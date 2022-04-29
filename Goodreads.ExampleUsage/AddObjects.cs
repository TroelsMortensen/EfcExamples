using Goodreads.DataAccess;
using Goodreads.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GoodreadsExampleUsage;

public class AddObjects
{
    public async Task Run()
    {
        // _ = await AddGenreFantasy();
        // await AddGenreRange();
        // await AddAuthorAsync();
        // await UpdateAuthorAsync();
        // await DeleteBrandonAsync();
        // await AddBook();
        // await AddBookToExistingAsync();
        await GroupBy();
    }

    private async Task GroupBy()
    {
        await using GoodreadsContext context = new();
        
        
        
    }

    private async Task AddBookToExistingAsync()
    {
        await using GoodreadsContext context = new();
        
        Author? brandon = await context.Authors.FindAsync(1);
        
        Book? book = await context.Books.FindAsync(54615879);
        
        brandon!.BooksAuthored.Add(book!);

        book!.WrittenBy = brandon;
        
        await context.SaveChangesAsync();
    }

    private async Task AddBook()
    {
        Book b = new()
        {
            Id = 54615879,
            Title = "The Original",
            Binding = new BookBinding{ Type = "Audible Audio"}
        };
        await using GoodreadsContext context = new();
        await context.Books.AddAsync(b);
        await context.SaveChangesAsync();
    }

    private async Task DeleteBrandonAsync()
    {
        await using GoodreadsContext context = new();
        
        Author? brandon = await context.Authors.FindAsync(1);
        
        if (brandon == null) return;
        
        context.Authors.Remove(brandon);
        
        await context.SaveChangesAsync();
    }

    private async Task UpdateAuthorAsync()
    {
        await using GoodreadsContext context = new();
        Author? author = await context.Authors.FindAsync(1);
        author!.Email = "b.s@cosmere.com";
        await context.SaveChangesAsync();
    }

    private async Task OtherUpdate(Author author)
    {
        await using GoodreadsContext context = new();
        context.Authors.Update(author);
    }

    private async Task AddAuthorAsync()
    {
        Author brandon = new()
        {
            FirstName = "Brandon",
            LastName = "Sanderson",
            Email = "brandon.sanderson@gmail.com",
            Website = "www.brandonsanderson.com/",
        };
        await using GoodreadsContext context = new();
        await context.Authors.AddAsync(brandon);
        await context.SaveChangesAsync();
    }

    private async Task<Genre> AddGenreFantasy()
    {
        await using GoodreadsContext context = new GoodreadsContext();

        Genre fantasy = new()
        {
            GenreName = "Fantasy"
        };

        EntityEntry<Genre> entityAdded = await context.Genres.AddAsync(fantasy);
        await context.SaveChangesAsync();
        return entityAdded.Entity;
    }

    private async Task AddGenreRange()
    {
        await using GoodreadsContext context = new GoodreadsContext();
        Genre scifi = new()
        {
            GenreName = "Scifi"
        };
        Genre romance = new()
        {
            GenreName = "Romance"
        };

        List<Genre> genres = new() { scifi, romance };
        await context.Genres.AddRangeAsync(genres);
        await context.SaveChangesAsync();
    }
}