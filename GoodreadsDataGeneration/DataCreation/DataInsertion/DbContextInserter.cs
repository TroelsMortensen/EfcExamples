using Goodreads.DataAccess;
using Goodreads.Entities;
using GoodreadsDataGeneration.DataCreation.Models;
using Microsoft.EntityFrameworkCore;
using Address = Goodreads.Entities.Address;
using Author = Goodreads.Entities.Author;
using Profile = Goodreads.Entities.Profile;

namespace GoodreadsDataGeneration.DataCreation.DataInsertion;

public static class DbContextInserter
{
    public static void InsertData(DataBaseModelContainer container)
    {
        InsertCities(container);
        InsertPublishers(container);
        InsertGenre(container);
        InsertBindings(container);
        InsertAuthor(container);
        InsertProfiles(container);
        InsertBooks(container);
        InsertAnnouncements(container);
        
        InsertBooksCoAuthored(container);
        InsertAnnouncementsLikes(container);
        InsertCurrentlyReadings(container);
        InsertWantToRead(container);
        InsertRead(container);
    }

    private static void InsertCities(DataBaseModelContainer container)
    {
        using GoodreadsContext ctx = new();
        Console.WriteLine("Inserting cities..");

        container.Publishers
            .Select(x => new City
            {
                Name = x.AddressData.CityName,
                PostCode = x.AddressData.PostCode
            })
            .ToList()
            .ForEach(c =>
            {
                if (!ctx.Cities.Any(x => x.PostCode == c.PostCode && x.Name.Equals(c.Name)))
                    ctx.Cities.Add(c);
            });

        ctx.SaveChanges();
        Console.WriteLine("Done!");
    }

    private static void InsertRead(DataBaseModelContainer container)
    {
        Console.WriteLine("Inserting has read");
        using GoodreadsContext ctx = new();
        int count = 0;
        foreach (BookReadData data in container.UsersHaveRead)
        {
            Book? book = ctx.Books.Find(int.Parse(data.BookId));
            Profile profile = ctx.Profiles.First(p => p.ProfileName.Equals(data.ProfileName));
            BookRead br = new()
            {
                Book = book,
                Profile = profile,
                Rating = data.Rating,
                Review = data.Review,
                BookId = book.Id,
                DateFinished = DateOnly.FromDateTime(data.DateFinishedReading),
                DateStarted = DateOnly.FromDateTime(data.DateStartedReading),
                ProfileName = data.ProfileName
            };
            ctx.BooksRead.Add(br);
            count++;
            if (count % 2500 == 0)
            {
                ctx.SaveChanges();
            }
        }

        ctx.SaveChanges();
        Console.WriteLine("Done");
    }

    private static void InsertWantToRead(DataBaseModelContainer container)
    {
        Console.WriteLine("Inserting wants to read");
        using GoodreadsContext ctx = new();
        int count = 0;
        foreach (BookToReadData data in container.UsersWantToRead)
        {
            Book? book = ctx.Books.Find(int.Parse(data.BookId));
            Profile profile = ctx.Profiles.First(p => p.ProfileName.Equals(data.ProfileName));
            WantsToRead wtr = new()
            {
                Book = book,
                Profile = profile,
                BookId = book.Id,
                ProfileName = profile.ProfileName,
                DateAdded = DateOnly.FromDateTime(data.DateAdded)
            };
            ctx.BooksWantedToBeRead.Add(wtr);
            count++;
            if (count % 2500 == 0)
            {
                ctx.SaveChanges();
            }
        }

        ctx.SaveChanges();
        Console.WriteLine("Done");
    }

    private static void InsertCurrentlyReadings(DataBaseModelContainer container)
    {
        Console.WriteLine("Inserting currently reading");
        using GoodreadsContext ctx = new();
        int count = 0;
        foreach (CurrentlyReadingBookData data in container.CurrentlyReadingBooks)
        {
            Book? book = ctx.Books.Find(int.Parse(data.BookId));
            Profile profile = ctx.Profiles.First(p => p.ProfileName.Equals(data.ProfileName));
            CurrentlyReading cr = new()
            {
                Book = book,
                Profile = profile,
                BookId = book.Id,
                ProfileName = profile.ProfileName,
                DateStarted = DateOnly.FromDateTime(data.DateStartedReading)
            };
            ctx.BooksCurrentlyBeingRead.Add(cr);
            count++;
            if (count % 2500 == 0)
            {
                ctx.SaveChanges();
            }
        }

        ctx.SaveChanges();
        Console.WriteLine("Done");
    }

    private static void InsertBookGenres(DataBaseModelContainer container)
    {
        throw new NotImplementedException();
    }

    private static void InsertPublishedBy(DataBaseModelContainer container)
    {
        throw new NotImplementedException();
    }

    private static void InsertBooksCoAuthored(DataBaseModelContainer container)
    {
        Console.WriteLine("Inserting co-authors");
        using GoodreadsContext ctx = new();
        foreach (BookData data in container.Books)
        {
            List<Author> coAuthors = ctx.Authors.Where(a => data.CoAuthors.Contains(a.Id)).ToList();
            Book book = ctx.Books.Find(int.Parse(data.BookId));
            book.CoAuthors = coAuthors;
        }

        ctx.SaveChanges();
        Console.WriteLine("Done");
    }

    private static void InsertBooksAuthored(DataBaseModelContainer container)
    {
        throw new NotImplementedException();
    }

    private static void InsertAnnouncementsLikes(DataBaseModelContainer container)
    {
        Console.WriteLine($"Inserting announcement likes, total: {container.AnnouncementLikes.Count}");
        using GoodreadsContext ctx = new();
        int count = 0;
        foreach (AnnouncementLikeData data in container.AnnouncementLikes)
        {
            Profile? profile = ctx.Profiles.First(p => p.ProfileName.Equals(data.ProfileName));
            Announcement? announcement = ctx.Announcements.Include(a => a.LikedByProfiles).First(a => a.Id == data.AnnouncementId);
            announcement.LikedByProfiles.Add(profile);

            if (count % 5000 == 0)
            {
                double progress = ((double)count / (double)container.AnnouncementLikes.Count);
                Console.WriteLine("\t" + progress + "%");
                ctx.SaveChanges();
            }

            count++;
        }

        ctx.SaveChanges();
        Console.WriteLine("Done");
    }

    private static void InsertAnnouncements(DataBaseModelContainer container)
    {
        Console.WriteLine("Inserting announcements");
        using GoodreadsContext ctx = new();
        foreach (AnnouncementData data in container.Announcements)
        {
            Author? author = ctx.Authors.Find(data.AuthorId);
            Announcement ann = new()
            {
                Content = data.Content,
                Id = data.Id,
                Title = data.Title,
                TimeStamp = data.TimeStamp,
                WrittenBy = author
            };
            ctx.Announcements.Add(ann);
        }

        ctx.SaveChanges();
        Console.WriteLine("Done");
    }

    private static void InsertBooks(DataBaseModelContainer container)
    {
        using GoodreadsContext ctx = new();
        Console.WriteLine("Inserting books");
        foreach (BookData data in container.Books)
        {
            Author author = ctx.Authors.Find(data.AuthorID);
            BookBinding bookBinding = ctx.Bindings.Find(data.BindingId);
            Publisher publisher = ctx.Publishers.Find(data.PublisherId);
            List<Genre> genres = ctx.Genres.Where(g => data.GenreIds.Contains(g.Id)).ToList();
            short? yp = null;
            if (data.YearPublished.HasValue)
            {
                yp = (short)data.YearPublished;
            }

            Book b = new()
            {
                Id = int.Parse(data.BookId),
                Isbn = data.ISBN,
                Title = data.Title,
                PageCount = data.PageCount,
                YearPublished = yp,
                WrittenBy = author,
                Binding = bookBinding,
                PublishedBy = publisher,
                Genres = genres
            };
            ctx.Books.Add(b);
        }

        ctx.SaveChanges();

        Console.WriteLine("Done");
    }

    private static void InsertProfiles(DataBaseModelContainer container)
    {
        using GoodreadsContext ctx = new();
        Console.WriteLine("Inserting profiles");
        foreach (ProfileData profile in container.Users)
        {
            Profile newPro = new()
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                ProfileName = profile.ProfileName,
            };
            ctx.Profiles.Add(newPro);
        }

        ctx.SaveChanges();
        Console.WriteLine("Done");
    }

    private static void InsertAuthor(DataBaseModelContainer container)
    {
        using GoodreadsContext ctx = new();
        Console.WriteLine("Inserting authors");
        foreach (AuthorData author in container.Authors)
        {
            Author a = new()
            {
                Email = author.Email,
                Id = author.Id,
                Website = author.Website,
                FirstName = author.FirstName,
                LastName = author.LastName,
                MiddleNames = author.MiddelNames
            };
            ctx.Authors.Add(a);
        }

        ctx.SaveChanges();
        Console.WriteLine("Done!");
    }

    private static void InsertBindings(DataBaseModelContainer container)
    {
        using GoodreadsContext ctx = new();
        Console.WriteLine("Inserting bindings");
        foreach (BindingData binding in container.Bindings)
        {
            BookBinding bb = new()
            {
                Id = binding.Id,
                Type = binding.Type
            };
            ctx.Bindings.Add(bb);
        }

        ctx.SaveChanges();
        Console.WriteLine("Done!");
    }

    private static void InsertGenre(DataBaseModelContainer container)
    {
        using GoodreadsContext ctx = new();
        Console.WriteLine("Inserting genre");
        foreach (GenreData genre in container.Genres)
        {
            Genre g = new()
            {
                Id = genre.Id,
                GenreName = genre.Genre
            };
            ctx.Genres.Add(g);
        }

        ctx.SaveChanges();
        Console.WriteLine("Done");
    }

    private static void InsertPublishers(DataBaseModelContainer container)
    {
        using GoodreadsContext ctx = new();
        Console.WriteLine("Inserting publisher");
        foreach (PublisherData pub in container.Publishers)
        {
            City existingCity =
                ctx.Cities.First(c => pub.AddressData.CityName.Equals(c.Name) && pub.AddressData.PostCode.Equals(c.PostCode));
            Address a = new()
            {
                City = existingCity,
                Street = pub.AddressData.Street,
                HouseNumber = pub.AddressData.HouseNumber
            };
            Goodreads.Entities.Publisher newPub = new()
            {
                Address = a,
                Name = pub.Name
            };
            ctx.Publishers.Add(newPub);
        }

        ctx.SaveChanges();
        Console.WriteLine("Done!");
    }
}