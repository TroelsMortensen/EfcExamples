using System;

namespace GoodreadsDataGeneration.DataCreation.Models;

public class AnnouncementData
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime TimeStamp { get; set; }    
}