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
        [BindProperty]
        public decimal Shipping { get; set; }
        [BindProperty]
        public decimal TotalBeforeTax { get; set; }
        [BindProperty]
        public decimal Tax { get; set; }
        [BindProperty]
        public decimal OrderTotal { get; set; }

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
                                  ProductSellPrice = p.sellPrice * u.Quantity,
                                  ProductQty = u.Quantity,
                                  DeliveryDate = (u.DateDelivery).Value.ToString("dddd, dd MMMM yyyy")                              }
                    ) ;

                Products = await result.ToListAsync();
                Count = Products.Count();

                TotalPrice = (decimal)Products.Sum(s => s.ProductSellPrice);
                TotalPrice = Math.Round(TotalPrice, 2);

                Shipping = TotalPrice * (decimal)0.2;
                Shipping = Math.Round(Shipping, 2);

                TotalBeforeTax = TotalPrice + Shipping;
                TotalBeforeTax = Math.Round(TotalBeforeTax, 2);

                Tax = TotalBeforeTax * (decimal)0.07;
                Tax = Math.Round(Tax, 2);

                OrderTotal = TotalBeforeTax + Tax;
                OrderTotal = Math.Round(OrderTotal, 2);
            }

            return Page();
        }
    }
}
