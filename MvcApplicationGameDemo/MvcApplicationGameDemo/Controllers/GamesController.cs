using AutoMapper;
using GameStore.BLL.Services.Abstraction;
using GameStore.DAL.Entities;
using MvcApplicationGameDemo.Models;
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
        private readonly IMapper mapper;
        public GamesController(IGameServices services, IMapper _mapper)
        {
            gamesServices = services;
            mapper = _mapper;
        }
        public ActionResult Index()
        {
            var games = gamesServices.GetAllGames();
            var gamesViewModel = mapper.Map<ICollection<GameCreateViewModel>>(games);
            ViewBag.Developers = gamesServices.GetAllDevelopers();

            //var gamesViewModel = new List<GameCreateViewModel>();
            //foreach (var item in games)
            //{
            //    gamesViewModel.Add(new GameCreateViewModel
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
            return View(gamesViewModel);

        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Developers = gamesServices.GetAllDevelopers();
            ViewBag.Genres = gamesServices.GetAllGenres();
            return View();
        }
        [HttpPost]
        public ActionResult Create(GameCreateViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var game = mapper.Map<Game>(model);
                gamesServices.AddGame(game);
                return RedirectToAction("Index");
            }
            return Create();
        }
    }
}