using System.ComponentModel.DataAnnotations;

namespace Goodreads.Entities;

public class BookBinding
{
    [Key]
    public int Id { get; set; }
    
    [Required, MaxLength(50)]
    public string Type { get; set; }
}