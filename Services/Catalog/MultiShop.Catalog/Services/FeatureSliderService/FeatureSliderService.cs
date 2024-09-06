using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureSlider;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderService
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
        private readonly IMapper _mapper;
        public FeatureSliderService(IDatabaseSettings _databaseSettings,IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _featureSliderCollection = database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName);
            _mapper = mapper;
        }

        public Task ActiveSliderStatus(string id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeature)
        {
            var value = _mapper.Map<FeatureSlider>(createFeature);
            await _featureSliderCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _featureSliderCollection.DeleteOneAsync(x=>x.SliderID == id);
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var result = await _featureSliderCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultFeatureSliderDto>>(result);
        }

        public async Task<GetByIdFeatureSliderDto> GetFeatureSliderById(string id)
        {
            var value = await _featureSliderCollection.Find(x=>x.SliderID==id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureSliderDto>(value);
        }

        public Task PassiveSliderStatus(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var value = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.SliderID == value.SliderID,value);
        }
    }
}
