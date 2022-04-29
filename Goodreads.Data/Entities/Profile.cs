using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace Goodreads.Entities;

public class Profile
{
    [Key, MaxLength(50)]
    public string ProfileName { get; set; }
    
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    
    // nav prop
    public ICollection<CurrentlyReading> CurrentlyReadings { get; set; }
    public ICollection<WantsToRead> BooksToBeRead { get; set; }
    public ICollection<BookRead> BooksRead { get; set; }
    public ICollection<Announcement> AnnouncementsLiked { get; set; }

    public override string ToString()
    {
        return $"{ProfileName}, {FirstName} {LastName}";
    }
}