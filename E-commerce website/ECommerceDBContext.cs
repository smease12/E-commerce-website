using Microsoft.EntityFrameworkCore;
using E_commerce_website.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace E_commerce_website
{
    public class ECommerceDBContext : IdentityDbContext<IdentityUser>
    {
        public ECommerceDBContext(DbContextOptions<ECommerceDBContext> options)
             : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
