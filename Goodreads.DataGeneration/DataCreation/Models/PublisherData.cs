namespace GoodreadsDataGeneration.DataCreation.Models;

public class PublisherData
{
    public int Id { get; set; }
    public string Name { get; set; }

    public AddressData AddressData { get; set; }
}