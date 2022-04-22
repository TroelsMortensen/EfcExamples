using Goodreads.Entities;
using Microsoft.EntityFrameworkCore;

namespace Goodreads.DataAccess;

public class GoodreadsContext : DbContext
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookBinding> Bindings { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<CurrentlyReading> BooksCurrentlyBeingRead { get; set; }
    public DbSet<BookRead> BooksRead { get; set; }
    public DbSet<WantsToRead> BooksWantedToBeRead { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = Goodreads.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SetupAnnouncements(modelBuilder);
        SetupAuthor(modelBuilder);
        SetupBook(modelBuilder);
        SetupCity(modelBuilder);
        SetupCurrentlyReading(modelBuilder);
        SetupGenre(modelBuilder);
        SetupProfile(modelBuilder);
        SetupPublisher(modelBuilder);
        SetupBooksRead(modelBuilder);
        SetupWantsToRead(modelBuilder);
    }

    private void SetupWantsToRead(ModelBuilder modelBuilder)
    {
        throw new NotImplementedException();
    }

    private void SetupBooksRead(ModelBuilder modelBuilder)
    {
        throw new NotImplementedException();
    }

    private void SetupPublisher(ModelBuilder modelBuilder)
    {
        throw new NotImplementedException();
    }

    private void SetupProfile(ModelBuilder modelBuilder)
    {
        throw new NotImplementedException();
    }

    private void SetupGenre(ModelBuilder modelBuilder)
    {
        throw new NotImplementedException();
    }

    private void SetupCurrentlyReading(ModelBuilder modelBuilder)
    {
        throw new NotImplementedException();
    }

    private void SetupCity(ModelBuilder modelBuilder)
    {
        throw new NotImplementedException();
    }

    private void SetupBook(ModelBuilder modelBuilder)
    {
        throw new NotImplementedException();
    }

    private void SetupAuthor(ModelBuilder modelBuilder)
    {
        throw new NotImplementedException();
    }

    private void SetupAnnouncements(ModelBuilder modelBuilder)
    {
        throw new NotImplementedException();
    }
}