using MultiShop.Catalog.Dtos.OfferDiscountDtos;

namespace MultiShop.Catalog.Services.OfferDiscountService
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();
        Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto);

        Task<GetByIdOfferDiscountDto> GetOfferDiscountById(string id);

        Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscount);
        Task DeleteOfferDiscountAsync(string id);
    }
}
