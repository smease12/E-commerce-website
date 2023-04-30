using Microsoft.EntityFrameworkCore;
using E_commerce_website.Models;

namespace E_commerce_website
{
    public class ECommerceDBContext : DbContext
    {
        public ECommerceDBContext(DbContextOptions<ECommerceDBContext> options)
             : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
