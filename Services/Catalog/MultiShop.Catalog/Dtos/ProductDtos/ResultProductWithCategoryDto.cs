using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class ResultProductWithCategoryDto
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public Decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImageUrl { get; set; }
        public ResultCategoryDto Category { get; set; }
    }
}
