using System.IO;
using System.Text.Json;
using GoodreadsDataGeneration.DataCreation.Models;

namespace GoodreadsDataGeneration.DataCreation.Generators;

public static class JsonSaver
{
    public static void SaveData(DataBaseModelContainer container)
    {
        string serialized = JsonSerializer.Serialize(container, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(@"C:\TRMO\RiderProjects\EfcExamples\Goodreads.DataGeneration\DataCreation\Source\DataAsJson.json", serialized);
    }

    public static DataBaseModelContainer LoadData()
    {
        string asJson = File.ReadAllText(@"C:\TRMO\RiderProjects\EfcExamples\Goodreads.DataGeneration\DataCreation\Source\DataAsJson.json");
        DataBaseModelContainer container = JsonSerializer.Deserialize<DataBaseModelContainer>(asJson)!;
        return container;
    }
}