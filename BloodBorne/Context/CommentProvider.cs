using BloodBorne.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace BloodBorne.Context
{


    public class CommentProvider
    {

        // Represents the database context for interacting with the database
        private readonly DatabaseContext _context;

        // Constructor to inject the database context
        public CommentProvider(DatabaseContext context)
        {
            _context = context;
        }

      

        //get all the comments from the database
        public async Task<List<Comment>> GetCommentsAsync()
        {
            return await _context.Comment
                // Load related Tags
                .Include(c => c.Bosses)    // Load related Bosses
                .Include(c => c.User)      // Load User info
                .OrderByDescending(c => c.Id) // Order comments by their ID in descending order
                .ToListAsync();
        }

        //Add comment to database and save those changes
        public async Task AddCommentAsync(Comment comment)
        {
            await _context.Comment.AddAsync(comment);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCommentAsync(Comment comment)
        {
            //gets comments that were liking on
            var existingComment = await _context.Comment.FirstOrDefaultAsync(c => c.Id == comment.Id);
            if (existingComment != null)
            {
                // Update the fields so that they persist
                existingComment.Likes = comment.Likes;
                existingComment.Dislikes = comment.Dislikes;


                await _context.SaveChangesAsync();

            }
        }




        public List<string> GetTagNames()
        {
            return _context.Tags.Select(tag => tag.TagName).ToList(); // Returns a list of all tag names
        }
    }
}


//public async Task CreateComment(User user, string commentDetails, Tags tags, Bosses bosses, DateTime dateTime)
//{

//    var existingComment = await _context.Comment.FirstOrDefaultAsync(c => c.CommentDetails == commentDetails);

//    if (existingComment != null)
//    {
//        throw new Exception("A comment with these details already exists.");
//    }

//}




