namespace BloodBorne.Model
{
    public class Bosses
    {
        public int Id { get; set; }
        public string boss_description { get; set; }
        public string boss_info { get; set; }
        public Comment Comment { get; set; }
        public BossList BossList { get; set; }

    }
}
