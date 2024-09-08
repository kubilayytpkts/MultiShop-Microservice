using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.SpecialOfferService;
using MultiShop.Dtos.SpecialOfferDtos;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOfferController : ControllerBase
    {

        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> GettAllSpecialOffer()
        {
            var value = await _specialOfferService.GetAllSpecialOfferAsync();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialOfferById(string id)
        {
            var value = await _specialOfferService.GetSpecialOfferById(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> AddSpecialOffer(CreateSpecialOfferDto createSpecialOffer)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOffer);
            return Ok("Özel Teklif ekleme başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOffer)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOffer);
            return Ok("Özel teklif güncelleme işlemi başarılı");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return Ok("Özel teklif silme işlemi başarılı");
        }
    }
}
