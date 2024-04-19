using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public class SampleContext : DbContext
        {
            public SampleContext() : base("name=QuanlysinhvienEntities14") { }
            public DbSet<Teachers> Teachers { get; set; }
        }
        public ActionResult Index()
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();
            var dsTeachers = db.Teachers.ToList();
            return View(dsTeachers);
   
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Teachers model)
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();

            db.Teachers.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");

        }
        public ActionResult Edit(int? id)
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();
            var p = db.Teachers.FirstOrDefault(z => z.TeacherID == id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(int id, Teachers model)
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();
            //1. tim doi tuong
            if (id == model.TeacherID)
            {
                db.Teachers.AddOrUpdate(model);
                //3.Luu thay doi
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();
            var p = db.Teachers.FirstOrDefault(y => y.TeacherID == id);
            if (p != null)
            {
                return View(p);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();
            var p = db.Teachers.FirstOrDefault(y => y.TeacherID == id);
            db.Teachers.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}