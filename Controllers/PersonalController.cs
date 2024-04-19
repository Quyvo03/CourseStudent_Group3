using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebApplication1.Models; // Import the namespace containing your DbContext

namespace WebApplication1.Controllers
{
    public class PersonalController : Controller
    {
      
        

      
        // GET: Personal

        public class SampleContext : DbContext
        {
            public SampleContext() : base("name=QuanlysinhvienEntities14") { }
            public DbSet<PersonalInfo> PersonalInfos { get; set; }
        }


        public ActionResult Index()
        {
            using (QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14())
            {
                var dsPersonalInfo = db.PersonalInfo.ToList();
                return View(dsPersonalInfo);
            }
        }

        
        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]

        public ActionResult ThemMoi(PersonalInfo model)
        {
            using (QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14())
            {
                db.PersonalInfo.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        public ActionResult CapNhat(int? id)
        {
            using (QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14())
            {
                var p = db.PersonalInfo.FirstOrDefault(x => x.Id == id);
                return View(p);
            }
        }

        [HttpPost]

        public ActionResult CapNhat(int id, PersonalInfo model)
        {
            using (QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14())
            {
                if (id == model.Id)
                {
                    db.PersonalInfo.AddOrUpdate(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(model);
            }
        }

        [HttpGet]

        public ActionResult Delete(int? id)
        {
            using (QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14())
            {
                var p = db.PersonalInfo.FirstOrDefault(y => y.Id == id);
                if (p != null)
                {
                    return View(p);
                }
                return View();
            }
        }

        [HttpPost]

        public ActionResult Delete(int id)
        {
            using (QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14())
            {
                var p = db.PersonalInfo.FirstOrDefault(y => y.Id == id);
                db.PersonalInfo.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }

}
