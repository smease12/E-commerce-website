using Microsoft.AspNetCore.Identity;

namespace E_commerce_website.Models
{
    public class ApplicationUser : IdentityUser  
    {
        public DateTime CreatedDate { get; set; }  
        public bool TermsAndCond { get; set; }
        public bool? Notification { get; set; }
        public DateTime? LastUpdatedDate { get; set; }

    }
}
