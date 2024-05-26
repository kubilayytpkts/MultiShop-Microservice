using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.ProductDetailService
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task<GetByIdProductDetailDto> GetProductDetailById(string id);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
    }
}

