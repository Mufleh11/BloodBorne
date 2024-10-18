using BloodBorne.Model;
using Microsoft.EntityFrameworkCore;


namespace BloodBorne.Context
{
    public class BossesProvider
    {
        private readonly DatabaseContext _context;

        public BossesProvider(DatabaseContext context)
        {
            _context = context;
        }


        public async Task<List<Bosses>> GetAllBossesAsync()
        {
            return await _context.Bosses.OrderBy(bosses => bosses.Name).ToListAsync();

        }


        public Bosses? GetBossesById(int id)
        {
            return _context.Bosses.Find(id);

        }

    }
}
