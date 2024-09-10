using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.FeatureDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7000/api/Feature");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var deserializeData = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);

                return View(deserializeData);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();

            var serializeData = JsonConvert.SerializeObject(createFeatureDto);
            var stringContent = new StringContent(serializeData, Encoding.UTF8, "application/json");

            var reponseMessage = await client.PostAsync("https://localhost:7000/api/Feature", stringContent);
            if (reponseMessage.IsSuccessStatusCode)
                return Redirect("/Admin/Feature/Index");

            return View();
        }

        [HttpGet]
        [Route("UpdateFeature/{id}")]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7000/api/Feature/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var deserializeData = JsonConvert.DeserializeObject<ResultFeatureDto>(jsonData);
                return View(deserializeData);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateFeature/{id}")]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();

            var SerializeData = JsonConvert.SerializeObject(updateFeatureDto);
            var stringContent = new StringContent(SerializeData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7000/api/Feature", stringContent);
            if (responseMessage.IsSuccessStatusCode)
                return Redirect("/Admin/Feature/Index");

            return View();
        }

        [Route("DeleteFeature/{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7000/api/Feature/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Feature/Index");
            }
            return View();
        }
    }
}
