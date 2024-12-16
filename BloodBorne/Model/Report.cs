namespace BloodBorne.Model
{
    public class Report
    {
        public int Id { get; set; } 
        public string ReportDetails { get; set; }

        public Comment Comment { get; set; }

        public User User { get; set; }

    }

 
}

