using System.ComponentModel.DataAnnotations;

namespace Goodreads.Entities;

public class Address
{
    [Key] 
    public int Id { get; set; }
    
    [Required]
    public City City { get; set; }
    
    [Required, MaxLength(100)]
    public string Street { get; set; }
    
    [Required, Range(1, 99999)]
    public string HouseNumber { get; set; }
}