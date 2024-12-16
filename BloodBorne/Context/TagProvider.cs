using BloodBorne.Model;
using Microsoft.EntityFrameworkCore;

namespace BloodBorne.Context
{
    public class TagProvider
    {
        // Represents the database context for interacting with the database
        private readonly DatabaseContext _context;

        // Constructor to inject the database context
        public TagProvider(DatabaseContext context)
        {
            _context = context;
        }

        // Asynchronously retrieves all tags from the database, ordered by tag name
        public async Task<List<Tags>> GetAllTagsAsync()
        {
            return await _context.Tags.OrderBy(tag => tag.TagName).ToListAsync();
        }

        // Retrieves a specific tag by its ID
        public async Task<Tags> GetTagByIdAsync(int tagId)
        {
            return _context.Tags.Find(tagId);
        }
    }
}
