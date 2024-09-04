using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.Dtos.CategoryDto;
using MultiShop.Dtos.ProductDtos;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7000/api/Products");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var stringData = JsonConvert.DeserializeObject<List<ProductResultDto>>(jsonData);

                return View(stringData);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            ViewData["CategoryList"] = await GetCategoriesHelperMethod(null);

            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProduct)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProduct);
            var stingContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7000/api/Products/", stingContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Product/Index");
            }
            return Redirect("Index");
        }

        [HttpGet]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7000/api/Products/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var stringData = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);

                ViewData["CategoryList"] = await GetCategoriesHelperMethod(stringData.ProductID);
                return View(stringData);
            }

            return View();
        }

        [HttpPost]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProduct)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProduct);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7000/api/Products/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Product/Index");
            }
            return View();
        }


        //HELPER METHOD
        private async Task<List<SelectListItem>> GetCategoriesHelperMethod(string? id)
           {
            string productCategoryId = null;

            var client = _httpClientFactory.CreateClient();
            var messageResponse = await client.GetAsync("https://localhost:7000/api/Categories");

            var jsonData = await messageResponse.Content.ReadAsStringAsync();
            var stringData = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            if(id != null)
            {
                var _messageResponse = await client.GetAsync("https://localhost:7000/api/Products/" +id);
                var _jsonData =await _messageResponse.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ProductResultDto>(_jsonData);

                productCategoryId = data.CategoryID;
            }

            List<SelectListItem> selectListItems = (from x in stringData
                                                    select new SelectListItem
                                                    {
                                                        Text = x.CategoryName,
                                                        Value = x.CategoryID.ToString(),
                                                        Selected = productCategoryId != null && x.CategoryID == productCategoryId
                                                    }).ToList();

            return selectListItems;
        }
    }
}
