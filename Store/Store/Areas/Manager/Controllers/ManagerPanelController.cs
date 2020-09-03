using Store.Entities;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Areas.Manager.Controllers
{
    public class ManagerPanelController : Controller
    {
        private readonly ApplicationDbContext context;
        public ManagerPanelController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Manager/ManagerPanel
        public ActionResult Index()
        {
            List<NewsViewModel> news = context.News.Select(t => new NewsViewModel
            {
                Id = t.Id,
                ImageName = t.ImageName,
                Category = t.Category.Name,
                Date = t.Date,
                Text = t.Text,
                Title = t.Title
            }).ToList();
            return View(news);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Category = context.Categories.Select(x => x.Name).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = context.Categories.FirstOrDefault(x => x.Name == model.Category);
                var news = new News
                {
                    Category = category,
                    Date = DateTime.Now.ToShortDateString(),
                    ImageName = model.ImageName,
                    Text = model.Text,
                    Title = model.Title
                };
                context.News.Add(news);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return Create();
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
        public ActionResult Delete(int id)
        {
            context.News.Remove(context.News.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}