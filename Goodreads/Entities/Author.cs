using System.ComponentModel.DataAnnotations;

namespace Goodreads.Entities;

public class Author
{
    [Key]
    public int Id { get; set; }
    
    [Required, MaxLength(100)]
    public string FirstName { get; set; }

    public string? MiddleNames { get; set; }

    [Required, MaxLength(100)]
    public string LastName { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
    [MaxLength(500)]
    public string About { get; set; }
    
    [Url]
    public string Website { get; set; }
    
    // nav props
    public ICollection<Book> BooksAuthored { get; set; }
    public ICollection<Book> BooksCoAuthored { get; set; }
    
}