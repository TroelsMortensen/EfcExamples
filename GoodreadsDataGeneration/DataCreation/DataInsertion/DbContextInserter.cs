using Goodreads.DataAccess;
using GoodreadsDataGeneration.DataCreation.Models;

namespace GoodreadsDataGeneration.DataCreation.DataInsertion;

public static class DbContextInserter
{
    public static void InsertData(DataBaseModelContainer container)
    {
        using GoodreadsContext gc = new();
        InsertPublishers(container, gc);
        InsertGenre(container, gc);
        InsertBindings(container, gc);
        InsertAuthor(container, gc);
        InsertProfiles(container, gc);
        InsertBooks(container, gc);
        InsertAnnouncements(container, gc);
        InsertBooksAuthored(container, gc);
        InsertBooksCoAuthored(container, gc);
        InsertPublishedBy(container, gc);
        InsertBookGenres(container, gc);
        InsertAnnouncementsLikes(container, gc);
        InsertCurrentlyReadings(container, gc);
        InsertWantToRead(container, gc);
        InsertRead(container, gc);
    }

    private static void InsertRead(DataBaseModelContainer container, GoodreadsContext goodreadsContext)
    {
        throw new NotImplementedException();
    }

    private static void InsertWantToRead(DataBaseModelContainer container, GoodreadsContext goodreadsContext)
    {
        throw new NotImplementedException();
    }

    private static void InsertCurrentlyReadings(DataBaseModelContainer container, GoodreadsContext goodreadsContext)
    {
        throw new NotImplementedException();
    }

    private static void InsertBookGenres(DataBaseModelContainer container, GoodreadsContext goodreadsContext)
    {
        throw new NotImplementedException();
    }

    private static void InsertPublishedBy(DataBaseModelContainer container, GoodreadsContext goodreadsContext)
    {
        throw new NotImplementedException();
    }

    private static void InsertBooksCoAuthored(DataBaseModelContainer container, GoodreadsContext goodreadsContext)
    {
        throw new NotImplementedException();
    }

    private static void InsertBooksAuthored(DataBaseModelContainer container, GoodreadsContext goodreadsContext)
    {
        throw new NotImplementedException();
    }

    private static void InsertAnnouncementsLikes(DataBaseModelContainer container, GoodreadsContext goodreadsContext)
    {
        throw new NotImplementedException();
    }

    private static void InsertAnnouncements(DataBaseModelContainer container, GoodreadsContext goodreadsContext)
    {
        throw new NotImplementedException();
    }

    private static void InsertBooks(DataBaseModelContainer container, GoodreadsContext goodreadsContext)
    {
        throw new NotImplementedException();
    }

    private static void InsertProfiles(DataBaseModelContainer container, GoodreadsContext goodreadsContext)
    {
        throw new NotImplementedException();
    }

    private static void InsertAuthor(DataBaseModelContainer container, GoodreadsContext goodreadsContext)
    {
        throw new NotImplementedException();
    }

    private static void InsertBindings(DataBaseModelContainer container, GoodreadsContext goodreadsContext)
    {
        throw new NotImplementedException();
    }

    private static void InsertGenre(DataBaseModelContainer container, GoodreadsContext goodreadsContext)
    {
        throw new NotImplementedException();
    }

    private static void InsertPublishers(DataBaseModelContainer container, GoodreadsContext goodreadsContext)
    {
        throw new NotImplementedException();
    }
}