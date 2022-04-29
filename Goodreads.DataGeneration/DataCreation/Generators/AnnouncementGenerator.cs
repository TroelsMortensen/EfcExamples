using System;
using System.Collections.Generic;
using System.Linq;
using GoodreadsDataGeneration.DataCreation.Models;

namespace GoodreadsDataGeneration.DataCreation.Generators;

public static class AnnouncementGenerator
{
    private static Random rand = new();
    private static int id = 0;
    private static List<ProfileData> users;
    public static void AddAnnouncements(DataBaseModelContainer container)
    {
        container.AnnouncementLikes = new List<AnnouncementLikeData>();
        Console.WriteLine("Generating author announcements");
        users = container.Users;
        container.Announcements = new();
        foreach (AuthorData author in container.Authors)
        {
            List<AnnouncementData> announcements = GenerateAnnouncementForAuthor(container, author.Id);
            Console.WriteLine("\tAnnouncements generated for " + author.FirstName + ". " + author.Id + "/" + container.Authors.Count);
            container.Announcements.AddRange(announcements);
        }

        Console.WriteLine("Done");
    }

    private static List<AnnouncementData> GenerateAnnouncementForAuthor(DataBaseModelContainer container, int authorId)
    {
        
        List<AnnouncementData> list = new();
        int count = rand.Next(0, 25);
        for (int i = 0; i < count; i++)
        {
            AnnouncementData announcementData = GenerateOneAnnouncement(container, authorId);
            list.Add(announcementData);
        }

        return list;
    }

    private static AnnouncementData GenerateOneAnnouncement(DataBaseModelContainer container, int authorId)
    {
        string title = RandomStringGenerator.GetRandomString(25);
        string body = RandomStringGenerator.GetRandomString(25, true);
        
        DateTime startDate = new DateTime(2010, 1, 1);
        DateTime endDate = DateTime.Now;
        TimeSpan timeSpan = endDate - startDate;
        TimeSpan newSpan = new TimeSpan(0, rand.Next(0, (int)timeSpan.TotalMinutes), 0);
        DateTime newDate = startDate + newSpan;
        
        AnnouncementData a = new()
        {
            Content = body,
            Title = title,
            AuthorId = authorId,
            Id = (++id),
            TimeStamp = newDate
        };
        
        AddLikes(container, a);
        
        return a;
    }

    private static void AddLikes(DataBaseModelContainer container, AnnouncementData announcementData)
    {
        Shuffle();
        
        var next = rand.Next(0, users.Count / 5);
        for (int i = 0; i < next; i++)
        {
            AnnouncementLikeData al = new()
            {
                AnnouncementId = announcementData.Id,
                ProfileName = container.Users[i].ProfileName
            };
            if(!container.AnnouncementLikes.Any(
                   x => x.AnnouncementId == al.AnnouncementId && 
                        x.ProfileName.Equals(al.ProfileName))
               )
                container.AnnouncementLikes.Add(al);
        }
    }

    public static void Shuffle()  
    {  
        int n = users.Count;  
        while (n > 1) {  
            n--;  
            int k = rand.Next(n + 1);  
            ProfileData value = users[k];  
            users[k] = users[n];  
            users[n] = value;  
        }  
    }
}