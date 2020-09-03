using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;
        public HomeController()
        {
            context = new ApplicationDbContext();

        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId(); //Отримали айді користувача який зараз залогінений
            if (userId != null)
            {
                var RoleId = context.Set<IdentityUserRole>().FirstOrDefault(t => t.UserId == userId).RoleId;
                var role = context.Roles.FirstOrDefault(t => t.Id == RoleId);
                if (role.Name == "Admin")
                {
                    return RedirectToAction("Index", "AdminPanel", new { area = "Admin" });
                }
                else if (role.Name == "Manager")
                {
                    return RedirectToAction("Index", "ManagerPanel", new { area = "Manager" });
                }
            }
            return View();
        }
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            List<UserViewModel> users = context.Users.Select(t => new UserViewModel
            {
                Id = t.Id,
                Email = t.Email,
                RoleId = context.Roles.FirstOrDefault(x => x.Id == t.Id).Id
            }).ToList();

            List<RolesViewModel> roles = context.Roles.Select(t => new RolesViewModel
            {
                RoleId = t.Id,
                RoleName = t.Name
            }).ToList();

            UserRolesViewModel userRolesView = new UserRolesViewModel(users, roles);
            return View(userRolesView);
        }
        [HttpPost]
        public ActionResult Admin(string id, string role)
        {
            var userToUp = context.Users.FirstOrDefault(t => t.Id == id);
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}