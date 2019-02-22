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
    private static BookLibrary Library { get; set; } = new BookLibrary();
    private static int BookId { get; set; } = Library.Books.Max(b => b.BookId);
    private static User BobRoss = new User("Bob", "Ross");

    [Route("")]
    [HttpGet]
    public IActionResult Index()
    {
      Dashboard dashboard = new Dashboard(BobRoss, Library);
      return View(dashboard);
    }

    [HttpGet("checkout/{bookId}")]
    public IActionResult Add(int bookId)
    {
      Book checkout = Library.Books.FirstOrDefault(b => b.BookId == bookId);
      BobRoss.FavoriteBooks.Add(checkout);
      Library.Books.Remove(checkout);
      return RedirectToAction("Index");
    }

    [HttpGet("return/{bookId}")]
    public IActionResult Remove(int bookId)
    {
      Book returningBook = BobRoss.FavoriteBooks.FirstOrDefault(b => b.BookId == bookId);
      BobRoss.FavoriteBooks.Remove(returningBook);
      Library.Books.Add(returningBook);
      return RedirectToAction("Index");
    }

    [HttpPost("newbook")]
    public IActionResult NewBook(Book book)
    {
      book.BookId = ++BookId;
      Library.Books.Add(book);
      return RedirectToAction("Index");
    }

  }
}
