using System.ComponentModel.DataAnnotations;

namespace Goodreads.Entities;

public class BookRead
{
    public int? Rating { get; set; }
    
    public DateOnly? DateStarted { get; set; }
    
    public DateOnly? DateFinished { get; set; }
    
    [MaxLength(500)]
    public string Review { get; set; }

    // nav prop
    public Profile Profile { get; set; }
    public Book Book { get; set; }
}