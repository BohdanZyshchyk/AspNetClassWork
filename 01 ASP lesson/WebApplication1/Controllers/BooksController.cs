using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BooksController : Controller
    {
        private readonly ICollection<Book> books = null;
        // GET: Books
        public BooksController()
        {
            books = new List<Book> { new Book {Author="R.S.Martin", Desc = "lorem ipsum" , Img="", Page="123",Title="Clean Code" , Year="2005"},
            new Book {Author="R.S.Martin2", Desc = "lorem loremipsum", Img="", Page="555",Title="Not Clean Code" , Year="2001"},
             new Book {Author="R.S.Martin3", Desc = "ipsum loremipsum", Img="", Page="8794",Title="Very Clean Code" , Year="2002"},
            new Book {Author="R.S.Martin4", Desc = "LOREM loremipsum", Img="", Page="1",Title="Very very Clean Code" , Year="2003"}};
        }
        public ActionResult Index()
        {
            ViewBag.Books = books;
            return View();
        }

        public ActionResult Detail(int id)
        {
            ViewBag.Detail = books.ToArray()[id];

            return View();
        }
    }
}