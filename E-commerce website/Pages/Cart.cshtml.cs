using E_commerce_website.Models;
using E_commerce_website.ViewModels;
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
        public List<CartProductVM> Products { get; set; }
        [BindProperty]
        public int ProductTypeCount { get; set; }
        [BindProperty]
        public int ProductCount { get; set; }
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
                            select new CartProductVM 
                            {
                                ProductId = p.id,
                                ProductName = p.name,
                                ProductImg = p.imgLocation1,
                                ProductSellPrice = decimal.Round((decimal)(p.sellPrice * u.Quantity), 2),
                                ProductQty = u.Quantity
                            }
                    );

                Products = await result.ToListAsync();
                ProductTypeCount = Products.Count();
                ProductCount = (int)Products.Sum(s => s.ProductQty);
                TotalPrice = Math.Round((decimal)(Products.Sum(s=> s.ProductSellPrice)), 2);
            }
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string returnUrl = Url.Content("~/Checkout");
            var postedValues = Products;
            Products = new List<CartProductVM>(postedValues);
            return LocalRedirect(returnUrl);

        }
    }
}
