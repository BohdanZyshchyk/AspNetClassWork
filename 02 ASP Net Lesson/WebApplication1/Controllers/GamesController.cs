using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DataAccess;

namespace WebApplication1.Controllers
{
    public class GamesController : Controller
    {
        MyApplication context = new MyApplication();
        // GET: Games
        public ActionResult Index(string genre)
        {
            SetGenres();
            if (genre == "All")
            {
                var games = context.Games.ToList();
                ViewBag.Games = games;
            }
            else
            {
                var filtered = context.Games.Where(x => x.Genre.Name == genre).ToList();
                ViewBag.Games = filtered;
            }

            return View();
        }
        public ActionResult Details(int id)
        {
            SetGenres();
            var game = context.Games.FirstOrDefault(g => g.Id == id);
            ViewBag.Game = game;
            return View();
        }

        public ActionResult Search(string name)
        {
            SetGenres();
            
            var games = context.Games.Where(x => x.Name.Contains(name)).ToList();
            if (games.Count == 0)
            {
                ViewBag.Msg = "Nothing found";
                return View("Error"); 
            }
            ViewData["Games"] = games;
            //ViewBag.Games = games;
            return View("Index");
        }

        public ActionResult Create(string name)
        {
            SetGenres();
            ViewBag.Developers = context.Developers.ToList();
            return View();
        }
        private void SetGenres()
        {
            ViewBag.Genres = context.Genres.ToList();
        }
        //example request params
        public string Example(int a, int b)
        {
            return "Rectangle square =" + a * b;
        }
    }
}