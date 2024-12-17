using BloodBorne.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BloodBorne.Context
{
    public class DatabaseContext : IdentityDbContext<User>
    {

        private IWebHostEnvironment _environment;


        public DbSet<Comment> Comment { get; set; }
        public DbSet<BossList> BossLists { get; set; }

        public DbSet<Tags> Tags { get; set; }
        public DbSet<Bosses> Bosses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Report> Reports { get; set; }



        public DatabaseContext(DbContextOptions<DatabaseContext> options, IWebHostEnvironment environment) : base(options)
        {
            _environment = environment;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            var folder = Path.Combine(_environment.WebRootPath, "database");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            optionbuilder.UseSqlite($"Data Source={folder}/bloodborne.db");
        }
    }
}
