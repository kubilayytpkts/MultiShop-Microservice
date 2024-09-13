using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Dtos.SpecialOfferDtos;

namespace MultiShop.Catalog.Services.SpecialOfferService
{
    public interface ISpecialOfferService
    {
        Task<List<ResultOfferDiscountDto>> GetAllSpecialOfferAsync();
        Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);

        Task<GetByIdSOfferDiscountDto> GetSpecialOfferById(string id);

        Task UpdateSpecialOfferAsync(UpdateOfferDiscountDto updateSpecialOffer);
        Task DeleteSpecialOfferAsync(string id);
    }
}
