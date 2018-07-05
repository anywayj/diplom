using Schedule.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Configuration;

namespace Schedule.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (Roles.IsUserInRole(User.Identity.Name, "Student"))
                    return RedirectToAction("Index","Student");
                if (Roles.IsUserInRole(User.Identity.Name, "Teacher"))
                    return View();
            }
            return View();
        }

        [HttpPost]
        public String LogIn(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserModel user = UserModel.getUserModel(model);
                    if (user == null)
                        return "Неправильный логин или пароль.";
                    else
                    {
                        FormsAuthentication.SetAuthCookie(user.Id.ToString(), true);
                        if (!Roles.RoleExists(user.Status))
                            Roles.CreateRole(user.Status);
                        if(!Roles.IsUserInRole(user.Id.ToString(), user.Status))
                            Roles.AddUserToRole(user.Id.ToString(), user.Status);
                        return "True:" + user.Status;
                    }
                }catch(Exception e)
                {
                    return e.Message + "\n" + e.StackTrace;
                }
            }
            else
                return "Ошибка сервера.";
        }

        public ActionResult LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                String[] roles = Roles.GetRolesForUser(User.Identity.Name);
                Roles.RemoveUserFromRoles(User.Identity.Name, roles);

                FormsAuthentication.SignOut();
            }
            return RedirectToAction("Index");
        }
       
    }
}