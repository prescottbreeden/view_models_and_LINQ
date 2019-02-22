using System.Collections.Generic;

namespace view_models.Models
{
  public class BookLibrary
  {
    public List<Book> Books { get; set; } = new List<Book>();
    public BookLibrary()
    {
      Books.Add(new Book(1, "Hamlet", "Bill Shakespeare", 1602));
      Books.Add(new Book(2, "Moby Dick", "Hermit Melville", 1851));
      Books.Add(new Book(3, "Frankenstein", "Merry Shelly", 1818));
      Books.Add(new Book(4, "Lord of the Rings", "J.R.R. Token", 1954));
      Books.Add(new Book(5, "Harry Potter", "J.K. Bowling", 1998));
    }
  }
}