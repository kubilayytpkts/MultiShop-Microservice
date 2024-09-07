using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MultiShop.Dtos.FeatureSliderDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarosuelDefaultComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarosuelDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7000/api/FeatureSlider");
            if(responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var deserializeData = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(data);

                List<ResultFeatureSliderDto> getAllActiveFeatureSlider=new List<ResultFeatureSliderDto>();

                foreach (var item in deserializeData)
                {
                    if(item.Status == false)
                        getAllActiveFeatureSlider.Add(item);
                }

                return View(getAllActiveFeatureSlider);
            }
            return View();
        }
    }
}
