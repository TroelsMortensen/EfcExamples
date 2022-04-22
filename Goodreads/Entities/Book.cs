namespace Goodreads.Entities;

public class Book
{
    // Defined by OnModelCreating
    
    public int Id { get; set; }
    public string Isbn { get; set; }
    public string Title { get; set; }
    public int PageCount { get; set; }
    public short YearPublished { get; set; }
    public BookBinding Binding { get; set; }
    public ICollection<Genre> Genres { get; set; }
    public Author WrittenBy { get; set; }
    
    // nav props
    public ICollection<Author> CoAuthors { get; set; }
    public Publisher PublishedBy { get; set; }
    public ICollection<CurrentlyReading> CurrentlyReadBy { get; set; }
    public ICollection<WantsToRead> WantedToBeReadBY { get; set; }
    public ICollection<BookRead> ReadBy { get; set; }
}