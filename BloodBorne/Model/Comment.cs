namespace BloodBorne.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentDetails { get; set; }
        public Tags Tags { get; set; }
        public Bosses Bosses { get; set; }
        public User User { get; set; }
        public List <Report> Report {  get; set; }
        public DateTime DateTime { get; set; }

    }
}
