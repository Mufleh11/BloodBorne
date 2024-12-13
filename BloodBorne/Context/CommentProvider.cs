﻿using BloodBorne.Model;
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


      
        public List<string> GetTagNames()
        {
            return _context.Tags.Select(tag => tag.TagName).ToList(); // Returns a list of all tag names
        }

        public async Task<List<Comment>> GetCommentsAsync()
        {
            return await _context.Comment
                     // Load related Tags
                .Include(c => c.Bosses)    // Load related Bosses
                .Include(c => c.User)      // Load User info
                .OrderByDescending(c => c.DateTime)
                .ToListAsync();
        }

        public async Task AddCommentAsync(Comment comment)
        {
            comment.DateTime = DateTime.Now;
            _context.Comment.Add(comment);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCommentAsync(Comment comment)
        {
           
            _context.Comment.Add(comment);
            await _context.SaveChangesAsync();
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




