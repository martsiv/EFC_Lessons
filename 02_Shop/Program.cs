using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace _02_Shop
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("MyDbConnection");

            var optionBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionBuilder.UseSqlServer(connectionString).Options;
            using (ApplicationContext db = new ApplicationContext(options))
            {
            
            }
        }
    }
}