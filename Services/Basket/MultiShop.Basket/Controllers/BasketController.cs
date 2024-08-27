using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IloginService _loginService;

        public BasketController(IBasketService basketService, IloginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalItemDto basketTotalItemDto)
        {
            basketTotalItemDto.UserId = _loginService.GetUserId;
            _basketService.SaveBasket(basketTotalItemDto);
            return Ok("Sepet Güncelleme işlemi başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMyBasket()
        {
            _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok("Sepet Silme işlemi başarılı");
        }

        [HttpGet]
        public async Task<IActionResult> GetMyBasket()
        {
            var user = User.Claims;
            var userBasket = _basketService.GetBasket(_loginService.GetUserId);
            return Ok(userBasket);    
        }
    }
}
