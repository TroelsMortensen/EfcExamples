using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Goodreads.Entities;
using ListToTablePrinter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NUnit.Framework;

namespace Goodreads.Exercises.Solutions;

public class ExerciseSolutions : Exercises
{
    [SetUp]
    public override void Setup()
    {
        base.Setup();
    }

    [Test]
    public override void Ex1()
    {
        Author? author = context.Authors.Find(23);
        Print(author);
    }

    private void Print(Object obj)
    {
        Console.WriteLine(JsonSerializer.Serialize(obj, new JsonSerializerOptions
        {
            WriteIndented = true
        }));
    }

    private void Print<T>(IEnumerable<T> list)
    {
        TablePrinter.Print(list);
    }

    [Test]
    public override void Ex2()
    {
        Book? book = context.Books.Find(24358527);
        Print(book);
    }

    [Test]
    public override void Ex3()
    {
        int count = context.Profiles.Count();
        Print(count);
    }

    [Test]
    public override void Ex4()
    {
        var count = context.Profiles.Count(p => p.FirstName.Equals("Abram"));
        Print(count);
    }

    [Test]
    public override void Ex5()
    {
        
        var list = context.Authors // access authors
            .GroupBy(a => a.FirstName) // group by the first name
            .Select(g => new { FirstName = g.Key, Count = g.Count() }) // select first name and count(*)
            .Where(arg => arg.Count > 1) // having count(*) > 1
            .OrderByDescending(arg => arg.Count) // order by count(*) desc
            .ToList();
        TablePrinter.Print(list);
    }

    [Test]
    public override void Ex6()
    {
        var list = context.Books.Select(book => new
            {
                Title = book.Title,
                PageCount = book.PageCount
            })
            .OrderByDescending(arg => arg.PageCount)
            .ToList();
        Print(list);
    }

    [Test]
    public override void Ex7()
    {
        var list = context.Books
            .Where(b => b.PageCount.HasValue)
            .Select(book => new
            {
                Title = book.Title,
                PageCount = book.PageCount
            })
            .OrderByDescending(arg => arg.PageCount)
            .ToList();
        Print(list);
    }

    [Test]
    public override void Ex8()
    {
        var books = context.Books.Where(book => book.YearPublished == 2017).ToList();
        Print(books);
    }

    [Test]
    public override void Ex9()
    {
        var books = context.Books
            .Where(b => b.Title.Contains("Tricked"))
            .Include(b => b.WrittenBy)
            .Select(book => new
            {
                Title = book.Title,
                AuthorName = book.WrittenBy.FirstName + " " + book.WrittenBy.LastName
            })
            .ToList();
        Print(books);
    }

    [Test]
    public override void Ex10()
    {
        base.Ex10();
    }

    [Test]
    public override void Ex11()
    {
        var list = context.Books
            .Where(b => b.Title.Equals("Fly by Night"))
            .Include(b => b.Binding)
            .Select(b => new
            {
                Binding = b.Binding.Type
            })
            .ToList();
        Print(list);
    }

    [Test]
    public override void Ex12()
    {
        var count = context.Books.Count(b => b.Isbn == null);
        Print(count);
    }

    [Test]
    public override void Ex13()
    {
        var count = context.Authors.Count(a => a.MiddleNames != null);
        Print(count);
    }

    [Test]
    public override void Ex14()
    {
        var result = context.Authors
            .Include(a => a.BooksAuthored)
            .Select(a => new
            {
                Name = a.FirstName + " " + a.LastName,
                BookCount = a.BooksAuthored.Count
            })
            .OrderByDescending(arg => arg.BookCount)
            .ToList();

        Print(result);
    }

    [Test]
    public override void Ex15()
    {
        var result = context.Books.OrderByDescending(b => b.PageCount)
            .Select(book => new
            {
                Title = book.Title,
                Pages = book.PageCount
            })
            .Take(1)
            .ToList();
        Print(result);
    }

    [Test]
    public override void Ex16()
    {
        var result = context.Books.OrderByDescending(b => b.PageCount)
            .Select(book => new
            {
                Title = book.Title,
                Pages = book.PageCount
            })
            .Skip(4)
            .Take(1)
            .ToList();
        Print(result);
    }

    [Test]
    public override void Ex17()
    {
        var result = context.Profiles
            .Include(p => p.BooksRead)
            .First(p => p.ProfileName.Equals("Venom_Fate"))
            .BooksRead
            .Count;
        Print(result);
    }

    [Test]
    public override void Ex18()
    {
        var result = context.Authors
            .Include(a => a.BooksAuthored)
            .First(a => a.FirstName.Equals("Brandon") && a.LastName.Equals("Sanderson"))
            .BooksAuthored
            .Count;
        Print(result);
    }

    [Test]
    public override void Ex19()
    {
        base.Ex19();
    }

    [Test]
    public override void Ex20()
    {
        base.Ex20();
    }

    [Test]
    public override void Ex21()
    {
        base.Ex21();
    }

    [Test]
    public override void Ex22()
    {
        base.Ex22();
    }

    [Test]
    public override void Ex23()
    {
        base.Ex23();
    }

    [Test]
    public override void Ex24()
    {
        base.Ex24();
    }

    [Test]
    public override void Ex25()
    {
        base.Ex25();
    }

    [Test]
    public override void Ex26()
    {
        base.Ex26();
    }

    [Test]
    public override void Ex27()
    {
        base.Ex27();
    }

    [Test]
    public override void Ex28()
    {
        base.Ex28();
    }

    [Test]
    public override void Ex29()
    {
        base.Ex29();
    }

    [Test]
    public override void Ex30()
    {
        base.Ex30();
    }

    [Test]
    public override void Ex31()
    {
        base.Ex31();
    }

    [Test]
    public override void Ex32()
    {
        base.Ex32();
    }

    [Test]
    public override void Ex33()
    {
        base.Ex33();
    }

    [Test]
    public override void Ex34()
    {
        base.Ex34();
    }

    [Test]
    public override void Ex35()
    {
        base.Ex35();
    }

    [Test]
    public override void Ex36()
    {
        base.Ex36();
    }

    [Test]
    public override void Ex37()
    {
        base.Ex37();
    }

    [Test]
    public override void Ex38()
    {
        base.Ex38();
    }

    [Test]
    public override void Ex39()
    {
        base.Ex39();
    }

    [Test]
    public override void Ex40()
    {
        base.Ex40();
    }

    [Test]
    public override void Ex41()
    {
        base.Ex41();
    }

    [Test]
    public override void Ex42()
    {
        base.Ex42();
    }

    [Test]
    public override void Ex43()
    {
        base.Ex43();
    }

    [Test]
    public override void Ex44()
    {
        base.Ex44();
    }

    [Test]
    public override void Ex45()
    {
        base.Ex45();
    }
}