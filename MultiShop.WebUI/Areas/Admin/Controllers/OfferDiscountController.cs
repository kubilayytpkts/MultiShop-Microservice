using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.OfferDiscountDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OfferDiscountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7000/api/OfferDiscount");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsondata =await responseMessage.Content.ReadAsStringAsync();
                var deserializeData = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsondata);

                return View(deserializeData);
            }
            return View();
        }

        [HttpGet]
        [Route("AddOfferDiscount")]
        public async Task<IActionResult> AddOfferDiscount()
        {

            return View();
        }

        [HttpPost]
        [Route("AddOfferDiscount")]
        public async Task<IActionResult> AddOfferDiscount(CreateOfferDiscountDto createOffer)
        {
            var client = _httpClientFactory.CreateClient();

            var serializeData = JsonConvert.SerializeObject(createOffer);
            var stringContent = new StringContent(serializeData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7000/api/OfferDiscount", stringContent);
            if (responseMessage.IsSuccessStatusCode)
                return Redirect("/Admin/OfferDiscount/Index");

            return View();
        }

        [HttpGet("{id}")]
        [Route("UpdateOfferDiscount/{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7000/api/OfferDiscount/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var deserializeData = JsonConvert.DeserializeObject<ResultOfferDiscountDto>(jsonData);

                return View(deserializeData);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateOfferDiscount/{id}")]
        public async Task<IActionResult> UpdateOfferDiscout(UpdateOfferDiscount offerDiscount)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(offerDiscount);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7000/api/OfferDiscount", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/OfferDiscount/Index");
            }
            return View();
        }

        [HttpDelete("{id}")]
        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7000/api/OfferDiscount/" + id);
            if(responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/OfferDiscount/Index");
            }
            return View();
        }

    }
}
