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
        public int ProductTypeCount { get; set; }
        [BindProperty]
        public int ProductCount { get; set; }
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
        [BindProperty]
        public string Country { get; set; }
        [BindProperty]
        public string FullName { get; set; }
        [BindProperty]
        public string PhoneNumber { get; set; }
        [BindProperty]
        public string Address1 { get; set; }
        [BindProperty]
        public string Address2 { get; set; }
        [BindProperty]
        public string City { get; set; }
        [BindProperty]
        public string State { get; set; }
        [BindProperty]
        public int ZipCode { get; set; }

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
                                  OrderSellPrice = decimal.Round((decimal)(p.sellPrice * u.Quantity), 2),
                                  ProductQty = u.Quantity,
                                  DeliveryDate = (u.DateDelivery).Value.ToString("dddd, dd MMMM yyyy"),
                                  UserCartId = u.Id
                              }
                    );

                UserCart userCart = _context.UserCarts.FirstOrDefault(u => u.ApplicationUser == user);
                if (userCart != null)
                {
                    Country = userCart.Country;
                    FullName = userCart.FullName;
                    PhoneNumber = userCart.PhoneNumber;
                    Address1 = userCart.Address1;
                    Address2 = userCart.Address2;
                    City = userCart.City;
                    State = userCart.State;
                    ZipCode = (int)userCart.ZipCode; 
                }
            
                Products = await result.ToListAsync();
                ProductTypeCount = Products.Count();
                ProductCount = (int)Products.Sum(s => s.ProductQty);

                TotalPrice = (decimal)Products.Sum(s => s.OrderSellPrice);
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

        public IActionResult OnPostCheckoutForm() 
        {
            int foo = 0;
            return Page();
        }

        public IActionResult OnPostAddressForm()
        {
            int foo = 0;
            return Page();
        }

        public IActionResult OnPostDelete(int productId)
        {
            UserCart toDelete = _context.UserCarts.FirstOrDefault(u => u.Id == productId);
            if (toDelete != null)
            {
                _context.Remove(toDelete);
                _context.SaveChanges();
            }

            return new JsonResult(new { success = true });
        }
    }
}
