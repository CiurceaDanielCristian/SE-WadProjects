using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtClubFinal.Models;
namespace ArtClubFinal.Controllers
{
    public class MembersController : Controller
    {
        // GET: Members
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GuestIndex()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();



        }

        public ActionResult GetData()
        {
            using (ArtClubWebAppEntities db = new ArtClubWebAppEntities())
            {
                List<Member> memList = db.Members.ToList<Member>();
                return Json(new { data = memList }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Member());
            else
            {
                using (ArtClubWebAppEntities db = new ArtClubWebAppEntities())
                {
                    return View(db.Members.Where(x => x.MemberID == id).FirstOrDefault<Member>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Member mem)
        {
            using (ArtClubWebAppEntities db = new ArtClubWebAppEntities())
            {
                if (mem.MemberID == 0)
                {
                    db.Members.Add(mem);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(mem).State = EntityState.Modified;
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
                Member mem = db.Members.Where(x => x.MemberID == id).FirstOrDefault<Member>();
                db.Members.Remove(mem);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}