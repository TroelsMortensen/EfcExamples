using System.ComponentModel.DataAnnotations;

namespace Goodreads.Entities;

public class Genre
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string GenreName { get; set; }
    public ICollection<Book> DescribedBooks { get; set; }
}