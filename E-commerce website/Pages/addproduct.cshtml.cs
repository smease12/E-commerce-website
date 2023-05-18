using E_commerce_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_website.Pages
{
    public class addproductModel : PageModel
    {
        private readonly ECommerceDBContext _dbContext;
        [BindProperty]
        public Product Product { get; set; }

        public addproductModel(ECommerceDBContext context) 
        {
            _dbContext = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyProduct = new Product();

            var test = await TryUpdateModelAsync<Product>(
                emptyProduct,
                "product",   // Prefix for form value.
                p => p.name, p => p.descriptionShort, p => p.descriptionLong,
                p => p.imgLocation1, p => p.imgLocation2, p => p.imgLocation3,
                p => p.imgLocation4, p => p.fullPrice, p => p.discount, p => p.stock,
                p => p.tags);
            var modelState = ModelState.Values;

            if (await TryUpdateModelAsync<Product>(
                emptyProduct,
                "product",   // Prefix for form value.
                p => p.name, p=> p.descriptionShort, p => p.descriptionLong,
                p => p.imgLocation1, p => p.imgLocation2, p => p.imgLocation3,
                p => p.imgLocation4, p => p.fullPrice, p => p.discount, p => p.stock,
                p => p.tags))
            {
                _dbContext.Products.Add(emptyProduct);
                await _dbContext.SaveChangesAsync();
                return RedirectToPage("/");
            }

            return Page();
        }
    }
}
