using Goodreads.Entities;
using Microsoft.EntityFrameworkCore;

namespace Goodreads.DataAccess;

public class GoodreadsContext : DbContext
{
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Announcement> Announcements { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<BookBinding> Bindings { get; set; } = null!;
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<Profile> Profiles { get; set; } = null!;
    public DbSet<Publisher> Publishers { get; set; } = null!;
    public DbSet<CurrentlyReading> BooksCurrentlyBeingRead { get; set; } = null!;
    public DbSet<BookRead> BooksRead { get; set; } = null!;
    public DbSet<WantsToRead> BooksWantedToBeRead { get; set; } = null!;

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
        SetupWantsToRead(modelBuilder);
        SetupBooksRead(modelBuilder);
    }

    private void SetupWantsToRead(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WantsToRead>().HasKey(x => new { x.BookId, x.ProfileName });
    }

    private void SetupBooksRead(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookRead>().HasKey(x => new { x.BookId, x.ProfileName });
    }

    private void SetupPublisher(ModelBuilder modelBuilder)
    {
        // Probably nothing to do here
    }

    private void SetupProfile(ModelBuilder modelBuilder)
    {
        // Probably nothing to do here
    }

    private void SetupGenre(ModelBuilder modelBuilder)
    {
        // Probably nothing to do here
    }

    private void SetupCurrentlyReading(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CurrentlyReading>().HasKey(x => new { x.BookId, x.ProfileName });
    }

    private void SetupCity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>().HasKey(x => new { x.Name, x.PostCode });
    }

    private void SetupBook(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasOne(book => book.WrittenBy)
                .WithMany(author => author.BooksAuthored);

            entity.HasMany(book => book.CoAuthors)
                .WithMany(author => author.BooksCoAuthored);

            entity.HasKey(b => b.Id);
            entity.HasIndex(b => b.Isbn).IsUnique();
        });
    }

    private void SetupAuthor(ModelBuilder modelBuilder)
    {
        // Should be handled with book setup
    }

    private void SetupAnnouncements(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Announcement>()
            .HasMany(x => x.LikedByProfiles)
            .WithMany(x => x.AnnouncementsLiked)
            .UsingEntity(j => j.ToTable("AnnouncementLikes"));
        // should be done automatically
    }
}