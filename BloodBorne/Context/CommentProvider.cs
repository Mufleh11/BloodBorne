using BloodBorne.Model;
using Microsoft.EntityFrameworkCore;

namespace BloodBorne.Context
{
   
    
        public class CommentProvider
        {

            private readonly DatabaseContext _context;

            public CommentProvider(DatabaseContext context)
            {
                _context = context;
            }

            public async Task<List<Comment>> GetAllCommentsAsync()
            {
                return await _context.Comment.ToListAsync();

            }

            public Comment? GetCommentsById(int id)
            {
                return _context.Comment.Find(id);

            }

        }
    }





