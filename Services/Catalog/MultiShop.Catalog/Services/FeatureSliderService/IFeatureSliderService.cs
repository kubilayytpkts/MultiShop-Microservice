using MultiShop.Catalog.Dtos.FeatureSlider;
using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.FeatureSliderService
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeature);

        Task<GetByIdFeatureSliderDto> GetFeatureSliderById(string id);

        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
        Task DeleteFeatureSliderAsync(string id);
        Task ActiveSliderStatus(string id);
        Task PassiveSliderStatus(string id);
    }
}
