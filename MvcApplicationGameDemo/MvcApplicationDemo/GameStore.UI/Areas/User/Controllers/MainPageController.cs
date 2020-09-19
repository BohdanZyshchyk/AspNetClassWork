using AutoMapper;
using GameStore.BLL.Filters;
using GameStore.BLL.Services.Abstraction;
using GameStore.DAL.Entities;
using GameStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStore.UI.Areas.User.Controllers
{
    public class MainPageController : Controller
    {
        // GET: User/MainPage
        private readonly IGameService gameService;
        private readonly IMapper mapper;
        //  3 DI
        public MainPageController(IGameService service, IMapper _mapper)
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
            return HttpNotFound();
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
            var isExists = filters.FirstOrDefault(x => x.Name == name && x.Type == type);
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
        public ActionResult AddToCart(int id)
        {
            var game = gameService.GetGame(id);

            var gamesViewModel = mapper.Map<GameViewModel>(game);

            if (Session["cart"] == null)
            {
                List<CartItemViewModel> cart = new List<CartItemViewModel>();
                cart.Add(new CartItemViewModel { Game = gamesViewModel, Quantity = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<CartItemViewModel> cart = (List<CartItemViewModel>)Session["cart"];
                int index = isExist(id.ToString());
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new CartItemViewModel { Game = gamesViewModel, Quantity = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }

        private int isExist(string id)
        {
            List<CartItemViewModel> cart = (List<CartItemViewModel>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Game.Id.Equals(id))
                    return i;
            return -1;
        }

    }
}