using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BaseJWTApplication819.Api_Angular.Helper;
using BaseJWTApplication819.DataAccess;
using BaseJWTApplication819.DataAccess.Entity;
using BaseJWTApplication819.DTO.Models.Meme;
using BaseJWTApplication819.DTO.Models.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseJWTApplication819.Api_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemeController : ControllerBase
    {
        private readonly EFContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MemeController(EFContext context, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
      
        [HttpGet]
        public List<MemeDTO> getAllMemes()
        {
            List<Meme> meme = _context.Memes.ToList(); //devService.GetAllDevelopers().ToList();
            var data = _mapper.Map<ICollection<MemeDTO>>(meme);
            return data.ToList();
        }
        [HttpGet("getupvote")]
        public List<MemeDTO> getUpvotedMemes([FromRoute] string userId)
        {
            var meme = _context.UpvotedMemes.Where(x=> x.UserId == userId).Select(x=> x.Meme).ToList(); //devService.GetAllDevelopers().ToList();
            var data = _mapper.Map<ICollection<MemeDTO>>(meme);
            return data.ToList();
        }
        [HttpGet("getdownvote")]
        public List<MemeDTO> getDownvotedMemes([FromRoute] string userId)
        {
            var meme = _context.UpvotedMemes.Where(x => x.UserId == userId).Select(x => x.Meme).ToList(); //devService.GetAllDevelopers().ToList();
            var data = _mapper.Map<ICollection<MemeDTO>>(meme);
            return data.ToList();
        }
        [HttpGet("upvote/{id:int}/{userId}")]
        public List<MemeDTO> upvoteMeme([FromRoute] int id,[FromRoute] string userId)
        {
            var meme = _context.Memes.FirstOrDefault(x => x.Id == id);
            meme.Rating = meme.Rating+1;
            _context.SaveChanges();
            return getAllMemes();
        }
        [HttpGet("downvote/{id:int}/{userId}")]
        public List<MemeDTO> downvoteMeme([FromRoute] int id, [FromRoute] string userId)
        {
            var meme = _context.Memes.FirstOrDefault(x => x.Id == id);
            meme.Rating = meme.Rating - 1;
            _context.SaveChanges();
            return getAllMemes();
        }
        [HttpGet("detail/{id}")]
        public MemeDTO getMemeById([FromRoute] int id)
        {
            var meme = _context.Memes.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<MemeDTO>(meme);
        }
        [HttpPost]
        [Route("Upload/{id}")]
        public ResultDTO UploadImage([FromRoute] string id, [FromForm(Name = "file")] IFormFile image)
        {
            string filename = Guid.NewGuid().ToString() + ".jpg";
            string path = _webHostEnvironment.WebRootPath + @"\Images";
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = path + @"\"+ filename;
            if(image == null)
            {
                return new ResultDTO
                {
                    Status = 505,
                    Message = "File is empty"
                };
            }
            if (image.Length == 0)
            {
                return new ResultDTO
                {
                    Message = "File is empty",
                    Status = 506
                };
            }
            using (Bitmap b = new Bitmap(image.OpenReadStream()))
            {
                Bitmap savedImage = ImageWorker.CreateImage(b, 400, 360);
                if (savedImage !=null)
                {
                    savedImage.Save(path, ImageFormat.Jpeg);
                    Meme meme = _context.Memes.Find(id);
                    meme.Image = filename;
                    _context.SaveChanges();
                    return new ResultDTO
                    {
                        Message = "Image saved",
                        Status = 200
                    };
                }
                else
                {
                    return new ResultDTO
                    {
                        Message = "Uploading ERROR",
                        Status = 506
                    };
                }
            };
        }
    }
}