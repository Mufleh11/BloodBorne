using BloodBorne.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BloodBorne.Context
{
    public class DatabaseSeeder
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(DatabaseContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            await _context.Database.MigrateAsync();
            if (!_context.Bosses.Any())
            {
                var bosses = GetBosses();
               _context.Bosses.AddRange(bosses);
               await _context!.SaveChangesAsync();
           }


           

            if (!_context.Users.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("User"));

                var adminEmail = "admin@bb.com";
                var adminPassword = "Blood123!";

                var admin = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    Age=18

                };

                await _userManager.CreateAsync(admin, adminPassword);
                await _userManager.AddToRoleAsync(admin, "Admin");


            }

        }
        private List<Bosses> GetBosses()
        {
            return
                [
                new Bosses {Name="Cleric Beast", BossDescription="A wild hairy beast that can deal damage to you and break your back", BossInfo="super cool guy",  ImageUrl="cleric.jpg"},
                new Bosses {Name="Father Gascoigne", BossDescription="A mind turned father made beast, weilding an axe and claws", BossInfo="jkgu", ImageUrl="cleric.jpg" }
                ];

        }



    }

  
}