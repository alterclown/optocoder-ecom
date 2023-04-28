using System.ComponentModel.DataAnnotations;

namespace OptoCoderEcommerceApi.Data.Entities
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public int Quantity { get; set; }
    }
}
