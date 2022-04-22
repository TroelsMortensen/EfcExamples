using System.ComponentModel.DataAnnotations;

namespace Goodreads.Entities;

public class CurrentlyReading
{
    public Profile Profile { get; set; }
    public Book Book { get; set; }
    
    [Required]
    public DateOnly DateStarted { get; set; }
}