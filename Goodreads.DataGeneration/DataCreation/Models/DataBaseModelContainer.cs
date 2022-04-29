namespace GoodreadsDataGeneration.DataCreation.Models;

public class DataBaseModelContainer
{
    public List<AuthorData> Authors { get; set; }
    public List<BookData> Books { get; set; }
    public List<PublisherData> Publishers { get; set; }
    public List<BindingData> Bindings { get; set; }
    public List<ProfileData> Users { get; set; }
    public List<BookReadData> UsersHaveRead { get; set; }
    public List<BookToReadData> UsersWantToRead { get; set; }
    public List<CurrentlyReadingBookData> CurrentlyReadingBooks { get; set; }
    public List<GenreData> Genres { get; set; }
    public List<AnnouncementLikeData> AnnouncementLikes { get; set; }
    public List<AnnouncementData> Announcements { get; set; }
}