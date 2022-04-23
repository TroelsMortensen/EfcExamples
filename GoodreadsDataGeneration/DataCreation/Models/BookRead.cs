namespace GoodreadsDataGeneration.DataCreation.Models;

public class BookRead
{
    public Profile Profile { get; set; }
    public Book Book { get; set; }
    public int? Rating { get; set; }
    public DateOnly DateFinishedReading { get; set; }
    public DateOnly DateStartedReading { get; set; }
    public string? Review { get; set; }
}