using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.WorkingCompanys;
using Newtonsoft.Json;
using System.Net.WebSockets;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _VendorDefaultComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _VendorDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7000/api/WorkingCompany");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsondData = await responseMessage.Content.ReadAsStringAsync();
                var deserializeData = JsonConvert.DeserializeObject<List<ResultWorkingCompanyDto>>(jsondData);

                return View(deserializeData);
            }
            return View();
        }
    }
}
