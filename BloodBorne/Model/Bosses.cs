namespace BloodBorne.Model
{
    public class Bosses
    {
        public int Id { get; set; }

        public string Name { get; set; }    
        public string BossDescription { get; set; }
        public string BossInfo { get; set; }
        public string ImageUrl { get; set; }
        public List<Comment> Comment { get; set; }
        public List<BossList> BossList { get; set; }

    }
}
