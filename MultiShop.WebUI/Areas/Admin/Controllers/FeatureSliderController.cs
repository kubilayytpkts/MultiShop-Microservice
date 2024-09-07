using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.FeatureSliderDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureSliderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7000/api/FeatureSlider");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var deserializeData = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(data);

                return View(deserializeData);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto sliderDto)
        {
            var client = _httpClientFactory.CreateClient();

            var serializeData = JsonConvert.SerializeObject(sliderDto);
            var stringContent = new StringContent(serializeData, Encoding.UTF8, "application/json");
            var postRequest = await client.PostAsync("https://localhost:7000/api/FeatureSlider", stringContent);

            return Redirect("/Admin/FeatureSlider/Index");
        }

        [HttpGet]
        [Route("UpdateFeatureSlider/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7000/api/FeatureSlider/" + id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var deserializeData = JsonConvert.DeserializeObject<ResultFeatureSliderDto>(data);

                return View(deserializeData);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateFeatureSlider/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto sliderDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(sliderDto);
            var stringData = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7000/api/FeatureSlider",stringData);
            if(responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/FeatureSlider/Index");
            }
            return View();
        }

        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7000/api/FeatureSlider/" + id);
            
            if (responseMessage.IsSuccessStatusCode)
                return Redirect("/Admin/FeatureSlider/Index");

            return View();
        }
    }
}
