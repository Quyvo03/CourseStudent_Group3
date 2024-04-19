using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DTO
{
    public class ClassTeach
    {
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public string SubjectName { get; set; }
        public string ClassName { get; set; }
        public string CourseName { get; set; }

    }
}