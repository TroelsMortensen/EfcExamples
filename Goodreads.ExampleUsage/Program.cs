// See https://aka.ms/new-console-template for more information

using System.Threading.Tasks;
using GoodreadsExampleUsage;

public class Program
{
    static async Task Main(string[] args)
    {
        await new AddObjects().Run();
    }
}