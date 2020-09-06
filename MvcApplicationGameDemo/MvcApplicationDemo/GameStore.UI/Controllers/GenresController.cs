using AutoMapper;
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
    public class GenresController : Controller
    {
        private readonly IGenreService genService;
        private readonly IMapper mapper;
        public GenresController(IGenreService service, IMapper _mapper)
        {
            genService = service;
            mapper = _mapper;
        }
        // GET: Genres
        public ActionResult Index()
        {
            List<Genre> Genres = genService.GetAllGenres().ToList();
            var devViewModel = mapper.Map<ICollection<GenreViewModel>>(Genres);
            return View(devViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(GenreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dev = mapper.Map<Genre>(model);
                genService.AddGenre(dev);

                return RedirectToAction("Index");
            }
            return Create();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            genService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var game = genService.GetGenre(id);
            return View(mapper.Map<GenreViewModel>(game));
        }
        [HttpPost]
        public ActionResult Edit(GenreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dev = mapper.Map<Genre>(model);
                genService.Update(dev);
                return RedirectToAction("Index");
            }
            return Edit(model.Id);
        }
    }
}