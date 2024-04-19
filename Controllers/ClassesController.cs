using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                // Thiết lập đường dẫn chuyển hướng
                string redirectUrl = "/KhongCoQuyen/Index"; // Thay đổi đường dẫn đến controller và action mà bạn muốn chuyển hướng

                // Chuyển hướng
                filterContext.Result = new RedirectResult(redirectUrl);
            }
        }
    }
    public class ClassesController : Controller
    {

        // GET: Classes
        public class SampleContext : DbContext
        {
            public SampleContext() : base("name=QuanlysinhvienEntities14") { }
            public DbSet<Classes> Classes { get; set; }
        }
        public ActionResult Index()
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();
            var dsClasses = db.Classes.ToList();
            return View(dsClasses);
        }
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Classes model)
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();

            db.Classes.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");

        }
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();
            var p = db.Classes.FirstOrDefault(z => z.ClassID == id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(int id, Classes model)
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();
            //1. tim doi tuong
            if (id == model.ClassID)
            {
                db.Classes.AddOrUpdate(model);
                //3.Luu thay doi
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();
            var p = db.Classes.FirstOrDefault(y => y.ClassID == id);
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
            var p = db.Classes.FirstOrDefault(y => y.ClassID == id);
            db.Classes.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
    