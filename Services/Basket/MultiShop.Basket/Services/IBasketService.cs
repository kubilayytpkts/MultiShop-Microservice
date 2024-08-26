using MultiShop.Basket.Dtos;
namespace MultiShop.Basket.Services
{
    public interface IBasketService
    {
        public Task SaveBasket(BasketTotalItemDto basketTotalItem);
        public Task DeleteBasket(string userId);
        public Task<BasketTotalItemDto> GetBasket(string userId);
    }
}
