using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TeacherViewController : Controller
    {
        public class SampleContext : DbContext
        {
            public SampleContext() : base("name=QuanlysinhvienEntities14") { }
            public DbSet<Teachers> Teachers { get; set; }
        }
        // GET: TeacherView
        public ActionResult Index()
        {

            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();
            int? id = null;
            if (HttpContext.Session["id"] != null)
            {
                if (int.TryParse(HttpContext.Session["id"].ToString(), out int userId))
                {
                    id = userId;
                }
            }

            var courses = db.Teachers
             .Include(t => t.Subjects) // Bao gồm thông tin về các môn học của giáo viên
             .Include(t => t.Courses) // Bao gồm thông tin về các môn học của giáo viên
             .Where(t => t.TeacherID == id) 
             .ToList();


            return View(courses);
        }

        public ActionResult Details(int id)
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();

            var user = (from a in db.Teachers
                    join b in db.Courses on a.CourseID equals b.CourseID
                    join c in db.Subjects on a.SubjectID equals c.SubjectID
                    join d in db.Classes on c.SubjectID equals d.SubjectID
                    where a.TeacherID == id
                    select new ClassTeach
                    {
                       TeacherID = a.TeacherID,
                       TeacherName = a.TeacherName,
                       SubjectName = c.SubjectName,
                       CourseName = b.CourseName,
                       ClassName = d.ClassName
                    }).ToList();
            return View(user);
        }
       
    }
}