using Microsoft.AspNetCore.Identity;


namespace BloodBorne.Model
{
    public class User : IdentityUser
    {     
        public int Age { get; set; }

        public List <Comment> Comments { get; set; }

        public List <Report> Report { get; set; }
    }



}
