using GameStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStore.UI.Areas.User.Controllers
{
    public class CartController : Controller
    {
        // GET: User/Cart
        public ActionResult Index()
        {
            List<CartItemViewModel> games = Session["cart"] as List<CartItemViewModel>;
            return View(games);
        }
    }
}