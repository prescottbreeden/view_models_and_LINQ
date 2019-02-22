using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using view_models.Models;

namespace view_models.Controllers
{
  public class HomeController : Controller
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

    [HttpGet("add/{bookId}")]
    public IActionResult Add(int bookId)
    {
      Book newFavorite = library.Books.FirstOrDefault(b => b.BookId == bookId);
      bobRoss.FavoriteBooks.Add(newFavorite);
      return RedirectToAction("Index");
    }

    [HttpGet("remove/{bookId}")]
    public IActionResult Remove(int bookId)
    {
      bobRoss.FavoriteBooks.Remove(library.Books.FirstOrDefault(b => b.BookId == bookId));
      return RedirectToAction("Index");
    }

  }
}
