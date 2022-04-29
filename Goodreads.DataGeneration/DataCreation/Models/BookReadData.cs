namespace GoodreadsDataGeneration.DataCreation.Models;

public class BookReadData
{
    public string ProfileName { get; set; }
    public string BookId { get; set; }
    public int? Rating { get; set; }
    public DateTime DateFinishedReading { get; set; }
    public DateTime DateStartedReading { get; set; }
    public string? Review { get; set; }
}