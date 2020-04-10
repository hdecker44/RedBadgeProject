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
    public class TicketController : Controller
    {
        // GET: Ticket
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TicketService(userId);
            var model = service.GetTickets();

            return View(model);
        }

        //Add method here
        //GET
        public ActionResult Create()
        {
            var service = CreateEventService();

            ViewBag.EventId = new SelectList(service.GetEvents(), "EventId", "EventName");
            return View();
        }
        //Add code here
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TicketCreate model)
        {
            var serviceEvent = CreateEventService();
            var even = serviceEvent.GetEventById(model.EventId);
            if (even.SoldOut == true)
            {
                TempData["SaveResult"] = "This Event is Sold Out.";
                return RedirectToAction("Index");
            };

            if (!ModelState.IsValid) return View(model);


            var service = CreateTicketService();

            if (service.CreateTicket(model))
            {
                TempData["SaveResult"] = "Your ticket was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Ticket could not be created");

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("CreateTicketFromEvent")]
        public ActionResult CreateTicketFromEvent(TicketCreate ticket)
        {
            var service = CreateEventService();
            var even = service.GetEventById(ticket.EventId);
            ViewBag.EventName = even.EventName;
            var ticketCreate = new TicketCreate
            {
                EventId = ticket.EventId
            };
            return View(ticketCreate);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTicketService();
            var model = svc.GetTicketById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateTicketService();
            var detail = service.GetTicketById(id);
            var model =
                new TicketEdit
                {
                    TicketId = detail.TicketId,
                    EventName = detail.EventName,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TicketEdit model)
        {
            if (!ModelState.IsValid) return View();

            if (model.TicketId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTicketService();

            if (service.UpdateTicket(model))
            {
                TempData["SaveResult"] = "Your ticket was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your ticket could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTicketService();
            var model = svc.GetTicketById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTicketService();

            service.DeleteTicket(id);

            TempData["SaveResult"] = "Your ticket was deleted";

            return RedirectToAction("Index");
        }
        private TicketService CreateTicketService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TicketService(userId);
            return service;
        }
        private EventService CreateEventService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventService(userId);
            return service;
        }
    }
}