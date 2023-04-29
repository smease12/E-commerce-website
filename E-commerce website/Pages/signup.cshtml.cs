using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_website.Pages
{
    public class signupModel : PageModel
    {
        [BindProperty]
        [StringLength(60, MinimumLength = 3, ErrorMessage ="Name must be 3 letters long and no more than 60")]
        [Required(ErrorMessage = "Enter your name")]
        public string Name { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Enter your name")]
        public string Email { get; set; }
        [BindProperty]
        [StringLength(60, MinimumLength = 8, ErrorMessage ="Password must be 8 letters long and no more than 60")]
        [Required(ErrorMessage = "Enter your password") ]
        public string Password { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Enter your phone number") ]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "Invalid number, please enter a valid one")]
        public string Number { get; set; }
        [BindProperty]
        [CheckBoxRequired(ErrorMessage = "You must agree to our terms and conditions")]
        public bool TermsAndCond {get; set;}
        [BindProperty]
        public bool Notification { get; set; }
        public void OnGet()
        {
        }
        public void OnPost(string Name, string Email, string Password, string Number, string TermsAndCond, string Notification) 
        {
            int foo = 0;
        }
    }
}
