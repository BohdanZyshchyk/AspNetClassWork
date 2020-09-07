using AutoMapper;
using GameStore.BLL.Filters;
using GameStore.BLL.Services.Abstraction;
using GameStore.DAL.Entities;
using GameStore.UI.Models;
using GameStore.UI.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace GameStore.UI.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameService gameService;
        private readonly IMapper mapper;
        //  3 DI
        public GamesController(IGameService service, IMapper _mapper)
        {
            gameService = service;
            mapper = _mapper;
        }
        // GET: Games
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Index(string type, string name)
        {
            SetFilters();
            List<Game> games = null;
            if (type != null && name != null)
            {
                AddFilter(type, name);
                games = gameService.FilterGames(Session["GameFilters"] as List<GameFilter>).ToList();
            }
            else games = gameService.GetAllGames().ToList();

            var gamesViewModel = mapper.Map<ICollection<GameViewModel>>(games);

            #region mapping
            //  var gamesViewModel = new List<GameViewModel>();
            //foreach (var item in games)
            //{
            //    gamesViewModel.Add(new GameViewModel
            //    {
            //        Id = item.Id,
            //        Name = item.Name,
            //        Developer = item.Developer.Name,
            //        Genre = item.Genre.Name,
            //        Year = item.Year,
            //        Description = item.Description,
            //        Image = item.Image
            //    });
            //} 
            #endregion

            return View(gamesViewModel);
        }

        [HttpGet]
        public ActionResult Search(string search)
        {
            var games = gameService.GetAllGames().Where(x => x.Name.Contains(search) || x.Developer.Name.Contains(search));

            var gamesViewModel = mapper.Map<ICollection<GameViewModel>>(games);
            if (games.Count() > 0)
            {
                return RedirectToAction("Index", gamesViewModel);
            }
            return HttpNotFound() ;
        }


        [HttpGet]
        public ActionResult Filter(string type, string name)
        {
            List<Game> games = null;
            if (type != null && name != null)
            {
                AddFilter(type, name);
                games = gameService.FilterGames(Session["GameFilters"] as List<GameFilter>).ToList();
            }
            else games = gameService.GetAllGames().ToList();

            var gamesViewModel = mapper.Map<ICollection<GameViewModel>>(games);

            return PartialView("Partial/GamesPartial", gamesViewModel);
        }

        private void AddFilter(string type, string name)
        {
            var filters = Session["GameFilters"] as List<GameFilter>;

            if (filters == null)
                filters = new List<GameFilter>();

            // перевірка чи фільтр вже існує
            var isExists =  filters.FirstOrDefault(x => x.Name == name && x.Type == type);
            if (isExists != null)
            {
                filters.Remove(isExists);
                Session["GameFilters"] = filters;
                return;
            }

            // create new filter
            var filter = new GameFilter
            {
                Name = name,
                Type = type
            };

            if (type == "Developer")
            {
                filter.Predicate = (x => x.Developer.Name == name);
            }
            else if (type == "Genre")
            {
                filter.Predicate = (x => x.Genre.Name == name);
            }
            filters.Add(filter);

            Session["GameFilters"] = filters;
        }

        private void SetFilters()
        {
            ViewBag.Developers = gameService.GetAllDevelopers();
            ViewBag.Genres = gameService.GetAllGenres();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Developers = gameService.GetAllDevelopers();
            ViewBag.Genres = gameService.GetAllGenres();

            gameService.GetAllGames();
            return View();
        }
        [HttpPost]
        public ActionResult Create(GameViewModel model, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                var game = mapper.Map<Game>(model);
                game.Image = SaveImage(imageFile);
                gameService.AddGame(game);

                return RedirectToAction("Index");
            }
            return Create();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            SetFilters();
            var game = gameService.GetGame(id);
            return View(mapper.Map<GameViewModel>(game));
        }
        [HttpPost]
        public ActionResult Edit(GameViewModel model)
        {
            if (ModelState.IsValid)
            {
                var game = mapper.Map<Game>(model);
                gameService.Update(game);
                return RedirectToAction("Index");
            }
            return Edit(model.Id);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var filePath = Server.MapPath("~/Content/img/" + gameService.GetGame(id).Image);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            gameService.Delete(id);
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
// new GamesController(new GameService(new EFRepository(new ApplicationContext())))