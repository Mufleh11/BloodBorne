using Microsoft.AspNetCore.Identity;


namespace BloodBorne.Model
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public DateTime  dob { get; set; }

        public List <Comment> Comment { get; set; }

        public List <Report> Report { get; set; }

        public List <BossList> Bosslist {  get; set; }

    }
}
