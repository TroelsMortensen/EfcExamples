namespace GoodreadsDataGeneration.DataCreation.Models;

public class GenreData
{
    public int Id { get; set; }
    public string Genre { get; set; }

    public override bool Equals(object? obj)
    {
        GenreData gc = (GenreData)obj;
        return Id == gc.Id && Genre.Equals(gc.Genre);
    }
}