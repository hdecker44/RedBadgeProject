using Microsoft.AspNet.Identity;
using RedBadge.Models;
using RedBadge.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeProject.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        // GET: Ticket
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventService(userId);
            var model = service.GetEvents();

            return View(model);
        }

        //Add method here
        //GET
        public ActionResult Create()
        {
            var service = CreateVenueService();

            ViewBag.VenueId = new SelectList(service.GetVenues(), "VenueId", "VenueName");
            return View();
        }
        //Add code here
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCreate model)
        {
            if (!ModelState.IsValid) return View(model);


            var service = CreateEventService();

            if (service.CreateEvent(model))
            {
                TempData["SaveResult"] = "Your Event was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Event could not be created");

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateEventService();
            var model = svc.GetEventById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateEventService();
            var detail = service.GetEventById(id);
            var model =
                new EventEdit
                {
                    EventId = detail.EventId,
                    EventName = detail.EventName,
                    EventType = detail.EventType,
                    VenueName = detail.VenueName,
                    PriceGA = detail.PriceGA,
                    PriceVIP = detail.PriceVIP,
                    DateTime = detail.DateTime,
                    Description = detail.Description
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventEdit model)
        {
            if (!ModelState.IsValid) return View();

            if (model.EventId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateEventService();

            if (service.UpdateEvent(model))
            {
                TempData["SaveResult"] = "Your Event was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Event could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateEventService();
            var model = svc.GetEventById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateEventService();

            service.DeleteEvent(id);

            TempData["SaveResult"] = "Your Event was deleted";

            return RedirectToAction("Index");
        }
        private EventService CreateEventService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventService(userId);
            return service;
        }
        private VenueService CreateVenueService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VenueService(userId);
            return service;
        }
    }
}