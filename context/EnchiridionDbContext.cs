using TheEnchiridion.models;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TheEnchiridion.context
{
    public class EnchiridionDbContext : IdentityDbContext<User>
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignUser> CampaignUsers { get; set; }
        public DbSet<CampaignCharacter> CampaignCharacters { get; set; }

        public EnchiridionDbContext(DbContextOptions<EnchiridionDbContext> options) : base(options) 
        {

        }
    }
}
