using AutoMapper;
using MultiShop.Catalog.Dtos;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Dtos.FeatureSlider;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Dtos.WorkingCompanyDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Dtos.SpecialOfferDtos;

namespace MultiShop.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            //CATEGORY
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

            //PRODUCT
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>().ReverseMap();

            //PRODUCTDETAİL
            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();

            //PRODUCTIMAGE
            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();

            //SLİDER
            CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, GetByIdFeatureSliderDto>().ReverseMap();

            //SPECİAL OFFER(ANASAYFA UST KISIM INDIRIMLER)
            CreateMap<SpecialOffer, GetByIdSepacialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, UpdateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, ResultSpecialOfferDto>().ReverseMap();

            //FEATURES()
            CreateMap<Features, UpdateFeatureDto>().ReverseMap();
            CreateMap<Features, CreateFeatureDto>().ReverseMap();
            CreateMap<Features, GetByIdFeatureDto>().ReverseMap();
            CreateMap<Features, ResultFeatureDto>().ReverseMap();

            //OFFER DİSCOUNT(OZEL ALAN INDIRIMLERI URUNLERIN ALT KISMI )
            CreateMap<OfferDiscount, UpdateOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, CreateOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, GetByIdOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, ResultOfferDiscountDto>().ReverseMap();

            //WORKİNG COMPANY (ÇALIŞILAN ŞİRKETLER) 
            CreateMap<WorkingCompany, CreateWorkingCompanyDto>().ReverseMap();
            CreateMap<WorkingCompany, ResultWorkingCompanyDto>().ReverseMap();
            CreateMap<WorkingCompany, GetByIdWorkingCompanyDto>().ReverseMap();
            CreateMap<WorkingCompany, UpdateWorkingCompanyDto>().ReverseMap();
        }
    }
}
