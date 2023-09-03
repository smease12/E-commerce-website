using E_commerce_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace E_commerce_website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ECommerceDBContext _dbContext;
        [BindProperty]
        public List<Product> FeaturedProducts { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ECommerceDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            List<int> idList = new List<int>{ 14, 15, 16, 17, 18, 19, 20, 21, 22 };
            FeaturedProducts = _dbContext.Products.Where(p => idList.Contains(p.id)).ToList();
        }
    }
}