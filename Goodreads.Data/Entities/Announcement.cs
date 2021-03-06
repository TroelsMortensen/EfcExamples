using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Goodreads.Entities;

public class Announcement
{
    // Defined by OnModelCreating
    
    public int Id { get; set; }
    public string Content { get; set; }
    public string Title { get; set; }
    public DateTime TimeStamp { get; set; }
    public ICollection<Profile> LikedByProfiles { get; set; }

    public Author WrittenBy { get; set; }
}