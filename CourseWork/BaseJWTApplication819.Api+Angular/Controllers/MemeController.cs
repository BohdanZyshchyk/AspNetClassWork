using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseJWTApplication819.DataAccess;
using BaseJWTApplication819.DTO.Models.Meme;
using Microsoft.AspNetCore.Mvc;

namespace BaseJWTApplication819.Api_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemeController : ControllerBase
    {
        private readonly EFContext _context;
        public MemeController(EFContext context)
        {
            _context = context;
        }
      
        [HttpGet]
        public List<MemeDTO> getAllMemes()
        {
            var data = _context.Memes.Select(m => new MemeDTO
            {
                Id = m.Id,
                Title = m.Title,
                Date = m.Date,
                Image = m.Image,
                Rating = m.Rating
            }).ToList();
            return data;
        }
        [HttpGet("upvote/{id}")]
        public List<MemeDTO> upvoteMeme([FromRoute] int id)
        {
            var meme = _context.Memes.FirstOrDefault(x => x.Id == id);
            meme.Rating = meme.Rating+1;
            _context.SaveChanges();
            return getAllMemes();
        }
    }
}