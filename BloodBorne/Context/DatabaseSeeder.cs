using BloodBorne.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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


           //This code is to make the admin user and to make sure the admin users details are correct

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
                new Bosses {Name="Cleric Beast", BossDescription="A wild hairy beast that can deal damage to you and break your back", BossInfo="The majority of the Cleric Beast's attacks consist of swipes with its larger, left arm at close range and jump attacks at a distance. It possesses few attacks that hit behind itself and, therefore, it is wise to stay behind it for the majority of the time. Location: Central Yharnam Strategy:\r\nAttack Patterns: The Cleric Beast is a large, slow-moving creature with powerful swipes and a few area-of-effect (AoE) attacks.\r\n                Weaknesses: It is weak to fire and bolt damage. Use fire paper or a firearm with bolt paper to deal extra damage.\r\nTips: Focus on dodging its wide sweeps. Once it roars, it is vulnerable to attack. Keep your distance when it starts charging, but be ready to dodge.",   ImageUrl="cleric.jpg"},
                new Bosses {Name="Father Gascoigne", BossDescription="A mind turned father made beast, weilding an axe and claws", BossInfo="The fight has three phases. In the beginning, Father Gascoigne fights with a normal Hunter Axe and his unique Hunter Blunderbuss. At roughly 75-80% health remaining, Father Gascoigne attacks you with a transformed Hunter Axe and his unique Hunter Blunderbuss, introducing charged and longer-reaching attacks.", ImageUrl="gascoigne.png" },   
                new Bosses {Name="Witch of Hemwick", BossDescription="A powerful witch who guards her coven in Hemwick", BossInfo="evil witch", ImageUrl="hemwick.png" },
                new Bosses {Name="Vicar Amelia", BossDescription="A nun who has been corrupted by the Beast", BossInfo="crazy nun", ImageUrl="vicar.png" },
                new Bosses {Name="Rom the Vacuous Spider", BossDescription="A giant spider-like creature that dwells in the Nightmare", BossInfo="big spider", ImageUrl="rom.png" },
                new Bosses {Name="Amygdala", BossDescription="A giant, monstrous creature that dwells in the Nightmare", BossInfo="nightmare guardian", ImageUrl="amygdala.png" },
                new Bosses {Name="Shadows of Yharnam", BossDescription="A group of hunters who have been corrupted by the Beast", BossInfo="multiple enemies", ImageUrl="shadow.png" },
                new Bosses {Name="The One Reborn", BossDescription = "A powerful entity that has been corrupted by the Beast", BossInfo = "final boss", ImageUrl = "reborn.png" },
                new Bosses {Name="Micolash, Host of the Nightmare", BossDescription="A madman who controls the Nightmare", BossInfo="nightmare host", ImageUrl="micolash.png" },
                new Bosses {Name="Mergo's Wet Nurse", BossDescription="A monstrous creature that protects Mergo", BossInfo="boss guardian", ImageUrl="mergos.png" },
                new Bosses {Name="Gehrman, the First Hunter", BossDescription="A former hunter who has become the guardian of the Nightmare", BossInfo="first hunter", ImageUrl="gher.png" },
                new Bosses {Name="Moon Presence", BossDescription="The ultimate source of the Beast", BossInfo="final boss", ImageUrl="moon.png" }
                ];

        }
        private List<Tags> GetTags()
        {
            return
                [
                 new Tags {tagName="Bossfight" },
                 new Tags {tagName = "Help" },
                 new Tags {tagName = "Discussion" },
                 new Tags {tagName = "Opinion" },
                 new Tags {tagName = "Humor" },
                 new Tags { tagName = "Other" }
                ];
        }


    }

  
}