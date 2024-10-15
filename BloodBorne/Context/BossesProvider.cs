using BloodBorne.Model;

namespace BloodBorne.Context
{
    public class BossesProvider
    {
        private readonly DatabaseContext _context;

        public BossesProvider(DatabaseContext context)
        {
            _context = context;
        }

        //public async Task<List<Bosses>> GetAllBossesAsync()
        //{
        //    return await _context.Bosses.OrderBy(bosses => bosses.Name).ToListAsync();
        //}

        public async Task AddBossesAsync(Bosses bosses)
        {
            _context.Bosses.Add(bosses);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCheeseAsync(Bosses bosses)
        {
            _context.Bosses.Update(bosses);
            await _context.SaveChangesAsync();
        }
    }
}
