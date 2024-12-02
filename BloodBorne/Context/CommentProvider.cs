using BloodBorne.Model;
using Microsoft.EntityFrameworkCore;

namespace BloodBorne.Context
{
   
    
        public class CommentProvider
        {
            //A link to the database.
            private readonly DatabaseContext _context;

            //Constructor: sets up the database link.
            public CommentProvider(DatabaseContext context)
            {
                _context = context;
            }

            //Gets a list of all bosses, sorted by name.
            public async Task<List<Comment>> GetAllCommentsAsync()
            {
                return await _context.Comment.ToListAsync();

            }

            //Finds a boss by ID. Returns null if not found.
            public Comment? GetCommentsById(int id)
            {
                return _context.Comment.Find(id);

            }

        }
    }





