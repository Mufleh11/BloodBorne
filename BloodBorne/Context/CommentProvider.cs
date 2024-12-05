using BloodBorne.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading;

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





        public async Task CreateComment(User user, string commentDetails)
        {
  
            var existingcomment = await _context.Comment.FirstOrDefaultAsync(c => c.CommentDetails == commentDetails);

            if (existingcomment == null || commentDetails == null)
            {
                throw new Exception("Invalid barber or service selected.");
            }


            var comment = new Comment
            { 

              CommentDetails = commentDetails,
               User = user,
             };

       
        _context.Comment.Add(comment);
         await _context.SaveChangesAsync();
    }


}

}
    





