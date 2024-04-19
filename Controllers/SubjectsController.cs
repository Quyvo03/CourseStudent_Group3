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
    public class SubjectsController : Controller
    {
        public class SampleContext : DbContext
        {
            public SampleContext() : base("name=QuanlysinhvienEntities14") { }
            public DbSet<Subjects> Subjects { get; set; }
        }
        // GET: Subjects
        public ActionResult Index()
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();
            var dsSubjects = db.Subjects.ToList();

            return View(dsSubjects);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Subjects model)
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();

            db.Subjects.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");

        }
        public ActionResult Edit(int? id)
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();
            var p = db.Subjects.FirstOrDefault(z => z.SubjectID == id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(int id, Subjects model)
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();
            //1. tim doi tuong
            if (id == model.SubjectID)
            {
                db.Subjects.AddOrUpdate(model);
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
            var p = db.Subjects.FirstOrDefault(y => y.SubjectID == id);
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
            var p = db.Subjects.FirstOrDefault(y => y.SubjectID == id);
            db.Subjects.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}