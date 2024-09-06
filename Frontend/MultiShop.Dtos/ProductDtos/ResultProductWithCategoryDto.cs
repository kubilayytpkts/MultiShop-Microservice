using MultiShop.Dtos.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Dtos.ProductDtos
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
