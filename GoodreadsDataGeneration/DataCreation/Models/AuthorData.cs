namespace GoodreadsDataGeneration.DataCreation.Models;

public class AuthorData
{
    public string FirstName { get; set; }
    public string MiddelNames { get; set; }
    public string LastName { get; set; }

    public int Id { get; set; }
    public string Email { get; set; }
    public string About { get; set; }
    public string? Website { get; set; }
}