﻿using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Dtos.SpecialOfferDtos;

namespace MultiShop.Catalog.Services.SpecialOfferService
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
        Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);

        Task<GetByIdSpecialOfferDto> GetSpecialOfferById(string id);

        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOffer);
        Task DeleteSpecialOfferAsync(string id);
    }
}
