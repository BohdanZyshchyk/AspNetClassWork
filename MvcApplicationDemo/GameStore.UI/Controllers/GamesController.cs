using AutoMapper;
using GameStore.BLL.Filters;
using GameStore.BLL.Services;
using GameStore.BLL.Services.Abstraction;
using GameStore.DAL.Entities;
using GameStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        private void AddFilter(string type, string name)
        {
            if (Session["GameFilters"] == null)
                Session["GameFilters"] = new List<GameFilter>();
            var filter = new GameFilter
            {
                Name = name,
                Type = type
            };
            if(type == "Developer")
            {
                filter.Predicate = (x => x.Developer.Name == name);
            }
            else if(type == "Genre")
            {
                filter.Predicate = (x => x.Genre.Name == name);
            }
            (Session["GameFilters"] as List<GameFilter>).Add(filter);
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
        public ActionResult Create(GameViewModel model)
        {
            if (ModelState.IsValid)
            {
                var game = mapper.Map<Game>(model);
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
            gameService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
// new GamesController(new GameService(new EFRepository(new ApplicationContext())))