using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.AboutDtos;
using MultiShop.Dtos.WorkingCompanys;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            string defaultAboutId = "66e9f6f296255582f3817d8c"; //Default About ıd

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7000/api/About/" + defaultAboutId);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var deserializeData = JsonConvert.DeserializeObject<ResultAboutDto>(jsonData);

                return View(deserializeData);
            }

            return View();
        }

        [HttpGet]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response =await client.GetAsync("https://localhost:7000/api/About/" + id);
            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var deserializeData = JsonConvert.DeserializeObject<ResultAboutDto>(jsonData);
                return View(deserializeData);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAbout)
        {
            var client = _httpClientFactory.CreateClient();

            var serializeData = JsonConvert.SerializeObject(updateAbout);
            var stringContent = new StringContent(serializeData, Encoding.UTF8, "application/json");
            var responseMessgae = await client.PutAsync("https://localhost:7000/api/About", stringContent);
            if (responseMessgae.IsSuccessStatusCode)
            {
                return Redirect("/Admin/About/Index");
            }
            return View();
        }

    }
}
