﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.ProductImagesDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailComponents
{
    public class _DetailImagesComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DetailImagesComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7000/api/ProductImages/GetImagesByProductId/" + productId);
            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var deserializeData = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsonData);
                return View(deserializeData);
            }
            return View();
        }
    }
}
