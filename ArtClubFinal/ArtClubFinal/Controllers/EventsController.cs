using ArtClubFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtClubFinal.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GuestIndex()
        {
            return View();
        }



        public ActionResult GetData()
        {
            using (ArtClubWebAppEntities db = new ArtClubWebAppEntities())
            {
                List<Event> eventList = db.Events.ToList<Event>();
                return Json(new { data = eventList }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Event());
            else
            {
                using (ArtClubWebAppEntities db = new ArtClubWebAppEntities())
                {
                    return View(db.Events.Where(x => x.EventID == id).FirstOrDefault<Event>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Event eve)
        {
            using (ArtClubWebAppEntities db = new ArtClubWebAppEntities())
            {
                if (eve.EventID == 0)
                {
                    db.Events.Add(eve);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(eve).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (ArtClubWebAppEntities db = new ArtClubWebAppEntities())
            {
                Event eve = db.Events.Where(x => x.EventID == id).FirstOrDefault<Event>();
                db.Events.Remove(eve);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Description()
        {

            return View();



        }
    }
}