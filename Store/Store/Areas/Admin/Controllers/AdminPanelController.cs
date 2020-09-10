using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Store.Entities;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace Store.Areas.Admin.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly ApplicationUserManager userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AdminPanelController()
        {
            context = new ApplicationDbContext();
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Index(string userId, string roleId)
        {
            var user = context.Users
                             .FirstOrDefault(x => x.Id.Equals(userId));

            var currentRoleId = context.Set<IdentityUserRole>()
                                       .FirstOrDefault(x => x.UserId.Equals(userId))
                                       .RoleId;

            var currentRole = roleManager.FindById(currentRoleId).Name;

            var removeResult =  userManager.RemoveFromRole(user.Id, currentRole);

            var addResult =  userManager.AddToRole(user.Id, roleId);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(CatgoriesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newCategory = new Category { Name = model.Name };
                context.Categories.Add(newCategory);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return CreateCategory();
        }
        
    }
}