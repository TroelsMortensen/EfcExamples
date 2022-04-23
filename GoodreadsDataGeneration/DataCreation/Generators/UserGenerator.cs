using GoodreadsDataGeneration.DataCreation.Generators.Data;
using GoodreadsDataGeneration.DataCreation.Models;

namespace GoodreadsDataGeneration.DataCreation.Generators;

public static class UserGenerator
{
    private static Random rand = new();

    public static void AddUsers(DataBaseModelContainer container)
    {
        container.Users = GenerateUsers();
        container.UsersHaveRead = GenerateUserHaveRead(container);
        container.UsersWantToRead = GenerateUserWantToRead(container);
        container.CurrentlyReadingBooks = GenerateUserCurrentlyReading(container);
    }

    private static List<CurrentlyReadingBook> GenerateUserCurrentlyReading(DataBaseModelContainer container)
    {
        List<CurrentlyReadingBook> list = new();
        foreach (Profile user in container.Users)
        {
            int count = 0;
            Dictionary<string, CurrentlyReadingBook> data = new();
            int numOfBooksToRead = rand.Next(0, 4);
            for (int i = 0; i < numOfBooksToRead; i++)
            {
                CurrentlyReadingBook crb = GenerateOneCurrentlyReadingBook(container, user);
                if (!data.ContainsKey(crb.Book.BookId))
                {
                    data.Add(crb.Book.BookId, crb);
                    count++;
                }
            }

            list.AddRange(data.Values);

            Console.WriteLine($"Added books for user {user.Id}, they have read {count} books");
        }

        return list;
    }

    private static CurrentlyReadingBook GenerateOneCurrentlyReadingBook(DataBaseModelContainer container, Profile profile)
    {
        CurrentlyReadingBook crb = new();
        Book? bookToRead = null;

        while (bookToRead == null)
        {
            bookToRead = container.Books[rand.Next(container.Books.Count)];
           
            if (container.UsersHaveRead.Any(br => br.Book.BookId == bookToRead.BookId)) // have already read the book 
                bookToRead = null;

            if (container.UsersWantToRead.Any(btr => btr.Book.BookId == bookToRead.BookId)) // is on want to read list
                bookToRead = null;
        }

        crb.Book = bookToRead;
        crb.Profile = profile;

        int yearPublished = (int)crb.Book.YearPublished!;

        DateTime startDate = new DateTime(yearPublished, 1, 1);
        DateTime endDate = DateTime.Now;
        TimeSpan timeSpan = endDate - startDate;
        TimeSpan newSpan = new TimeSpan(0, rand.Next(0, (int)timeSpan.TotalMinutes), 0);
        DateTime newDate = startDate + newSpan;

        DateOnly added = DateOnly.FromDateTime(newDate);
        crb.DateStartedReading = added;

        return crb;
    }

    private static List<BookToRead> GenerateUserWantToRead(DataBaseModelContainer container)
    {
        List<BookToRead> list = new();
        foreach (Profile user in container.Users)
        {
            int count = 0;
            Dictionary<string, BookToRead> data = new();
            int numOfBooksToRead = rand.Next(25, 750);
            for (int i = 0; i < numOfBooksToRead; i++)
            {
                BookToRead btr = GenerateOneWantToReadBook(container, user);
                if (!data.ContainsKey(btr.Book.BookId))
                {
                    data.Add(btr.Book.BookId, btr);
                    count++;
                }
            }

            list.AddRange(data.Values);

            Console.WriteLine($"Added books for user {user.Id}, they have read {count} books");
        }

        return list;
    }

    private static BookToRead GenerateOneWantToReadBook(DataBaseModelContainer container, Profile profile)
    {
        BookToRead btr = new();
        Book? bookToRead = null;

        while (bookToRead == null)
        {
            bookToRead = container.Books[rand.Next(container.Books.Count)];
            
            if (container.UsersHaveRead.Any(br => br.Book.BookId == bookToRead.BookId)) // have already read the book 
                bookToRead = null;
                        
        }

        btr.Book = bookToRead;
        btr.Profile = profile;

        int yearPublished = (int)btr.Book.YearPublished!;


        DateTime startDate = new DateTime(yearPublished, 1, 1);
        DateTime endDate = DateTime.Now;
        TimeSpan timeSpan = endDate - startDate;
        TimeSpan newSpan = new TimeSpan(0, rand.Next(0, (int)timeSpan.TotalMinutes), 0);
        DateTime newDate = startDate + newSpan;

        DateOnly added = DateOnly.FromDateTime(newDate);
        btr.DateAdded = added;

        return btr;
    }

    private static List<BookRead> GenerateUserHaveRead(DataBaseModelContainer container)
    {
        List<BookRead> list = new();
        foreach (Profile user in container.Users)
        {
            int count = 0;
            Dictionary<string, BookRead> data = new();
            int numOfBooksToRead = rand.Next(25, 450);
            for (int i = 0; i < numOfBooksToRead; i++)
            {
                BookRead br = GenerateOneBookRead(container, user);
                if (!data.ContainsKey(br.Book.BookId))
                {
                    data.Add(br.Book.BookId, br);
                    count++;
                }
            }

            list.AddRange(data.Values);

            Console.WriteLine($"Added books for user {user.Id}, they have read {count} books");
        }

        return list;
    }

    private static BookRead GenerateOneBookRead(DataBaseModelContainer container, Profile profile)
    {
        BookRead br = new();
        Book? bookIsRead = null;

        while (bookIsRead == null)
        {
            bookIsRead = container.Books[rand.Next(container.Books.Count)];
            if (!bookIsRead.YearPublished.HasValue) bookIsRead = null;
        }

        br.Book = bookIsRead;
        br.Profile = profile;

        br.Rating = rand.Next(1, 6);
        int yearPublished = (int)br.Book.YearPublished!;


        DateOnly start = new DateOnly(rand.Next(yearPublished, 2022), 1, 1).AddMonths(rand.Next(0, 13)).AddDays(rand.Next(0, 31));
        DateOnly end = start.AddDays(rand.Next(4, 50));
        br.DateStartedReading = start;
        br.DateFinishedReading = end;
        br.Review = rand.Next(0, 2) == 0 ? null : RandomStringGenerator.GetRandomString(500);

        return br;
    }


    private static List<Profile> GenerateUsers()
    {
        List<Profile> users = new();
        for (int i = 0; i < UserName.list.Length; i++)
        {
            Profile profile = new()
            {
                LastName = LastName.list[rand.Next(LastName.list.Length)],
                FirstName = rand.Next(2) == 0
                    ? FemaleName.list[rand.Next(FemaleName.list.Length)]
                    : MaleName.list[rand.Next(MaleName.list.Length)],
                Id = (i + 1),
                ProfileName = UserName.list[i]
            };
            users.Add(profile);
        }

        return users;
    }
}