using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_website.Pages
{
    public class signupModel : PageModel
    {
        [BindProperty]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [BindProperty]
        [Required]
        public string Email { get; set; }
        [BindProperty]
        [StringLength(60, MinimumLength = 8)]
        [Required]
        public string Password { get; set; }
        [BindProperty]
        [Required]
        [StringLength(60, MinimumLength = 10)]
        public string Number { get; set; }
        [BindProperty]
        [Required]
        public Boolean TermsAndCond {get; set;}
        [BindProperty]
        public Boolean Notification { get; set; }
        public void OnGet()
        {
        }
        public void OnPost(string Name, string Email, string Password, string Number, string TermsAndCond, string Notification) 
        {
            int foo = 0;
        }
    }
}
