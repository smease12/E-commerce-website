using E_commerce_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce_website.Pages
{
    public class searchModel : PageModel
    {
        private ECommerceDBContext _context;
        [BindProperty]
        public List<Product> Products { get; set; }
        [BindProperty]
        public string searchKeyword { get; set; }

        public searchModel(ECommerceDBContext context) 
        {
            _context = context;
        }
        public void OnGet(string? keyword)
        {
            searchKeyword = keyword;
            Products = _context.Products.Where(p => p.tags.Contains(keyword)).ToList();
        }
    }
}
