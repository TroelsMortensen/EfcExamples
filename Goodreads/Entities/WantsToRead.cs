namespace Goodreads.Entities;

public class WantsToRead
{
    public Profile Profile { get; set; }
    public Book Book { get; set; }
    public DateOnly? DateAdded { get; set; }
}