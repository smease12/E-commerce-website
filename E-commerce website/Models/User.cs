using E_commerce_website.Pages;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace E_commerce_website.Models
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Name must be 3 letters long and no more than 60")]
        [Required(ErrorMessage = "Enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter your name")]
        public string Email { get; set; }
        [StringLength(60, MinimumLength = 8, ErrorMessage = "Password must be 8 letters long and no more than 60")]
        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Enter your phone number")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "Invalid number, please enter a valid one")]
        public string Number { get; set; }
        [CheckBoxRequired(ErrorMessage = "You must agree to our terms and conditions")]
        public bool TermsAndCond { get; set; }
        public bool Notification { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set;}
    }
}
