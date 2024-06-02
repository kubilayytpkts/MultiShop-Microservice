using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.CategoryService;
using MultiShop.Catalog.Services.ProductImageService;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {

        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var values = await _productImageService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageyById(string id)
        {
            var value = await _productImageService.GetProductImageById(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImage)
        {
            await _productImageService.CreateProductImageAsync(createProductImage);
            return Ok("Ürün resmi ekleme başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            _productImageService.DeleteProductImageAsync(id);
            return Ok("Ürün resmi Silme işlemi başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetailImage(UpdateProductImageDto updateProductImage)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImage);
            return Ok("Ürün resmi güncelleme başarılı");
        }

    }
}
