using BloodBorne.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BloodBorne.Context
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Tags> Tags { get; set; }
        public DbSet<Bosses> Bosses { get; set; }
        public DbSet<Report> Reports { get; set; }
        


        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            var dbPath = Path.Join(path, "database.db");
            optionbuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
