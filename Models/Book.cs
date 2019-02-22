namespace view_models.Models
{
  public class Book
  {
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int ReleaseYear { get; set; }
    public Book(int bookId, string title, string author, int releaseYear)
    {
      BookId = bookId;
      Title = title;
      Author = author;
      ReleaseYear = releaseYear;
    }
  }
}