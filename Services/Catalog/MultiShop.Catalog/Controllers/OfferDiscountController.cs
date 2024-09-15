using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Services.OfferDiscountService;

namespace MultiShop.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OfferDiscountController : ControllerBase
	{
		private readonly IOfferDiscountService _offerDiscount;

		public OfferDiscountController(IOfferDiscountService offerDiscount)
		{
			_offerDiscount = offerDiscount;
		}

		[HttpGet]
		public async Task<IActionResult> GetOfferDiscount()
		{
			var resultOfferDiscount = await _offerDiscount.GetAllOfferDiscountAsync();
			return Ok(resultOfferDiscount);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetOfferDiscountById(string id)
		{
			var resultOfferDiscount = await _offerDiscount.GetOfferDiscountById(id);
			return Ok(resultOfferDiscount);
		}

		[HttpPost]
		public async Task<IActionResult> AddOfferDiscount(CreateOfferDiscountDto createOfferDiscount)
		{
			await _offerDiscount.CreateOfferDiscountAsync(createOfferDiscount);
			return Ok("Özel indirim ekleme başarılı !");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscount)
		{
			await _offerDiscount.UpdateOfferDiscountAsync(updateOfferDiscount);
			return Ok("Özel indirim güncelleme başarılı !");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveOfferDiscount(string id)
		{
			await _offerDiscount.DeleteOfferDiscountAsync(id);
			return Ok("Özel indirim silme işlemi başarılı !");
		}
	}
}
