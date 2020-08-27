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
    public class DevelopersController : Controller
    {
        private readonly IDeveloperService devService;
        private readonly IMapper mapper;
        public DevelopersController(IDeveloperService service, IMapper _mapper)
        {
            devService = service;
            mapper = _mapper;
        }
        // GET: Developers
        public ActionResult Index()
        {
            List<Developer> developers = devService.GetAllDevelopers().ToList();
            var devViewModel = mapper.Map<ICollection<DeveloperViewModel>>(developers);
            return View(devViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DeveloperViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dev = mapper.Map<Developer>(model);
                devService.AddDeveloper(dev);

                return RedirectToAction("Index");
            }
            return Create();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            devService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}