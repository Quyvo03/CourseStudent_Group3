using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public class SampleContext : DbContext
        {
            public SampleContext() : base("name=QuanlysinhvienEntities14") { }
            public DbSet<Courses> Courses { get; set; }
        }
        public ActionResult Index()
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();
            var dsCourses = db.Courses.ToList();
            return View(dsCourses);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Courses model)
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();

            db.Courses.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");

        }
        public ActionResult Edit(int? id)
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();
            var p = db.Courses.FirstOrDefault(z => z.CourseID == id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(int id, Courses model)
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();
            //1. tim doi tuong
            if (id == model.CourseID)
            {
                db.Courses.AddOrUpdate(model);
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
            var p = db.Courses.FirstOrDefault(y => y.CourseID == id);
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
            var p = db.Courses.FirstOrDefault(y => y.CourseID == id);
            db.Courses.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
    
}