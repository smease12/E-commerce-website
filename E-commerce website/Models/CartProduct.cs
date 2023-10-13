namespace E_commerce_website.Models
{
    public class CartProduct
    {
        public int Id { get; set; }
        public DateTime? DateAdded { get; set; }
        public int? Quantity { get; set; }
        public DateTime? DateDelivery { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
