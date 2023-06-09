using E_commerce_website.Models;
using E_commerce_website.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


//https://blog.christian-schou.dk/implement-stripe-payments-in-asp-net6/
namespace E_commerce_website.Pages
{
    public class CheckoutModel : PageModel
    {
        [BindProperty]
        public List<CartProductVM> Products { get; set; }
        [BindProperty]
        public int Count { get; set; }
        [BindProperty]
        public decimal TotalPrice { get; set; }
        private readonly ECommerceDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CheckoutModel(ECommerceDBContext context, UserManager<ApplicationUser> userManager) 
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);

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
                                  ProductSellPrice = p.sellPrice,
                                  ProductQty = u.Quantity
                              }
                    );

                Products = await result.ToListAsync();
                Count = Products.Count();
                TotalPrice = (decimal)Products.Sum(s => s.ProductSellPrice);
            }

            return Page();
        }
    }
}
