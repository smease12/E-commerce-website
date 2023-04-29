using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace E_commerce_website.Models
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Password { get; set; }
        public string Number { get; set; }
        public Boolean TermsAndCond { get; set; }
        public Boolean Notification { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set;}
    }
}
