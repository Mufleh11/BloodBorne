using BloodBorne.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

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
                new Bosses {Name="Father Gascoigne", BossDescription="A mind turned father made beast, weilding an axe and claws", BossInfo="jkgu", ImageUrl="cleric.jpg" },
                new Bosses {Name="Witch Of Hemwick", BossDescription="", BossInfo="" },
                new Bosses {Name="", BossDescription="A monstrous creature that lurks in the shadows of Yharnam", BossInfo="scary guy", ImageUrl="bloodborne_beast.jpg" },
                new Bosses {Name="Witch of Hemwick", BossDescription="A powerful witch who guards her coven in Hemwick", BossInfo="evil witch", ImageUrl="witch_of_hemwick.jpg" },
                new Bosses {Name="Rom the Vacuous Spider", BossDescription="A giant spider-like creature that dwells in the Nightmare", BossInfo="big spider", ImageUrl="rom_the_vacuous_spider.jpg" },
                new Bosses {Name="Vicar Amelia", BossDescription="A nun who has been corrupted by the Beast", BossInfo="crazy nun", ImageUrl="amelia_the_nun.jpg" },
                new Bosses {Name="Ebrietas", BossDescription="A cosmic entity that has descended to Yharnam", BossInfo="space monster", ImageUrl="ebrietas_daughter_of_the_cosmos.jpg" },
                new Bosses {Name="Shadows of Yharnam", BossDescription="A group of hunters who have been corrupted by the Beast", BossInfo="multiple enemies", ImageUrl="shadows_of_yharnam.jpg" },
                new Bosses {Name="The One Reborn", BossDescription = "A powerful entity that has been corrupted by the Beast", BossInfo = "final boss", ImageUrl = "great_one_reborn.jpg" },
                new Bosses {Name="Amygdala", BossDescription="A giant, monstrous creature that dwells in the Nightmare", BossInfo="nightmare guardian", ImageUrl="amygdala.jpg" },
                new Bosses {Name="Micolash, Host of the Nightmare", BossDescription="A madman who controls the Nightmare", BossInfo="nightmare host", ImageUrl="micolash.jpg" },
                new Bosses { Name="Mergo's Wet Nurse", BossDescription="A monstrous creature that protects Mergo", BossInfo="boss guardian", ImageUrl="mergos_wet_nurse.jpg" },
                new Bosses {Name="Gehrman, the First Hunter", BossDescription="A former hunter who has become the guardian of the Nightmare", BossInfo="first hunter", ImageUrl="gehrman_the_first_hunter.jpg" },
                new Bosses { Name="Moon Presence", BossDescription="The ultimate source of the Beast", BossInfo="final boss", ImageUrl="moon_presence.jpg" }
                ];

        }



    }

  
}