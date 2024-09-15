using AutoMapper;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;
using MultiShop.Dtos.SpecialOfferDtos;
using System.Text.Json.Serialization;

namespace MultiShop.Catalog.Services.SpecialOfferService
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;
        private readonly IMapper _mapper;
        public SpecialOfferService(IDatabaseSettings databaseSettings,IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _specialOfferCollection = database.GetCollection<SpecialOffer>(databaseSettings.SpecialOfferCollectionName);
            _mapper = mapper;
        }
        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var data = _mapper.Map<SpecialOffer>(createSpecialOfferDto);
            await _specialOfferCollection.InsertOneAsync(data);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _specialOfferCollection.DeleteOneAsync(x=>x.SpecialOfferId == id);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var data =await _specialOfferCollection.Find(x=> true).ToListAsync();
            return _mapper.Map<List<ResultSpecialOfferDto>>(data);  
        }

        public async Task<GetByIdSepacialOfferDto> GetSpecialOfferById(string id)
        {
            var data =await _specialOfferCollection.Find(x=>x.SpecialOfferId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSepacialOfferDto>(data);
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOffer)
        {
            var data = _mapper.Map<SpecialOffer>(updateSpecialOffer);
            await _specialOfferCollection.FindOneAndReplaceAsync(x => x.SpecialOfferId == data.SpecialOfferId, data);
        }
    }
}
