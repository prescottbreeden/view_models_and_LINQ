using view_models.Models;

namespace view_models
{
  public class Dashboard
  {
    public User CurrentUser { get; set; }
    public BookLibrary Library { get; set; }
    public Dashboard(User currentUser, BookLibrary books)
    {
      CurrentUser = currentUser;
      Library = books;
    }
  }
}