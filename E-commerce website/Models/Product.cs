using System.ComponentModel.DataAnnotations;

namespace E_commerce_website.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; } 
        public string? descriptionShort { get; set; }
        public string? descriptionLong { get; set; }
        public string? imgLocation1 { get; set; }
        public string? imgLocation2 { get; set;}
        public string? imgLocation3 { get; set;} 
        public string? imgLocation4 { get; set;}
        public decimal fullPrice { get; set; }
        public int? discount { get; set; }
        public decimal? sellPrice { get; set; }
        public int stock { get; set; }
        public string? tags { get; set; }
        
    }
}
