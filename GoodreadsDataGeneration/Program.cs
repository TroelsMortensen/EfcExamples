// See https://aka.ms/new-console-template for more information

using GoodreadsDataGeneration.DataCreation.Conversion;
using GoodreadsDataGeneration.DataCreation.CsvImport;
using GoodreadsDataGeneration.DataCreation.DataInsertion;
using GoodreadsDataGeneration.DataCreation.Generators;
using GoodreadsDataGeneration.DataCreation.Models;

// import csv data, each row becomes a GoodreadsItem
List<GoodreadsItem> items = new CsvImporter().ImportItems(@"C:\TRMO\RiderProjects\EfcExamples\GoodreadsDataGeneration\DataCreation\Source\goodreads_library_export.csv");

// convert GoodreadsItems to Model classes
DataBaseModelContainer container = CsvModelToDbModelConverter.ConvertFromCsvModelToDbModel(items);

// Add genres to books, these were fetched from goodreads api
GenreImporter.AddGenres(container.Books, container);

// Generate users, and their currently reading, has read, want to read.
UserGenerator.AddUsers(container);

// Generate announcements by authors, and likes by users.
AnnouncementGenerator.AddAnnouncements(container);

// Store data as json for future use
JsonSaver.SaveData(container);


// Insert data into sqlite database
// DbContextInserter.InsertData(container);


// or generate sql data files.
