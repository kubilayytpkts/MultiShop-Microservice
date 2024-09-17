using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.WorkingCompanys;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/WorkingCompany")]
    public class WorkingCompanyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WorkingCompanyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7000/api/WorkingCompany");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var deserializeData = JsonConvert.DeserializeObject<List<ResultWorkingCompanyDto>>(jsonData);

                return View(deserializeData);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateWorkingCompany")]
        public IActionResult CreateWorkingCompany()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateWorkingCompany")]
        public async Task<IActionResult> CreateWorkingCompany(CreateWorkingCompanyDto createWorking)
        {
            var client = _httpClientFactory.CreateClient();

            var serializeData = JsonConvert.SerializeObject(createWorking);
            var stringContent = new StringContent(serializeData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7000/api/WorkingCompany", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
              return Redirect("/Admin/WorkingCompany/Index");
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateWorkingCompany/{id}")]
        public async Task<IActionResult> UpdateWorkingCompany(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7000/api/WorkingCompany/" + id);
            if(response.IsSuccessStatusCode)
            {
                var jsonData =await response.Content.ReadAsStringAsync();
                var deserializeData = JsonConvert.DeserializeObject<ResultWorkingCompanyDto>(jsonData);
                
                return View(deserializeData);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateWorkingCompany/{id}")]
        public async Task<IActionResult> UpdateWorkingCompany(UpdateWorkingCompanyDto updateWorking)
        {
            var client = _httpClientFactory.CreateClient();

            var serializeData = JsonConvert.SerializeObject(updateWorking);
            var stringContent = new StringContent(serializeData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7000/api/WorkingCompany/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
               return Redirect("/Admin/WorkingCompany/Index");
            }

            return View();
        }

        [Route("DeleteWorkingCompany/{id}")]
        public async Task<IActionResult> DeleteWorkingCompany(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7000/api/WorkingCompany/" + id);
            if(response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/WorkingCompany/Index");
            }
            return View();
        }
    }
}
