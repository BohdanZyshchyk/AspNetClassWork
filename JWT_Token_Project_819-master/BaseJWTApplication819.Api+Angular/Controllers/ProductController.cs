using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseJWTApplication819.DataAccess;
using BaseJWTApplication819.DataAccess.Entity;
using BaseJWTApplication819.DTO.Models;
using BaseJWTApplication819.DTO.Models.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseJWTApplication819.Api_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly EFContext _context;
        public ProductController(EFContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<ProductDTO> getAllProducts()
        {
            var data = _context.Products.Select(t => new ProductDTO
            {
                Id = t.Id,
                Description = t.Description,
                Image = t.ImageURL,
                Price = t.Price,
                Title = t.Title,
            }).ToList();
            return data;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("add")]
        public ResultDTO AddProduct([FromBody] ProductDTO model)
        {
            var product = new Product
            {
                Description = model.Description,
                ImageURL = model.Image,
                Price = model.Price,
                Title = model.Title
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            return new ResultDTO
            {
                Message = "Ok",
                Status = 200
            };
        }
        [HttpGet("search")]
        public IEnumerable<ProductDTO> SearchProduct([FromQuery] string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return getAllProducts();
            }

            search = search.ToLower();
            var products = _context.Products
                                  .Where(x => x.Title.ToLower().Contains(search))
                                  .Select(x => new ProductDTO
                                  {
                                      Description = x.Description,
                                      Id = x.Id,
                                      Image = x.ImageURL,
                                      Price = x.Price,
                                      Title = x.Title
                                  }).ToArray();

            return products;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("delete")]
        public IEnumerable<ProductDTO> DeleteProduct([FromBody] int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);

            _context.Products.Remove(product);

            _context.SaveChanges();

            return getAllProducts();
        }
    }
}
