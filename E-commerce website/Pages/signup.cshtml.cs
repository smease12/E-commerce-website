#nullable disable

using E_commerce_website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;

namespace E_commerce_website.Pages
{
    public class signupModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<signupModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ECommerceDBContext _context;

        public signupModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<signupModel> logger,
            IEmailSender emailSender,
            ECommerceDBContext context)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(60, MinimumLength = 3, ErrorMessage = "Name must be 3 letters long and no more than 60")]
            [Display(Name = "Name")]
            public string Username { get; set; }
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            //[Required]
            //[EmailAddress]
            //[Display(Name = "Email")]
            //public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
           // [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
           // [DataType(DataType.PhoneNumber)]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }
           // [CheckBoxRequired(ErrorMessage = "You must agree to our terms and conditions")]
            public bool TermsAndCond { get; set; }
            public bool Notification { get; set;}
            
        }

        [PageRemote(
            ErrorMessage = "Email Address already exists",
            AdditionalFields = "__RequestVerificationToken",
            HttpMethod = "post",
            PageHandler = "CheckEmail"
        )]
        [BindProperty]
        public string Email { get; set; }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            //   if (ModelState.IsValid)
            //    {
            //   var user = CreateUser();
            var user = new ApplicationUser { UserName = Input.Username,
                PhoneNumber = Input.PhoneNumber,
            CreatedDate = DateTime.Now,
           LastUpdatedDate = DateTime.Now,
            Notification = Input.Notification,
            TermsAndCond = Input.TermsAndCond};
                await _userStore.SetUserNameAsync(user, Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
          //  }

            // If we got this far, something failed, redisplay form
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

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
