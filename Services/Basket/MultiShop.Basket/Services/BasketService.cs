using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisServices _redisServices;

        public BasketService(RedisServices redisServices)
        {
            _redisServices = redisServices;
        }

        public async Task DeleteBasket(string userId)
        {
            await _redisServices.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalItemDto> GetBasket(string userId)
        {
            var existBasket =await  _redisServices.GetDb().StringGetAsync(userId);

            var value = JsonSerializer.Deserialize<BasketTotalItemDto>(existBasket);
            return value;

        }

        public async Task SaveBasket(BasketTotalItemDto basketTotalItem)
        {
            await _redisServices.GetDb().StringSetAsync(basketTotalItem.UserId, JsonSerializer.Serialize(basketTotalItem));

        }
    }
}
