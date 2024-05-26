using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();

        Task<GetByIdCategoryDto> getByIdCategory(string id);
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
    }
}
