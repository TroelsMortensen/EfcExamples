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

    private static List<CurrentlyReadingBookData> GenerateUserCurrentlyReading(DataBaseModelContainer container)
    {
        Console.WriteLine("Generating currently reading books");
        List<CurrentlyReadingBookData> list = new();
        foreach (ProfileData user in container.Users)
        {
            int count = 0;
            Dictionary<string, CurrentlyReadingBookData> data = new();
            int numOfBooksToRead = rand.Next(0, 4);
            for (int i = 0; i < numOfBooksToRead; i++)
            {
                CurrentlyReadingBookData crb = GenerateOneCurrentlyReadingBook(container, user);
                if (!data.ContainsKey(crb.BookId))
                {
                    data.Add(crb.BookId, crb);
                    count++;
                }
            }

            list.AddRange(data.Values);

            Console.WriteLine($"\tAdded books for user {user.Id}, they are currently reading {count} books");
        }

        Console.WriteLine("Done!");
        return list;
    }

    private static CurrentlyReadingBookData GenerateOneCurrentlyReadingBook(DataBaseModelContainer container, ProfileData profileData)
    {
        CurrentlyReadingBookData crb = new();
        BookData? bookToRead = null;

        while (bookToRead == null)
        {
            bookToRead = container.Books[rand.Next(container.Books.Count)];

            if (!bookToRead.YearPublished.HasValue)
                bookToRead = null;
        }

        crb.BookId = bookToRead.BookId;
        crb.ProfileName = profileData.ProfileName;

        int yearPublished = (int)bookToRead.YearPublished!;

        DateTime startDate = new DateTime(yearPublished, 1, 1);
        DateTime endDate = DateTime.Now;
        TimeSpan timeSpan = endDate - startDate;
        TimeSpan newSpan = new TimeSpan(0, rand.Next(0, (int)timeSpan.TotalMinutes), 0);
        DateTime newDate = startDate + newSpan;

        crb.DateStartedReading = newDate;

        return crb;
    }

    private static List<BookToReadData> GenerateUserWantToRead(DataBaseModelContainer container)
    {
        Console.WriteLine("Adding want to read books for users");
        List<BookToReadData> list = new();
        foreach (ProfileData user in container.Users)
        {
            int count = 0;
            Dictionary<string, BookToReadData> data = new();
            int numOfBooksToRead = rand.Next(5, 250);
            for (int i = 0; i < numOfBooksToRead; i++)
            {
                BookToReadData btr = GenerateOneWantToReadBook(container, user);
                if (!data.ContainsKey(btr.BookId))
                {
                    data.Add(btr.BookId, btr);
                    count++;
                }
            }

            list.AddRange(data.Values);

            Console.WriteLine($"\tAdded books for user {user.Id}, they want to read {count} books");
        }

        Console.WriteLine("Done");
        return list;
    }

    private static BookToReadData GenerateOneWantToReadBook(DataBaseModelContainer container, ProfileData profileData)
    {
        BookToReadData btr = new();
        BookData? bookToRead = null;

        while (bookToRead == null)
        {
            bookToRead = container.Books[rand.Next(container.Books.Count)];
        }

        btr.BookId = bookToRead.BookId;
        btr.ProfileName = profileData.ProfileName;

        DateTime startDate = new DateTime(2010, 1, 1);
        DateTime endDate = DateTime.Now;
        TimeSpan timeSpan = endDate - startDate;
        TimeSpan newSpan = new TimeSpan(0, rand.Next(0, (int)timeSpan.TotalMinutes), 0);
        DateTime newDate = startDate + newSpan;

        btr.DateAdded = newDate;

        return btr;
    }

    private static List<BookReadData> GenerateUserHaveRead(DataBaseModelContainer container)
    {
        Console.WriteLine("Adding have read books to users");
        List<BookReadData> list = new();
        foreach (ProfileData user in container.Users)
        {
            int count = 0;
            Dictionary<string, BookReadData> data = new();
            int numOfBooksToRead = rand.Next(5, 250);
            for (int i = 0; i < numOfBooksToRead; i++)
            {
                BookReadData br = GenerateOneBookRead(container, user);
                if (!data.ContainsKey(br.BookId))
                {
                    data.Add(br.BookId, br);
                    count++;
                }
            }

            list.AddRange(data.Values);

            Console.WriteLine($"\tAdded books for user {user.Id}, they have read {count} books");
        }

        Console.WriteLine("Done!");
        return list;
    }

    private static BookReadData GenerateOneBookRead(DataBaseModelContainer container, ProfileData profileData)
    {
        BookReadData br = new();
        BookData? bookIsRead = null;

        while (bookIsRead == null)
        {
            bookIsRead = container.Books[rand.Next(container.Books.Count)];
            if (!bookIsRead.YearPublished.HasValue) bookIsRead = null;
            
        }

        br.BookId = bookIsRead.BookId;
        br.ProfileName = profileData.ProfileName;

        br.Rating = rand.Next(1, 6);
        int yearPublished = (int)bookIsRead.YearPublished!;


        DateOnly start = new DateOnly(rand.Next(yearPublished, 2022), 1, 1).AddMonths(rand.Next(0, 13)).AddDays(rand.Next(0, 31));
        DateOnly end = start.AddDays(rand.Next(4, 50));
        br.DateStartedReading = start.ToDateTime(TimeOnly.Parse("10:00 PM"));
        br.DateFinishedReading = end.ToDateTime(TimeOnly.Parse("10:00 PM"));
        br.Review = rand.Next(0, 2) == 0 ? null : RandomStringGenerator.GetRandomString(25, true);

        return br;
    }


    private static List<ProfileData> GenerateUsers()
    {
        List<ProfileData> users = new();
        for (int i = 0; i < UserName.list.Length; i++)
        {
            ProfileData profileData = new()
            {
                LastName = LastName.list[rand.Next(LastName.list.Length)],
                FirstName = rand.Next(2) == 0
                    ? FemaleName.list[rand.Next(FemaleName.list.Length)]
                    : MaleName.list[rand.Next(MaleName.list.Length)],
                Id = (i + 1),
                ProfileName = UserName.list[i]
            };
            users.Add(profileData);
        }

        return users;
    }
}