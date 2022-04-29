using System;

namespace GoodreadsDataGeneration.DataCreation.Models;

public class CurrentlyReadingBookData
{
    public string ProfileName { get; set; }
    public string BookId { get; set; }
    public DateTime DateStartedReading { get; set; }
}