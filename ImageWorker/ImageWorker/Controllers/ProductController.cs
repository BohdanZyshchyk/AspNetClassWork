using ImageWorker.Entity;
using ImageWorker.Helper;
using ImageWorker.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageWorker.Controllers
{
    public class ProductController : Controller
    {
        private readonly EFContext _context;
        public ProductController()
        {
            _context = new EFContext();
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateProductVewModel model, HttpPostedFileBase imageFile)
        {
            string fileName = Guid.NewGuid().ToString() + ".jpg";
            string fullPathImage = Server.MapPath(ImageConfig.ProductImagePath)+ "\\" + fileName;
            using (Bitmap bmp = new Bitmap(imageFile.InputStream))
            {
                var readyImage = Image_Helper.CreateImage(bmp, 450, 450);
                if (readyImage != null)
                {
                    readyImage.Save(fullPathImage, ImageFormat.Jpeg);
                    Product newProduct = new Product
                    {
                        ImageName = fileName,
                        Name = model.Name,
                        Price = model.Price
                    };
                    _context.products.Add(newProduct);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult List()
        {
            List<ProductViewModel> products = _context.products.Select(t=> new ProductViewModel
            {
                Name = t.Name,
                Price = t.Price,
                LinkImage = ImageConfig.DomainProject + "Images/Product/" + t.ImageName
            }).ToList(); 
            return View(products);
        }
    }
}