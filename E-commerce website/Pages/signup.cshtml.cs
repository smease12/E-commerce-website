using E_commerce_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_website.Pages
{
    public class signupModel : PageModel
    {
        [BindProperty]
        public User User {get; set;}
        public void OnGet()
        {
        }
        public void OnPost() 
        {
            int foo = 0;
        }
    }
}
