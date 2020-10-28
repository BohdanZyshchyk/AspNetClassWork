using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseJWTApplication819.DataAccess;
using BaseJWTApplication819.DTO.Models.Meme;
using Microsoft.AspNetCore.Mvc;

namespace BaseJWTApplication819.Api_Angular.Controllers
{
    public class MemeController : Controller
    {
        private readonly EFContext _context;
        public MemeController(EFContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public List<MemeDTO> getAllMemes()
        {
            var data = _context.Memes.Select(m => new MemeDTO
            {
                Id = m.Id,
                Date = m.Date,
                Image = m.Image,
                Rating = m.Rating
            }).ToList();
            return data;
        }
    }
}