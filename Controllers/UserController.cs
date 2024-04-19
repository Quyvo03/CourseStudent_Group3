using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Canview(int classid)
        {
            return View();  
            // Code để hiển thị danh sách lớp học
        }


        public ActionResult Details(int classId)
        {
            return View();
            // Code để hiển thị chi tiết lớp học
        }
    }
}