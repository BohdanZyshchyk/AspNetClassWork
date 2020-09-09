using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using News.DataAccess;
using News.DataAccess.Entity;
using NewsASPCORE.Models;

namespace NewsASPCORE.Controllers
{
    [ApiController]
    [Route("api/News")]
    public class NewsController : Controller
    {
        private readonly EFContext _context;
        public NewsController(EFContext context)
        {
            _context = context;
        }
       [HttpGet]
       public IEnumerable<NewsViewModel> getNews()
        {
            List<NewsViewModel> data = _context.News.Select(t => new NewsViewModel()
            {
                DatePost = t.DatePost,
                LinkImage = t.LinkImage,
                Id = t.Id,
                Description = t.Description,
                Title = t.Title
            }).ToList();
            return data;
        }
        [HttpPost("postNews")]
        public ResultDTO postNew([FromBody]NewsCreateDTO model)
        {
            try
            {
                _context.News.Add(new tblNews()
                {
                    DatePost = model.DatePost,
                    Description = model.Description,
                    LinkImage = model.LinkImage,
                    Title = model.Title
                });
                _context.SaveChanges();
                return new ResultDTO
                {
                    Status = 200,
                    Message = "OK"
                };
            }
            catch (Exception e)
            {

                return new ResultDTO
                {
                    Status = 500,
                    Message = e.Message
                };
            }
        }
    }
}
