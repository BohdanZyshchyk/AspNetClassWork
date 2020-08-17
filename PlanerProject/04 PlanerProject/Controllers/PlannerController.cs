using _04_PlanerProject.Entity;
using _04_PlanerProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _04_PlanerProject.Controllers
{
    public class PlannerController : Controller
    {
        private readonly EFContext _context;
        public PlannerController()
        {
            _context = new EFContext();
        }

        public ActionResult ListEvents()
        {

            List<EventViewModel> data = _context.Events.Select(t => new EventViewModel
            {
                Id = t.Id,
                Date = t.Date,
                Description = t.Description,
                Image = t.Image,
                Title = t.Title
            }).ToList();

            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Search()
        {
            List<EventViewModel> data = _context.Events.Select(t => new EventViewModel
            {
                Id = t.Id,
                Date = t.Date,
                Description = t.Description,
                Image = t.Image,
                Title = t.Title
            }).ToList();

            return RedirectToAction("ListEvents", "Planner");
        }
        [HttpPost]
        public ActionResult Create(EventCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(new PlanerEvent
                {
                    Date = model.Date,
                    Description = model.Description,
                    Image = model.Image,
                    Title = model.Title
                });
                _context.SaveChanges();
                return RedirectToAction("ListEvents", "Planner");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            _context.Events.Remove(_context.Events.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();

            return RedirectToAction("ListEvents", "Planner");
        }

       
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var eventEditModel = _context.Events.FirstOrDefault(x => x.Id == id);
            EventEditViewModel model = new EventEditViewModel
            {
                Id = eventEditModel.Id,
                Date = eventEditModel.Date,
                Description = eventEditModel.Description,
                Image = eventEditModel.Image,
                Title = eventEditModel.Title
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EventEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var edit = _context.Events.FirstOrDefault(x => x.Id == model.Id);
                edit.Image = model.Image;
                edit.Title = model.Title;
                edit.Date = model.Date;
                edit.Description = edit.Description;
                _context.SaveChanges();
                return RedirectToAction("ListEvents", "Planner");
            }
            else
            {
                return View();
            }
        }
    }
}