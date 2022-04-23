namespace GoodreadsDataGeneration.DataCreation.Models;

public class CurrentlyReadingBook
{
    public Profile Profile { get; set; }
    public Book Book { get; set; }
    public DateOnly DateStartedReading { get; set; }
}