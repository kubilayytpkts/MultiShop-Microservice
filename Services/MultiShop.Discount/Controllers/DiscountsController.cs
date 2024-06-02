using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountCouponService _discountCouponService;
        public DiscountsController(IDiscountCouponService discountCouponService)
        {
            _discountCouponService = discountCouponService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var value = await _discountCouponService.GetAllDiscountCouponAsync();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdDiscountCoupon(int id)
        {
            var value = await _discountCouponService.GetByIdDiscountCouponDtoAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createDiscountCoupon)
        {
            await _discountCouponService.CreateDiscountCouponAsync(createDiscountCoupon);
            return Ok("Kupon Ekleme Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateDiscountCoupon)
        {
            await _discountCouponService.UpdateDiscountCouponAsync(updateDiscountCoupon);
            return Ok("Kupon Güncelleme Başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountCouponService.DeleteDiscountCouponAsync(id);
            return Ok("Kupon Silme İşlemi Başarılı");
        }
    }
}
