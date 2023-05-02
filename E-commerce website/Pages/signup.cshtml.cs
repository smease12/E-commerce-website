using E_commerce_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_website.Pages
{
    public class signupModel : PageModel
    {
        private readonly ECommerceDBContext _context;
        [BindProperty]
        public User User { get; set; }

        public signupModel(ECommerceDBContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            var emptyUser = new User();

            if (await TryUpdateModelAsync<User>(
                emptyUser,
                "user",   // Prefix for form value.
                 u => u.Name, u => u.Email, u => u.Password, u => u.Number, u => u.TermsAndCond, 
                 u => u.Notification))
            {
                emptyUser.CreatedDate = DateTime.UtcNow;    
                emptyUser.LastUpdatedDate = DateTime.UtcNow;    
                _context.Users.Add(emptyUser);
                await _context.SaveChangesAsync();
                return RedirectToPage("/");
            }

            return Page();
        }
    }
}
