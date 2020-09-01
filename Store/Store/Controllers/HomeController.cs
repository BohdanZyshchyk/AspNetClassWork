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
                RoleId = context.Roles.FirstOrDefault(x=> x.Id==t.Id).Id
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