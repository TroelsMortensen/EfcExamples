﻿using System.Net;
using System.Text;
using System.Text.Json;
using GoodreadsDataGeneration.DataCreation.Models;

namespace GoodreadsDataGeneration.DataCreation.CsvImport;

public class GenreImporter
{
    private static string path = @"C:\TRMO\RiderProjects\EfcExamples\Goodreads.DataGeneration\DataCreation\Source\BooksWithGenres.txt";

    /**
         * Reads genres from a file. Then for each book, the genres are attached.
         */
    public static void AddGenres(List<BookData> books, DataBaseModelContainer container)
    {
        Dictionary<string, int> genres = CollectAllGenres();


        using StreamReader reader = new(path);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            var strings = line.Split(",");
            BookData bookData = books.First(b => b.BookId.Equals(strings[0]));
            for (int i = 1; i < strings.Length; i++)
            {
                bookData.GenreIds.Add(genres[strings[i]]);
            }
        }

        AddGenreContainers(container, genres);
    }



    private static void AddGenreContainers(DataBaseModelContainer container, Dictionary<string, int> genres)
    {
        List<GenreData> list = new();
        foreach (string key in genres.Keys)
        {
            int genreId = genres[key];
            list.Add(new GenreData
            {
                Genre = key,
                Id = genreId
            });
        }

        container.Genres = list;
    }

    private static Dictionary<string, int> CollectAllGenres()
    {
        Dictionary<string, int> genres = new();
        using StreamReader reader = new StreamReader(path);
        string line;
        int idx = 0;
        while ((line = reader.ReadLine()) != null)
        {
            var strings = line.Split(",");
            for (int i = 1; i < strings.Length; i++)
            {
                if (!genres.ContainsKey(strings[i]))
                {
                    idx++;
                    genres.Add(strings[i], idx);
                }
            }
        }

        return genres;
    }


    // private void GetGenres(Book book)
    // {
    //     string id = book.BookId;
    //     
    //     HashSet<string> genres = GetFromGoodreads(id);
    //
    //     book.Genres = genres;
    //     int stopher = 0;
    // }

    private static HashSet<string> GetFromGoodreads(string id)
    {
        Console.WriteLine("Retrieving " + id);
        string urlAddress = "https://www.goodreads.com/book/show/" + id;

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        HashSet<string> genres = new();
        if (response.StatusCode == HttpStatusCode.OK)
        {
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = null;

            if (String.IsNullOrWhiteSpace(response.CharacterSet))
                readStream = new StreamReader(receiveStream);
            else
                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

            string data = readStream.ReadToEnd();
            foreach (string line in data.Split("\n"))
            {
                if (line.Contains("<a class=\"actionLinkLite bookPageGenreLink\" href=\"/genres/"))
                {
                    string genre = line.Replace("<a class=\"actionLinkLite bookPageGenreLink\" href=\"/genres/", "")
                        .Split("\"")[0].Trim();
                    genres.Add(genre);
                }
            }

            response.Close();
            readStream.Close();
        }

        return genres;
    }

    public void StoreBookIds(List<BookData> containerBooks)
    {
        using StreamWriter file = new StreamWriter(@"C:\TRMO\RiderProjects\DbsData\Goodreads.Data\Books.txt");
        foreach (BookData book in containerBooks)
        {
            file.WriteLine(book.BookId);
        }
    }

    public void FetchOneByOne()
    {
        throw new Exception("Update paths here");
        // first check which I have the data from
        HashSet<string> hasFetched = new();
        if (File.Exists(@"C:\TRMO\RiderProjects\DbsData\Goodreads.Data\BooksWithGenres.txt"))
        {
            using StreamReader readerHasCompleted = new StreamReader(@"C:\TRMO\RiderProjects\DbsData\Goodreads.Data\BooksWithGenres.txt");
            string line;
            while ((line = readerHasCompleted.ReadLine()) != null)
            {
                hasFetched.Add(line.Split(",")[0]);
            }
        }

        // now try to fetch more data
        using StreamReader readerAllBooks = new StreamReader(@"C:\TRMO\RiderProjects\DbsData\Goodreads.Data\Books.txt");
        using StreamWriter writer = new StreamWriter(@"C:\TRMO\RiderProjects\DbsData\Goodreads.Data\BooksWithGenres.txt", true);

        try
        {
            string line1;
            while ((line1 = readerAllBooks.ReadLine()) != null)
            {
                string id = line1;
                if (hasFetched.Contains(id))
                    continue;

                HashSet<string> genresFromGoodreads = GetFromGoodreads(id);
                string result = id;
                foreach (string g in genresFromGoodreads)
                {
                    result += "," + g;
                }

                writer.WriteLine(result);
                Thread.Sleep(3000);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}