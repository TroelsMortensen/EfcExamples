namespace GoodreadsDataGeneration.DataCreation.Models;

public class Announcement
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime TimeStamp { get; set; }    
}