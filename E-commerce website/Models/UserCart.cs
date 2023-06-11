namespace E_commerce_website.Models
{
    public class UserCart
    {
        public int Id { get; set; } 
        public DateTime? DateAdded { get; set; }
        public int? Quantity { get; set; }
        public DateTime? DateDelivery { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Product Product { get; set; }
    }
}
