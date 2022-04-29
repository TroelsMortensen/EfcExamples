using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Goodreads.Entities;

public class Publisher
{
    [Key]
    public int Id { get; set; }
    
    [Required, MaxLength(100)]
    public string Name { get; set; }
    
    public Address? Address { get; set; }

    // nav prop
    public ICollection<Book> BooksPublished { get; set; }
}