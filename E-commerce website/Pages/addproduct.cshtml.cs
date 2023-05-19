using E_commerce_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_website.Pages
{
    public class addproductModel : PageModel
    {
        private readonly ECommerceDBContext _dbContext;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public IFormFile Img1 { get; set; }
        [BindProperty]
        public IFormFile Img2 { get; set; }
        [BindProperty]
        public IFormFile Img3 { get; set; }
        [BindProperty]
        public IFormFile Img4 { get; set; }

        public addproductModel(ECommerceDBContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment) 
        {
            _dbContext = context;
            _environment = environment;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyProduct = new Product();

            //var test = await TryUpdateModelAsync<Product>(
            //    emptyProduct,
            //    "product",   // Prefix for form value.
            //    p => p.name, p => p.descriptionShort, p => p.descriptionLong,
            //    p => p.imgLocation1, p => p.imgLocation2, p => p.imgLocation3,
            //    p => p.imgLocation4, p => p.fullPrice, p => p.discount, p => p.stock,
            //    p => p.tags);
            //var modelState = ModelState.Values;

            var file = Path.Combine(_environment.ContentRootPath,  Img1.FileName); //"uploads",
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Img1.CopyToAsync(fileStream);
            }

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
