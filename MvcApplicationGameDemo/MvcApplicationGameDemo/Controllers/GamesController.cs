using GameStore.BLL.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplicationGameDemo.Controllers
{
    public class GamesController : Controller
    {
        // GET: Games
        private readonly IGameServices gamesServices;
        public GamesController(IGameServices services)
        {
            gamesServices = services;
        }
        public ActionResult Index()
        {
            var games = gamesServices.GetAllGames();
            return View();

        }
    }
}