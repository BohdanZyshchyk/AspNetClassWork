using Microsoft.AspNet.Identity.EntityFramework;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Areas.Admin.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly ApplicationDbContext context;
        public AdminPanelController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Admin/AdminPanel
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<UserViewModel> users = context.Users.Select(t => new UserViewModel
            {
                Id = t.Id,
                Email = t.Email,
                RoleId = context.Set<IdentityUserRole>().FirstOrDefault(x => x.UserId == t.Id).RoleId
            }).ToList();

            List<RolesViewModel> roles = context.Roles.Select(t => new RolesViewModel
            {
                RoleId = t.Id,
                RoleName = t.Name
            }).ToList();

            UserRolesViewModel userRolesView = new UserRolesViewModel(users, roles);
            return View(userRolesView);
        }
    }
}