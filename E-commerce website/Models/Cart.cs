namespace E_commerce_website.Models
{
    public class Cart
    {
        public int Id { get; set; } 
        public DateTime? DateAdded { get; set; }
        public int? Quantity { get; set; }
        public DateTime? DateDelivery { get; set; }
        public string? Country { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        //address1 = street address or p.o. box
        public string? Address1 { get; set; }
        //address2 = apt, suite, unit, building, floor, etc. 
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? ZipCode { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Product Product { get; set; }
    }
}
