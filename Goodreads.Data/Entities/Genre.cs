using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Goodreads.Entities;

public class Genre
{
    [Key]
    public int Id { get; set; }
    
    [Required, MaxLength(50)]
    public string GenreName { get; set; }
    
    public ICollection<Book> DescribedBooks { get; set; }

    public override string ToString()
    {
        return GenreName;
    }
}