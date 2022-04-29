using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Goodreads.Entities;

public class CurrentlyReading
{
    [ForeignKey(nameof(Profile))]
    public string ProfileName { get; set; }
    
    [ForeignKey(nameof(Book))]
    public int BookId { get; set; }
    public Profile Profile { get; set; }
    public Book Book { get; set; }
    
    public DateOnly DateStarted { get; set; }
}