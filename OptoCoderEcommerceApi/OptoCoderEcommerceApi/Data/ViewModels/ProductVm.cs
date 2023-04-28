using OptoCoderEcommerceApi.Data.Entities;

namespace OptoCoderEcommerceApi.Data.ViewModels
{
    public class ProductVm
    {
        public Product product { get; set; }
        public List<Images> images { get; set; } = new List<Images>();
    }
}
