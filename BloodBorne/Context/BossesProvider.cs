using BloodBorne.Model;
using Microsoft.EntityFrameworkCore;


namespace BloodBorne.Context
{
    //This class provides access to "Bosses" data in the database.
    public class BossesProvider
    {
        //A link to the database.
        private readonly DatabaseContext _context;

        //Constructor: sets up the database link.
        public BossesProvider(DatabaseContext context)
        {
            _context = context;
        }

        //Gets a list of all bosses, sorted by name.
        public async Task<List<Bosses>> GetAllBossesAsync()
        {
            return await _context.Bosses.OrderBy(bosses => bosses.Name).ToListAsync();

        }

        //Finds a boss by ID. Returns null if not found.
        public Bosses? GetBossesById(int id)
        {
            return _context.Bosses.Find(id);

        }

    }
}
