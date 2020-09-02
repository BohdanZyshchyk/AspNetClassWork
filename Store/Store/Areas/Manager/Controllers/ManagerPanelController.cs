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
                Text = t.Text
            }).ToList();
            return View();
        }

       
    }
}