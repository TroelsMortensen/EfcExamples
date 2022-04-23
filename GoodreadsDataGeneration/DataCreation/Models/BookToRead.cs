namespace GoodreadsDataGeneration.DataCreation.Models;

public class BookToRead
{
    public Profile Profile { get; set; }
    public Book Book { get; set; }
    public DateOnly DateAdded { get; set; }
}