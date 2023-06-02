using E_commerce_website.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace E_commerce_website.Pages
{
    public class CartModel : PageModel
    {
        [BindProperty]
        public List<Product> Products { get; set; }
        [BindProperty]
        public int Count { get; set; }
        [BindProperty]
        public decimal TotalPrice { get; set; }
        private readonly ECommerceDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartModel(ECommerceDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            ApplicationUser user = await  _userManager.GetUserAsync(User);

            if (user != null)
            {
                var result = (from p in _context.Products
                            join u in _context.UserCarts on p.id equals u.Product.id
                            where u.ApplicationUser == user
                            select p
                    );

                Products = await result.ToListAsync();
                Count = Products.Count();
                TotalPrice = (decimal)Products.Sum(s=> s.sellPrice);
            }
            
            return Page();
        }

        public void OnPost() 
        {
            var postedValues = Products;
            Products = new List<Product>(postedValues);
        }
    }
}
