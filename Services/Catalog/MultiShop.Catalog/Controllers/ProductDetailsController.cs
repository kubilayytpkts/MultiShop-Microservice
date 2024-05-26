using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductDetailService;
using MultiShop.Catalog.Services.ProductService;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await _productDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var value = await _productDetailService.GetProductDetailById(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Ürün ekleme başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            _productDetailService.DeleteProductDetailAsync(id);
            return Ok("Categori Silme işlemi başarılı");
        }


    }
}
