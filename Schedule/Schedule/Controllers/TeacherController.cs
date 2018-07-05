using Schedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Schedule.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public String GetModelTeacher()
        {
            UserModel user = UserModel.
                getUserModel(Convert.ToInt32(User.Identity.Name));
            return new JavaScriptSerializer().Serialize((TeacherModel)user.People);
        }

        [HttpPost]
        public String GetSchedule(int DayOfWeek)
        {
            UserModel user = UserModel.getUserModel(Convert.ToInt32(User.Identity.Name));
            List<LessonModel> lessons =
                LessonModel.getListLessons(((TeacherModel)user.People))
                .Where(lesson => (lesson.Day == DayOfWeek)).ToList();

            return new JavaScriptSerializer().Serialize(lessons);
        }
    }
}