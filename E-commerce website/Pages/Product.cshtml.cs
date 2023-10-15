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
            Product product = await _context.Products
                    .FirstOrDefaultAsync(p => p.id == Product.id);
            //check if this user already has a cart
            Cart userCart = _context.Carts
            .Where(u => u.ApplicationUser == user)
            .FirstOrDefault();

            if (userCart == null)
            {
                Cart newCart = new Cart();
                newCart.ApplicationUser = user;
                CartProduct newCartProduct = new CartProduct();
                newCartProduct.Quantity = 1;
                newCartProduct.DateAdded = DateTime.Now;
                newCartProduct.DateDelivery = (DateTime.Today).AddDays(3);
                newCartProduct.Product = product;
                newCart.CartProducts.Add(newCartProduct);
                _context.Carts.Add(newCart);
            }
            else
            {
                CartProduct userCartProduct = new CartProduct();
                userCartProduct.DateAdded = DateTime.Now;
                userCartProduct.Product = product;
                userCartProduct.Quantity = 1;
                userCartProduct.DateDelivery = (DateTime.Today).AddDays(3);
                userCart.CartProducts.Add(userCartProduct);
            }
         
            await _context.SaveChangesAsync();

            IsAddProductSuccessful = true;
            InsertedProductName = product.name;

            return Page();
        }
    }
}
