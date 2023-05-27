using E_commerce_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_website.Pages
{
    public class CartModel : PageModel
    {
        [BindProperty]
        public List<Product> Products { get; set; }
        private readonly ECommerceDBContext _context;
        public CartModel(ECommerceDBContext context)
        {
            _context = context;
        }
        public async void OnGetAsync(int UserId)
        {
            Products = ( from p in _context.Products
                      join u in _context.UserCarts on p.id equals u.Product.id
                      select p
                ).ToList();
        }
    }
}
