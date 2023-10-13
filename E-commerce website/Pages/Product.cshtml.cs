using E_commerce_website.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_website.Pages
{
    public class ProductModel : PageModel
    {
        private ECommerceDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public bool IsAddProductSuccessful { get; set; }
        public string InsertedProductName { get; set; }
        public ProductModel(ECommerceDBContext dbContext, UserManager<ApplicationUser> userManager) 
        {
            _context = dbContext;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGetAsync(int? productId)
        {
            Product = await _context.Products.FirstOrDefaultAsync(p => p.id == productId);
            if (Product == null) 
            {
               Product = await _context.Products.FirstOrDefaultAsync(p => p.id == 9);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            
            

            Cart userCart = new Cart();
            userCart.DateAdded = DateTime.Now;
            userCart.Product = 
                await _context.Products.FirstOrDefaultAsync(p => p.id == Product.id);
            userCart.ApplicationUser = user;
            userCart.Quantity = 1;
            userCart.DateDelivery = (DateTime.Today).AddDays(3);

            //check if this item is aleady in user cart
            Cart existingCart = _context.Carts
                .Where(u => u.ApplicationUser == user)
                .Where(u => u.Product == userCart.Product)
                .FirstOrDefault();

            if(existingCart != null) 
            {
                existingCart.Quantity += 1;
            }
            else
            {
                _context.Add(userCart);
            }          
            await _context.SaveChangesAsync();

            IsAddProductSuccessful = true;
            InsertedProductName = userCart.Product.name;

            return Page();
        }
    }
}
