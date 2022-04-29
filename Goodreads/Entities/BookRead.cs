using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Goodreads.Entities;

public class BookRead
{
    [ForeignKey(nameof(Profile))]
    public string ProfileName { get; set; }
    
    [ForeignKey(nameof(Book))]
    public int BookId { get; set; }
    
    public int? Rating { get; set; }
    
    public DateOnly? DateStarted { get; set; }
    
    public DateOnly? DateFinished { get; set; }
    
    [MaxLength(500)]
    public string? Review { get; set; }

    // nav prop
    public Profile Profile { get; set; }
    public Book Book { get; set; }
}