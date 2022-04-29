using GoodreadsDataGeneration.DataCreation.Conversion;
using GoodreadsDataGeneration.DataCreation.CsvImport;
using GoodreadsDataGeneration.DataCreation.DataInsertion;
using GoodreadsDataGeneration.DataCreation.Generators;
using GoodreadsDataGeneration.DataCreation.Models;


// GenerateData();
// InsertDataIntoDbContext();

Console.WriteLine("Currently doing nothing, in-comment either line above");

void GenerateData()
{
// import csv data, each row becomes a GoodreadsItem
    List<GoodreadsItem> items =
        new CsvImporter().ImportItems(
            @"C:\TRMO\RiderProjects\EfcExamples\Goodreads.DataGeneration\DataCreation\Source\goodreads_library_export.csv");

// convert GoodreadsItems to Model classes
    DataBaseModelContainer container = CsvModelToDbModelConverter.ConvertFromCsvModelToDbModel(items);

// Add genres to books, these were fetched from goodreads api
    GenreImporter.AddGenres(container.Books, container);

// Generate users, and their currently reading, has read, want to read.
    UserGenerator.AddUsers(container);

// Generate announcements by authors, and likes by users.
    AnnouncementGenerator.AddAnnouncements(container);

    PublisherGenerator.AddDataToPublisher(container);
// Store data as json for future use
    JsonSaver.SaveData(container);
}

void InsertDataIntoDbContext()
{
    DataBaseModelContainer container = JsonSaver.LoadData();
    DbContextInserter.InsertData(container);
}


