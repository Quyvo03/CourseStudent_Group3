using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{

    public class HomeController : Controller
    {
        // GET: Home


        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                // Nếu chưa đăng nhập, chuyển hướng đến trang đăng nhập
                return RedirectToAction("Login");
            }
            // Khởi tạo danh sách môn học và lớp học
            string subjectsHtml = LoadSubjects();
            string classesHtml = LoadClasses();
            string coursesHtml = LoadCourses();
            string teachersHtml = LoadTeachers();
            string studentsHtml = LoadStudents();
            // Truyền dữ liệu vào view
            ViewBag.SubjectsHtml = subjectsHtml;
            ViewBag.ClassesHtml = classesHtml;
            ViewBag.CoursesHtml = coursesHtml;
            ViewBag.TeachersHtml = teachersHtml;
            ViewBag.StudentsHtml = studentsHtml;
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            QuanlysinhvienEntities14 db = new QuanlysinhvienEntities14();
            var user = db.Users.SingleOrDefault(x => x.Username.ToLower() == username.ToLower() && x.Password == password);

            if (user == null)
            {


                TempData["StatusMessage"] = "Infomation wrong";
                return View();
            }
            
                System.Diagnostics.Debug.WriteLine("User logged in successfully: " + user.Username);
                HttpContext.Session["user"] = user.Username;
                HttpContext.Session["id"] = user.Id.ToString();



            if (user.Role == "Admin")
            {
                return RedirectToAction("Index", "Home");
            }
            
            else if (user.Role == "Teachers")
            {
                return RedirectToAction("index", "TeacherView");
            }
            else if (user.Role == "User")
            {
                return RedirectToAction("index", "Classes1");
            }
            return RedirectToAction("Login");
        }


        public ActionResult Dangxuat()
        {
            Session.Remove("user");
            FormsAuthentication.SignOut();
            return RedirectToAction("Dang Xuat");
        }
        // Phương thức để tải danh sách môn học từ SQL Server
        private string LoadSubjects()
        {
            string connectionString = "Data Source=NAMLE\\SQLEXPRESS;Initial Catalog=Quanlysinhvien;Integrated Security=True"; // Thay đổi connection string cho phù hợp
            string query = "SELECT * FROM Subjects"; // Thay đổi truy vấn để lấy dữ liệu từ bảng môn học của bạn

            string subjectsHtml = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string subjectName = reader["SubjectName"].ToString(); // Thay "SubjectName" bằng tên cột chứa tên môn học trong cơ sở dữ liệu của bạn

                    // Tạo HTML cho mỗi môn học
                    subjectsHtml += $"<li>{subjectName}</li>";
                }

                reader.Close();
            }

            return subjectsHtml;
        }

        // Phương thức để tải danh sách lớp học từ SQL Server
        private string LoadClasses()
        {
            string connectionString = "Data Source=NAMLE\\SQLEXPRESS;Initial Catalog=Quanlysinhvien;Integrated Security=True"; // Thay đổi connection string cho phù hợp
            string query = "SELECT * FROM Classes"; // Thay đổi truy vấn để lấy dữ liệu từ bảng lớp học của bạn

            string classesHtml = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string className = reader["ClassName"].ToString(); // Thay "ClassName" bằng tên cột chứa tên lớp học trong cơ sở dữ liệu của bạn

                    // Tạo HTML cho mỗi lớp học
                    classesHtml += $"<li>{className}</li>";
                }

                reader.Close();
            }

            return classesHtml;
        }
        // Action method để hiển thị danh sách khóa học
        private string LoadCourses()
        {
            string connectionString = "Data Source=NAMLE\\SQLEXPRESS;Initial Catalog=Quanlysinhvien;Integrated Security=True"; // Thay đổi connection string cho phù hợp
            string query = "SELECT * FROM Courses"; // Thay đổi truy vấn để lấy dữ liệu từ bảng khóa học của bạn

            string coursesHtml = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string courseName = reader["CourseName"].ToString(); // Thay "CourseName" bằng tên cột chứa tên khóa học trong cơ sở dữ liệu của bạn

                    // Tạo HTML cho mỗi khóa học
                    coursesHtml += $"<li>{courseName}</li>";
                }

                reader.Close();
            }

            return coursesHtml;
        }

        // Action method để hiển thị danh sách giáo viên

        // Phương thức để tạo HTML cho danh sách giáo viên
        private string LoadTeachers()
        {
            string connectionString = "Data Source=NAMLE\\SQLEXPRESS;Initial Catalog=Quanlysinhvien;Integrated Security=True"; // Thay đổi connection string cho phù hợp
            string query = "SELECT * FROM Teachers"; // Thay đổi truy vấn để lấy dữ liệu từ bảng giáo viên

            string teachersHtml = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string teacherName = reader["TeacherName"].ToString(); // Lấy tên giáo viên từ cơ sở dữ liệu

                    // Tạo HTML cho mỗi giáo viên
                    teachersHtml += $"<li>{teacherName}</li>";
                }

                reader.Close();
            }

            return teachersHtml;
        }


        // Phương thức để tạo HTML cho danh sách sinh viên
        private string LoadStudents()
        {
            string connectionString = "Data Source=NAMLE\\SQLEXPRESS;Initial Catalog=Quanlysinhvien;Integrated Security=True"; // Thay đổi connection string cho phù hợp
            string query = "SELECT * FROM Students"; // Thay đổi truy vấn để lấy dữ liệu từ bảng sinh viên

            string studentsHtml = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string studentName = reader["StudentName"].ToString(); // Lấy tên sinh viên từ cơ sở dữ liệu

                    // Tạo HTML cho mỗi sinh viên
                    studentsHtml += $"<li>{studentName}</li>";
                }

                reader.Close();
            }

            return studentsHtml;
        }
        public ActionResult Search(string searchString)
        {
            using (var db = new QuanlysinhvienEntities14())
            {
                var searchResults = db.Courses
                    .Where(p => p.CourseName.Contains(searchString)) // Điều kiện tìm kiếm
                    .ToList();

                return Json(searchResults, JsonRequestBehavior.AllowGet);
            }
        }


    }
}