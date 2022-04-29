using System.Collections.Generic;
using System.Linq;
using Goodreads.DataAccess;
using Goodreads.Entities;
using ListToTablePrinter;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Goodreads.Exercises;

public class Exercises
{
    protected GoodreadsContext context;

    [SetUp]
    public virtual void Setup()
    {
        context = new GoodreadsContext();
    }

    [Test]
    public void Test1()
    {
        // Notice all the null values because nothing has been included.

        IEnumerable<Book> books = context.Books.Where(b => b.PageCount < 100).ToList();
        TablePrinter.Print(books);
    }

    [Test]
    public void Test2()
    {
        // Notice the value for Genre column, which prints the name of the collection: HashSet, instead of the elements within. This is just what to ToString method of HashSet does.
        // The table printer does best, if the properties (of the objects to print) are simple types or strings.

        IEnumerable<Book> books = context.Books
            .Include(b => b.Binding)
            .Include(b => b.Genres)
            .Where(b => b.PageCount < 100).ToList();
        TablePrinter.Print(books);
    }

    [Test]
    public void Test3()
    {
        // In this case, I'm using Select(..) to take the data from Book and it's Author (.WrittenBy), and creating a new anonymous object.
        // This is sort of like when you in SQL select only some columns, instead of *

        var books = context.Books
            .Include(b => b.WrittenBy)
            .Where(b => b.PageCount < 100)
            .Select(b => new
            {
                b.Id,
                b.Title,
                b.PageCount,
                b.WrittenBy.FirstName
            })
            .ToList();

        TablePrinter.Print(books);
    }

    [Test]
    public virtual void Ex1()
    {
        // What is the first and last name of the author with id 23?
    }

    [Test]
    public virtual void Ex2()
    {
        // What book has the id 24358527?
    }

    [Test]
    public virtual void Ex3()
    {
        // How many profiles are there?
    }

    [Test]
    public virtual void Ex4()
    {
        // How many profiles have the first name 'Abram'?
    }

    [Test]
    public virtual void Ex5()
    {
        // Are there two authors with the same first name?
    }

    [Test]
    public virtual void Ex6()
    {
        // Create a list of book titles and their page count, order by the book with the highest page count first.
    }

    [Test]
    public virtual void Ex7()
    {
        //Create a list of book titles and their page count, order by the book with the highest page count first, but remove books without a page count.
    }

    [Test]
    public virtual void Ex8()
    {
        // Show the books published in 2017.
    }

    [Test]
    public virtual void Ex9()
    {
        // Who published 'Tricked (The Iron Druid Chronicles, #4)'
        // hit, you may not be able to get an exact match of the name above, so try .Contains method with part of the name
    }

    [Test]
    public virtual void Ex10()
    {
        // eh, I messed something up
    }

    [Test]
    public virtual void Ex11()
    {
        // What's the binding type of 'Fly by Night'?
    }

    [Test]
    public virtual void Ex12()
    { 
        // How many books do not have an ISBN number?
    }

    [Test]
    public virtual void Ex13()
    { // How many authors have a middle name?
    }

    [Test]
    public virtual void Ex14()
    { // Show an overview of author first name and last name and how many books they have written.
      // Order by highest count at the top.
    }

    [Test]
    public virtual void Ex15()
    { 
        // What is the title of the book with the highest page count?
    }

    [Test]
    public virtual void Ex16()
    { // What is the title of the book with the fifth highest page count?
    }

    [Test]
    public virtual void Ex17()
    { // How many books has the reader with the profile name 'Venom_Fate' read?
    }

    [Test]
    public virtual void Ex18()
    { // How many books are written by Brandon Sanderson?
    }

    [Test]
    public virtual void Ex19()
    { // How many readers have read the book 'Gullstruck Island'?
    }

    [Test]
    public virtual void Ex20()
    { //How many books have the author Ray Porter co-authored?
    }

    [Test]
    public virtual void Ex21()
    { // Who are the names of the author of the book which contains 'The Summer Dragon' in its title?
    }

    [Test]
    public virtual void Ex22()
    { // What type of binding does 'Dead Iron (Age of Steam,  #1)' have?
    }

    [Test]
    public virtual void Ex23()
    { // Show a list of each binding type and how many books are using that type.
    }

    [Test]
    public virtual void Ex24()
    { // For each profile, show how many books they have read.
    }

    [Test]
    public virtual void Ex25()
    { //Show all the genres of the book 'Hand of Mars (Starship's Mage, #2)'.
    }

    [Test]
    public virtual void Ex26()
    { //Show a list of both author and co-authors for the book with title 'Dark One'.
    }

    [Test]
    public virtual void Ex27()
    { //What is the title of the book which is read by most readers.
    }

    [Test]
    public virtual void Ex28()
    { //For the top-ten largest books (page count wise) show their title and binding type.
    }

    [Test]
    public virtual void Ex29()
    { //Show a count of how many books there are in each genre
    }

    [Test]
    public virtual void Ex30()
    { //Show a list of publisher names and how many books they each have published
    }

    [Test]
    public virtual void Ex31()
    { //Which book has the highest average rating?
    }

    [Test]
    public virtual void Ex32()
    { //How many books have reader 'radiophobia' read in 2018?
    }

    [Test]
    public virtual void Ex33()
    { //Show a list of how many books reader 'radiophobia' have read each year.
    }

    [Test]
    public virtual void Ex34()
    { //Show a top 10 of highest rated books.
    }

    [Test]
    public virtual void Ex35()
    { //What's the poorest rated book?
    }

    [Test]
    public virtual void Ex36()
    { //Is there any book, which hasn't been read?
    }

    [Test]
    public virtual void Ex37()
    { //Which reader has read the most books
    }

    [Test]
    public virtual void Ex38()
    { //Show how many pages each reader has read. Limit to top 10.
    }

    [Test]
    public virtual void Ex39()
    { //What's the lowest number of days to read 'Oathbringer (The Stormlight Archive, #3)', and who did that?
    }

    [Test]
    public virtual void Ex40()
    { // which Genre describes the most books?
    }

    [Test]
    public virtual void Ex41()
    { // What is each reader's most read genre?
    }

    [Test]
    public virtual void Ex42()
    { // What is the most popular type of binding?
    }

    [Test]
    public virtual void Ex43()
    { // Show how many books each author has written (exclude co-authors)
    }

    [Test]
    public virtual void Ex44()
    { // show how many pages each author has written (exclude co-authors)
    }

    [Test]
    public virtual void Ex45()
    { // Are there two authors with the same first name?
    }

    [Test]
    public virtual void Ex46()
    {
    }

    [Test]
    public virtual void Ex47()
    { // Show titles of all books written by Brandon Sanderson
    }

    [Test]
    public virtual void Ex48()
    {
    }

    [Test]
    public virtual void Ex49()
    {
    }

    [Test]
    public virtual void Ex50()
    {
    }
}