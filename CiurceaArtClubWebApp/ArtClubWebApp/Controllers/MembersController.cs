using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtClubWebApp.Models;
using System.Data.Entity;

namespace ArtClubWebApp.Controllers
{
    public class MembersController : Controller
    {
        //
        // GET: /Members/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (DBModel db = new DBModel())
            {
                List<Member> empList = db.Members.ToList<Member>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Member());
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.Members.Where(x => x.MemberId == id).FirstOrDefault<Member>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Member mem)
        {
            using (DBModel db = new DBModel())
            {
                if (mem.MemberId == 0)
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
            using (DBModel db = new DBModel())
            {
                Member mem = db.Members.Where(x => x.MemberId == id).FirstOrDefault<Member>();
                db.Members.Remove(mem);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }

}