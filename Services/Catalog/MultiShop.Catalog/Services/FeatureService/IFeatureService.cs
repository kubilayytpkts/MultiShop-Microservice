using MultiShop.Catalog.Dtos.FeatureDtos;

namespace MultiShop.Catalog.Services.FeatureService
{
    public interface IFeatureService
    {
        public Task AddFeatureAsync(CreateFeatureDto featureDto);
        public Task DeleteFeatureAsync(string id);
        public Task UpdateFeatureAsync(UpdateFeatureDto featureDto);
        public Task<ResultFeatureDto> GetByIdFeatureAsync(string id);
        public Task<List<ResultFeatureDto>> ListFeatureAsync();

    }
}
