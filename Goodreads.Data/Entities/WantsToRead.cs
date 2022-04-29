using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Goodreads.Entities;

public class WantsToRead
{
    [ForeignKey(nameof(Profile))]
    public string ProfileName { get; set; }
    
    [ForeignKey(nameof(Book))]
    public int BookId { get; set; }
    
    public Profile Profile { get; set; }
    public Book Book { get; set; }
    public DateOnly? DateAdded { get; set; }
}