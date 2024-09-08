using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.SpecialOfferDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SpecialOfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult>Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7000/api/SpecialOffer");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
                return View(data);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer()
        {
            return View();

        }

        [HttpPost]
        [Route("CreateSpecialOffer")]

        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOffer)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSpecialOffer);
            var stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");

            var responseMessage = await client.PostAsync("https://localhost:7000/api/SpecialOffer", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/SpecialOffer/Index");
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage =await client.GetAsync("https://localhost:7000/api/SpecialOffer/" + id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData =await responseMessage.Content.ReadAsStringAsync();
                var deserializeData = JsonConvert.DeserializeObject<ResultSpecialOfferDto>(jsonData);

                return View(deserializeData);
            }

            return View();
        }

        [HttpPost]
        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecial)
        {
            var client = _httpClientFactory.CreateClient();
            var serializeData = JsonConvert.SerializeObject(updateSpecial);
            var stringContent = new StringContent(serializeData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7000/api/SpecialOffer", stringContent);
            if (responseMessage.IsSuccessStatusCode)
                return Redirect("/Admin/SpecialOffer/Index");
            
            return View();
        }

        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7000/api/SpecialOffer/" + id);
            if(responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/SpecialOffer/Index");
            }

            return View();
        }
    }
}
