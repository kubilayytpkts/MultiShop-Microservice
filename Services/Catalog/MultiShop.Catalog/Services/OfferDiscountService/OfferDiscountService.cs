using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;
using MultiShop.Dtos.OfferDiscountDtos;

namespace MultiShop.Catalog.Services.OfferDiscountService
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly IMongoCollection<OfferDiscount> _offerDisctounCollection;
        private readonly IMapper _mapper;

        public OfferDiscountService(IDatabaseSettings databaseSettings,IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _offerDisctounCollection = database.GetCollection<OfferDiscount>(databaseSettings.OfferDiscountCollectionName);
            _mapper = mapper;
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var mappedData= _mapper.Map<OfferDiscount>(createOfferDiscountDto);
           await _offerDisctounCollection.InsertOneAsync(mappedData);

        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _offerDisctounCollection.FindOneAndDeleteAsync<OfferDiscount>(id);
        }

        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
        {
           var resultList = await _offerDisctounCollection.Find<OfferDiscount>(x => true).ToListAsync();
           var mappedData = _mapper.Map<List<ResultOfferDiscountDto>>(resultList);
            return mappedData;
        }

        public async Task<GetByIdSOfferDiscountDto> GetOfferDiscountById(string id)
        {
            var resultList =await _offerDisctounCollection.Find<OfferDiscount>(x=>x.SpecialOfferId==id).FirstOrDefaultAsync();
            var mappedData = _mapper.Map<GetByIdSOfferDiscountDto>(resultList);
            return mappedData;
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscount)
        {
            var mappedData = _mapper.Map<OfferDiscount>(updateOfferDiscount);
            await _offerDisctounCollection.FindOneAndReplaceAsync<OfferDiscount>(x => x.SpecialOfferId == updateOfferDiscount.OfferDiscountId,mappedData);

        }
    }
}
