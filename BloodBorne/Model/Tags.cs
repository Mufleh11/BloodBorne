using Microsoft.EntityFrameworkCore;

namespace BloodBorne.Model
{
    public class Tags
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
