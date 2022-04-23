using System.ComponentModel.DataAnnotations;

namespace Goodreads.Entities;

public class Book
{
    // Defined by OnModelCreating
    [Key]    
    public int Id { get; set; }
    [StringLength(13)]
    public string? Isbn { get; set; }
    [Required, MaxLength(50)]
    public string Title { get; set; }
    [Range(0, 9999)]
    public int? PageCount { get; set; }
    [Range(1500, 9999)]
    public short? YearPublished { get; set; }
    
    public BookBinding? Binding { get; set; }
    public ICollection<Genre> Genres { get; set; }
    public Author? WrittenBy { get; set; }
    
    // nav props
    public Publisher? PublishedBy { get; set; }
    public ICollection<Author> CoAuthors { get; set; }
    public ICollection<CurrentlyReading> CurrentlyReadBy { get; set; }
    public ICollection<WantsToRead> WantedToBeReadBY { get; set; }
    public ICollection<BookRead> ReadBy { get; set; }
}