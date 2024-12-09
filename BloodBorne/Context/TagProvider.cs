using BloodBorne.Model;
using Microsoft.EntityFrameworkCore;

namespace BloodBorne.Context
{
    public class TagProvider
    {
        private readonly DatabaseContext _context;

        public TagProvider(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Tags>> GetAllTagsAsync()
        {
            return await _context.Tags.OrderBy(tag => tag.TagName).ToListAsync();
        }

        public Tags? GetTagById(int id)
        {
            return _context.Tags.Find(id);
        }

    }
}
