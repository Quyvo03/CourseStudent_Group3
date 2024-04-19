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
    public class StudentsController : Controller
    {
       
        // GET: Students
        public class SampleContext : DbContext
        {
            public SampleContext() : base("name=QuanlysinhvienEntities14") { }
            public DbSet<Students> Students { get; set; }
        }
        public ActionResult Index()
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();
            var dsStudents = db.Students.ToList();
            return View(dsStudents);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Students model)
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();

            db.Students.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");

        }
        public ActionResult Edit(int? id)
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();
            var p = db.Students.FirstOrDefault(z => z.StudentID == id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(int id, Students model)
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();
            //1. tim doi tuong
            if (id == model.StudentID)
            {
                db.Students.AddOrUpdate(model);
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
            var p = db.Students.FirstOrDefault(y => y.StudentID == id);
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
            var p = db.Students.FirstOrDefault(y => y.StudentID == id);
            db.Students.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}