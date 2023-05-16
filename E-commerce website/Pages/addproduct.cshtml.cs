using E_commerce_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce_website.Pages
{
    public class addproductModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }
        public void OnGet()
        {
        }
    }
}
