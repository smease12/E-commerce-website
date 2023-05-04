using E_commerce_website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_website.Pages
{
    public class signupModel : PageModel
    {
        private readonly ECommerceDBContext _context;
        [BindProperty]
        public User User { get; set; }

        [PageRemote(
            ErrorMessage = "Email Address already exists",
           // AdditionalFields = "__RequestVerificationToken",
            HttpMethod = "post",
            PageHandler = "CheckEmail"
        )]
        [BindProperty]
        public string Email { get; set; }

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
                "user",   // Prefix for form value. u => Email,
                 u => u.Name, u => u.Password, u => u.Number, u => u.TermsAndCond,
                 u => u.Notification))
            {
                emptyUser.CreatedDate = DateTime.UtcNow;
                emptyUser.LastUpdatedDate = DateTime.UtcNow;
                _context.Users.Add(emptyUser);
                await _context.SaveChangesAsync();
                return Redirect("~/");
            }

            return Page();
        }

        // https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-7.
        // https://www.learnrazorpages.com/razor-pages/validation/remote-validation
        public JsonResult OnPostCheckEmail(string Email)
        {
            if (_context.Users.ToList().Exists(p => p.Email.Equals
            (Email, StringComparison.CurrentCultureIgnoreCase)))
            {
                //  return new JsonResult($"Email {Email} is already in use.");
                return new JsonResult(false);
            }
            return new JsonResult(true);
        }
    }
}
