using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.CategoryService;
using MultiShop.Catalog.Services.ProductService;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productService.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var value = await _productService.GetProductById(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return Ok("Ürün ekleme başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            _productService.DeleteProductAsync(id);
            return Ok("Categori Silme işlemi başarılı");
        }

    }
}
