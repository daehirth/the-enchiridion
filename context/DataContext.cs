using TheEnchiridion.models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace TheEnchiridion.context
{
    public class DataContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignUser> CampaignUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                IConfiguration config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables()
                    .Build();
                optionsBuilder
                    .UseNpgsql(config.GetSection("ConnectionStrings")["DbConnection"]);
            }
        }
    }
}
