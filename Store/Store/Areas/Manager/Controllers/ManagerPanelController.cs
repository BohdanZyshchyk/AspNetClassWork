using Store.Entities;
using Store.Helper;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
                ImageName = ImageConfig.DomainProject + "Images/UserPhoto/" + t.ImageName,
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
        public ActionResult Create(NewsViewModel model, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                var category = context.Categories.FirstOrDefault(x => x.Name == model.Category);
                var news = new News
                {
                    Category = category,
                    Date = DateTime.Now.ToShortDateString(),
                    ImageName = SaveImage(imageFile),
                    Text = model.Text,
                    Title = model.Title
                };
                context.News.Add(news);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return Create();
        }
       
        public ActionResult Delete(int id)
        {
            context.News.Remove(context.News.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public string SaveImage(HttpPostedFileBase imageFile)
        {
            string fileName = Guid.NewGuid().ToString() + ".jpg";
            string fullPathImage = Server.MapPath(ImageConfig.ProductImagePath) + "\\" + fileName;
            using (Bitmap bmp = new Bitmap(imageFile.InputStream))
            {
                var readyImage = Image_Helper.CreateImage(bmp, 450, 450);
                if (readyImage != null)
                {
                    readyImage.Save(fullPathImage, ImageFormat.Jpeg);
                    return fileName;
                }
            }
            return "no image";
        }
    }
}