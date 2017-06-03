using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class EventsController : Controller
    {
        private AppContext db = new AppContext();

        public ActionResult Index()
        {
            return View(db.Events.Where(e=>e.Date>=DateTime.Now).ToList());
        }

        public ActionResult Create()
        {
            ViewBag.AllUsers = db.Users.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Date,Place")] Event @event, int[] UserIds)
        {
            if (ModelState.IsValid)
            {
                db.AddEvent(@event, UserIds);
                return RedirectToAction("Index");
            }
            ViewBag.AllUsers = db.Users.ToList();
            return View(@event);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.AllUsers = db.Users.ToList(); 
            return View(@event);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Date,Place")] Event @event, int[] UserIds)
        {
            if (ModelState.IsValid)
            {
                db.UpdateEvent(@event, UserIds);
                return RedirectToAction("Index");
            }
            ViewBag.AllUsers = db.Users.ToList();
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
