namespace BloodBorne.Model
{
    public class Report
    {
        public int Id { get; set; } 
        public string report_details { get; set; }

        public Comment Comment { get; set; }

        public User User { get; set; }

    }
}
