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
        public IFormFile? Img1 { get; set; }
        [BindProperty]
        public IFormFile? Img2 { get; set; }
        [BindProperty]
        public IFormFile? Img3 { get; set; }
        [BindProperty]
        public IFormFile? Img4 { get; set; }

        public addproductModel(ECommerceDBContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment) 
        {
            _dbContext = context;
            _environment = environment;
        }

        public void OnGet()
        {
        }

        //upload a file and return the file location as a string
        private string uploadFile(IFormFile img) 
        {
            string path = "";
            if (img != null)
            {
                var file = Path.Combine(_environment.ContentRootPath, "wwwroot\\uploads", img.FileName);
                path = file.ToString();
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    img.CopyTo(fileStream);
                }
            }
            return path;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyProduct = new Product();

            var test = await TryUpdateModelAsync<Product>(
                emptyProduct,
                "product",   // Prefix for form value.
                p => p.name, p => p.descriptionShort, p => p.descriptionLong,
                 p => p.fullPrice, p => p.discount, p => p.stock, p => p.tags);
            var modelState = ModelState.Values;


            if (await TryUpdateModelAsync<Product>(
                emptyProduct,
                "product",   // Prefix for form value.
                p => p.name, p=> p.descriptionShort, p => p.descriptionLong,
                 p => p.fullPrice, p => p.discount, p => p.stock, p => p.tags))
            {
                emptyProduct.imgLocation1 = uploadFile(Img1);
                emptyProduct.imgLocation2 = uploadFile(Img2);
                emptyProduct.imgLocation3 = uploadFile(Img3);
                emptyProduct.imgLocation4 = uploadFile(Img4);
                _dbContext.Products.Add(emptyProduct);
                await _dbContext.SaveChangesAsync();
                return RedirectToPage("/");
            }

            return Page();
        }
    }
}
