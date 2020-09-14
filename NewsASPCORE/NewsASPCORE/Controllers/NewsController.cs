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
        //https://localhost:44566/api/News/removeNews/13
        [HttpGet("removeNews/{id}")]
        public ResultDTO removeNews([FromRoute] int id)
        {
            try
            {

                var this_news = _context.News.FirstOrDefault(t => t.Id == id);
                if (this_news == null)
                {
                    return new ResultDTO
                    {
                        Status = 504,
                        Message = "not found news"
                    };
                }

                _context.News.Remove(this_news);
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
        [HttpPost("editNews/{id}")]
        public ResultDTO editNews([FromRoute] int id, [FromBody] NewsCreateDTO model)
        {
            try
            {
                var this_news = _context.News.FirstOrDefault(t => t.Id == id);
                if (this_news == null)
                {
                    return new ResultDTO
                    {
                        Status = 504,
                        Message = "not found news"
                    };
                }

                this_news.Title = model.Title;
                this_news.LinkImage = model.LinkImage;
                this_news.Description = model.Description;
                this_news.DatePost = model.DatePost;
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

        [HttpGet("getComments/{id}")]
        public IEnumerable<CommentsViewModel> getComments(int id)
        {
            List<CommentsViewModel> data = _context.Comments.Where(t => t.News.Id == id).Select(t => new CommentsViewModel
            {
                Id = t.Id,
                CommentAuthor = t.CommentAuthor,
                CommentText = t.CommentText

            }).ToList();
            return data;
        }

        [HttpPost("postComment/{id}")]
        public ResultDTO postComment(int id, [FromBody] CommentsCreateDTO model)
        {
            try
            {
                var news = _context.News.FirstOrDefault(t => t.Id == id);
                news.Comments.Add(new Comments()
                {
                    CommentAuthor = model.CommentAuthor,
                    CommentText = model.CommentText
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
