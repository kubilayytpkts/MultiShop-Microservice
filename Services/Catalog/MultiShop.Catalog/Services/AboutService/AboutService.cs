using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.AboutService
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _aboutMongoCollection;
        private readonly IMapper _mapper;

        public AboutService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _aboutMongoCollection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
            _mapper = mapper;
        }

        public async Task CreateAbout(CreateAboutDto about)
        {
            var mappedData = _mapper.Map<About>(about);
            await _aboutMongoCollection.InsertOneAsync(mappedData);
        }

        public async Task DeleteAbout(string id)
        {
            await _aboutMongoCollection.DeleteOneAsync(x => x.id == id);
        }

        public async Task<List<ResultAboutDto>> GetAllAbout()
        {
            var resultAbout = await _aboutMongoCollection.Find(x => true).ToListAsync();
            var mappedData = _mapper.Map<List<ResultAboutDto>>(resultAbout);

            return mappedData;
        }

        public async Task<ResultAboutDto> GetByIdAbout(string id)
        {
            var resultAbout = await _aboutMongoCollection.Find(x => x.id == id).FirstOrDefaultAsync();
            var mappedData = _mapper.Map<ResultAboutDto>(resultAbout);
            return mappedData;
        }

        public async Task UpdateAbout(UpdateAboutDto about)
        {
            var mappedData = _mapper.Map<About>(about);
            await _aboutMongoCollection.FindOneAndReplaceAsync(x => x.id == about.id, mappedData);
        }
    }
}
