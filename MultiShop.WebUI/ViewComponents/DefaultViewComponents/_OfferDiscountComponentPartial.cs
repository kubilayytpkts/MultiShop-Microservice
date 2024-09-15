using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.OfferDiscountDtos;
using MultiShop.Dtos.SpecialOfferDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _OfferDiscountComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public _OfferDiscountComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7000/api/OfferDiscount");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var deserializeData = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
                
                return View(deserializeData);
            }
            return View();
        }
    }
}
