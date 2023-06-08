using Microsoft.AspNetCore.Identity;

namespace E_commerce_website.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime CreatedDate { get; set; }
        public bool TermsAndCond { get; set; }
        public bool? Notification { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string? AddressUnitNum { get; set; }
        public string? AddressStreet { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressState { get; set; }
        public int? AddressZipCode { get; set; }

    }
}
