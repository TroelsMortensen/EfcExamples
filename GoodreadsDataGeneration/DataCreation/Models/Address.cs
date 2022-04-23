namespace GoodreadsDataGeneration.DataCreation.Models;

public class Address
{
    public int Id { get; set; }
    public string PostCode { get; set; }
    public string CityName { get; set; }
    public string Street { get; set; }
    public int HouseNumber { get; set; }
}