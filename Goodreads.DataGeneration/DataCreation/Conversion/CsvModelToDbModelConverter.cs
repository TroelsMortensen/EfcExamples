using GoodreadsDataGeneration.DataCreation.Generators;
using GoodreadsDataGeneration.DataCreation.Models;

namespace GoodreadsDataGeneration.DataCreation.Conversion;

public class CsvModelToDbModelConverter
{

    private static Random rand = new();
    public static DataBaseModelContainer ConvertFromCsvModelToDbModel(List<GoodreadsItem> items)
    {
        DataBaseModelContainer container = new();
        HashSet<string> bindings = new();
        HashSet<string> publishers = new();
        foreach (GoodreadsItem item in items)
        {
            if (!String.IsNullOrEmpty(item.Binding))
                bindings.Add(item.Binding.Trim());

            string itemPubName = item.PubName;
            if (!String.IsNullOrEmpty(itemPubName))
                publishers.Add(itemPubName.Trim());
        }

        Console.WriteLine("Done collecting bindings, publishers");
        container.Bindings = GetContainerBindings(bindings);
        Console.WriteLine("Bindings added");
        
        container.Publishers = ContainerPublishers(publishers);
        Console.WriteLine("Publishers added");
        List<AuthorData> authors = ConvertAuthors(items);
        AddCoAuthors(authors, items);
        container.Authors = authors;
        Console.WriteLine("Authors added");
        Console.WriteLine("Converting books..");
        container.Books = ConvertBooks(items, authors, container);
        Console.WriteLine("Books converted");

        return container;
    }

    private static List<PublisherData> ContainerPublishers(HashSet<string> publishers)
    {
        int id = 0;
        List<PublisherData> list = new();
        foreach (string publisher in publishers)
        {
            id++;
            list.Add(new PublisherData
            {
                Id = id,
                Name = publisher
            });
        }

        return list;
    }

    private static List<BindingData> GetContainerBindings(HashSet<string> bindings)
    {
        List<BindingData> list = new();
        int id = 0;
        foreach (string binding in bindings)
        {
            id++;
            list.Add(new BindingData
            {
                Id = id,
                Type = binding
            });
        }

        return list;
    }


    private static List<BookData> ConvertBooks(List<GoodreadsItem> items, List<AuthorData> authors, DataBaseModelContainer container)
    {
        List<BookData> books = new();
        foreach (GoodreadsItem item in items)
        {
            int? bindingId = container.Bindings.FirstOrDefault(b => b.Type.Equals(item.Binding))?.Id;
            int? publisherId = container.Publishers.FirstOrDefault(p => p.Name.Equals(item.PubName))?.Id;
            BookData b = new BookData
            {
                Title = item.Title, //.Replace("'","''"),
                // AvgRating = item.AvgRating,
                BookId = item.BookId,
                // DateRead = item.DateRead,
                // MyRating = item.MyRating == 0 ? null : item.MyRating,
                PageCount = item.PageCount,
                YearPublished = item.YearPublished,
                ISBN = "".Equals(item.ISBN) ? null : item.ISBN,
                BindingId = bindingId,
                PublisherId = publisherId, //.Replace("'","''"),
                
                // AuthorFN = first.Replace("'","''"),
                // AuthorLN = last.Replace("'","''")
            };

            string first = item.AuthorName.Trim().Split(' ')[0].Trim();
            string last = item.AuthorName.Trim().Split(' ')[^1].Trim();
            AuthorData? find = authors.Find(author => author.FirstName.Equals(first) && author.LastName.Equals(last));
            if (find == null)
            {
                int stopher = 0;
            }

            b.AuthorID = find.Id;

            b.CoAuthors = FindCoAuthors(authors, b, item);
            books.Add(b);
        }

        return books;
    }

    private static List<int> FindCoAuthors(List<AuthorData> authors, BookData bookData, GoodreadsItem goodreadsItem)
    {
        List<int> ids = new();
        foreach (string authorName in goodreadsItem.CoAuthorNames)
        {
            string first = authorName.Trim().Split(' ')[0].Trim();
            string last = authorName.Trim().Split(' ')[^1].Trim();
            AuthorData? find = authors.Find(author => author.FirstName.Equals(first) && author.LastName.Equals(last));
            if (find == null)
            {
                int stopher = 0;
            }

            ids.Add(find.Id);
        }

        return ids;
    }

    private static void AddCoAuthors(List<AuthorData> authors, List<GoodreadsItem> items)
    {
        foreach (GoodreadsItem item in items)
        {
            foreach (string name in item.CoAuthorNames)
            {
                if (String.IsNullOrEmpty(name))
                    continue;
                AddSingleAuthor(name.Trim().Split(' '), authors);
            }
        }
    }

    private static List<AuthorData> ConvertAuthors(List<GoodreadsItem> items)
    {
        List<AuthorData> authors = new();
        foreach (GoodreadsItem item in items)
        {
            var strings = item.AuthorName.Split(" ");
            AddSingleAuthor(strings, authors);
        }

        return authors;
    }

    private static void AddSingleAuthor(string[] strings, List<AuthorData> authors)
    {
        AuthorData authorData = new();
        authorData.FirstName = strings[0]; //.Replace("'", "''");
        authorData.LastName = strings[^1]; //.Replace("'", "''");
        if (strings.Length > 2)
        {
            string middleName = "";
            for (int i = 1; i < strings.Length - 1; i++)
            {
                middleName += strings[i];
            }

            if (!String.IsNullOrEmpty(middleName))
            {
                authorData.MiddelNames = middleName;
            }
        }

        if (authors.Any(a => a.FirstName.Equals(strings[0]) && a.LastName.Equals(strings[^1])))
        {
            return;
        }
        
        authorData.Id = authors.Count+1;
        authorData.About = RandomStringGenerator.GetRandomString(25, true);
        authorData.Email = authorData.FirstName + "." + authorData.LastName + "@" + emailDomains[rand.Next(0, emailDomains.Length)];
        authorData.Website = rand.Next(0, 2) == 0 ? null : "www." + authorData.FirstName + authorData.LastName + ".com";
                
        authors.Add(authorData);
    }


    private static string[] emailDomains =
    {
        "hotmail.com",
        "yahoo.com",
        "google.com",
        "live.com",
        "outlook.com"
    };
}