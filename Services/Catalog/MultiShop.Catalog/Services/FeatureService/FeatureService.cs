using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Core.Misc;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureService
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Features> _featureCollection;
        private IMapper _mapper;
        public FeatureService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featureCollection = database.GetCollection<Features>(databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }
        public async Task AddFeatureAsync(CreateFeatureDto featureDto)
        {
            var mapData = _mapper.Map<Features>(featureDto);
            await _featureCollection.InsertOneAsync(mapData);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(x => x.FeatureId == id);
        }

        public async Task<ResultFeatureDto> GetByIdFeatureAsync(string id)
        {

            var value =await _featureCollection.Find(x => x.FeatureId == id).FirstOrDefaultAsync();
            var mappedData = _mapper.Map<ResultFeatureDto>(value);

            return mappedData;
        }

        public async Task<List<ResultFeatureDto>> ListFeatureAsync()
        {
            var value = await _featureCollection.Find(x=> true).ToListAsync();
            var mappedData = _mapper.Map<List<ResultFeatureDto>>(value);
            
            return mappedData;
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto featureDto)
        {
            var data = _mapper.Map<Features>(featureDto);
            await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureId == featureDto.FeatureId, data);
        }
    }
}
