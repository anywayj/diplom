using Schedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Schedule.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public String GetSchedule(int DayOfWeek)
        {
            UserModel user = UserModel.getUserModel(Convert.ToInt32(User.Identity.Name));
            List<LessonModel> lessons = 
                ((StudentModel)user.People).
                Group.Lessons.Where(lesson => (lesson.Day == DayOfWeek)).ToList();

            return new JavaScriptSerializer().Serialize(lessons);
        }

        [HttpPost]
        public String GetModelStudent()
        {
            UserModel user = UserModel.
                getUserModel(Convert.ToInt32(User.Identity.Name));
            return new JavaScriptSerializer().Serialize((StudentModel)user.People);
        }

        [HttpPost]
        public String GetModelTeacher(int Id)
        {
            return new JavaScriptSerializer().
                Serialize(TeacherModel.getTeacherModel(Id));
        }
    }
}