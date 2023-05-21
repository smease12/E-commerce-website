using E_commerce_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_website.Pages
{
    public class ProductModel : PageModel
    {
        private ECommerceDBContext _context;
        public Product Product { get; set; }
        public ProductModel(ECommerceDBContext dbContext) 
        {
            _context = dbContext;
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
    }
}
