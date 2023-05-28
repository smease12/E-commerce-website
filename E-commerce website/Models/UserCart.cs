﻿namespace E_commerce_website.Models
{
    public class UserCart
    {
        public int Id { get; set; } 
        public DateTime? DateAdded { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Product Product { get; set; }
    }
}