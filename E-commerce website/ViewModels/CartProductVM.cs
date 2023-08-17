using System.ComponentModel.DataAnnotations;

namespace E_commerce_website.ViewModels
{
    public class CartProductVM
    {
        public int ProductId { get; set; }
        public int UserCartId { get; set; }
        public string ProductName { get; set; }
        public string? ProductImg { get; set; }
        public decimal? ProductSellPrice { get; set; }
        public decimal? OrderSellPrice { get; set; }
        public int? ProductQty { get; set; }

        public string? DeliveryDate { get; set; }

    }
}
