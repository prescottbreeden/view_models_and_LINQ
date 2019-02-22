using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using view_models.Models;

namespace view_models.Controllers
{
  public class BookController : Controller
  {
    private static BookLibrary library { get; set; } = new BookLibrary();
    private static User bobRoss = new User("Bob", "Ross");

    [Route("")]
    [HttpGet]
    public IActionResult Index()
    {
      Dashboard dashboard = new Dashboard(bobRoss, library);
      return View(dashboard);
    }

    [HttpGet("checkout/{bookId}")]
    public IActionResult Add(int bookId)
    {
      Book checkout = library.Books.FirstOrDefault(b => b.BookId == bookId);
      bobRoss.FavoriteBooks.Add(checkout);
      library.Books.Remove(checkout);
      return RedirectToAction("Index");
    }

    [HttpGet("return/{bookId}")]
    public IActionResult Remove(int bookId)
    {
      Book returningBook = bobRoss.FavoriteBooks.FirstOrDefault(b => b.BookId == bookId);
      bobRoss.FavoriteBooks.Remove(returningBook);
      library.Books.Add(returningBook);
      return RedirectToAction("Index");
    }

  }
}
