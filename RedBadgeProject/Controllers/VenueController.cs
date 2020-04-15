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
    public class VenueController : Controller
    {
        // GET: Ticket
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VenueService(userId);
            var model = service.GetVenues();

            return View(model);
        }

        //Add method here
        //GET
        public ActionResult Create()
        {
            return View();
        }
        //Add code here
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VenueCreate model)
        {
            if (!ModelState.IsValid) return View(model);


            var service = CreateVenueService();

            if (service.CreateVenue(model))
            {
                TempData["SaveResult"] = "Your Venue was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Venue could not be created");

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateVenueService();
            var model = svc.GetVenueById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateVenueService();
            var detail = service.GetVenueById(id);
            var model =
                new VenueEdit
                {
                    VenueId = detail.VenueId,
                    VenueName = detail.VenueName,
                    StreetNumber = detail.StreetNumber,
                    City = detail.City,
                    State = detail.State,
                    ZipCode = detail.ZipCode,
                    Seats = detail.Seats,
                    Image = detail.Image
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VenueEdit model)
        {
            if (!ModelState.IsValid) return View();

            if (model.VenueId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateVenueService();

            if (service.UpdateVenue(model))
            {
                TempData["SaveResult"] = "Your Venue was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Venue could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateVenueService();
            var model = svc.GetVenueById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateVenueService();

            service.DeleteVenue(id);

            TempData["SaveResult"] = "Your Venue was deleted";

            return RedirectToAction("Index");
        }
        private VenueService CreateVenueService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VenueService(userId);
            return service;
        }
    }
}