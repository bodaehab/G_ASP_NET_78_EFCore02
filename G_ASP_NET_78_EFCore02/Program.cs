using G_ASP_NET_78_EFCore02.data;
using Microsoft.EntityFrameworkCore;

namespace G_ASP_NET_78_EFCore02
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

            using var context = new AppDBContext();

            context.Database.EnsureCreated();

            Console.WriteLine("EventHub Database Created Successfully!");

            Console.WriteLine(
                context.Database.GetDbConnection().Database);
        }
    }
}
