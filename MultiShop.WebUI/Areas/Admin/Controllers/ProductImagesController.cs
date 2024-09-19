using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.ProductImagesDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductImages")]
    public class ProductImagesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductImagesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(string productId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7000/api/ProductImages/"+ productId);
            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var deserializeData = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsonData);
                return View(deserializeData);
            }

            return View();
        }

        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(UpdateProductImageDto productImageDto,IFormFile productImage)
        {
            var client = _httpClientFactory.CreateClient();
            productImageDto.ProductImages = productImage != null ? AddImageToFile(productImage) : "null";

            var serializeData = JsonConvert.SerializeObject(productImageDto);
            var stringContent = new StringContent(serializeData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7000/api/ProductImages",stringContent);
            if(response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Product/Index");
            }
            return View();
        }

        [HttpGet]
        [Route("AddProductImages/{id}")]
        public IActionResult AddProductImages(string id)
        {
            ViewData["productId"] = id;
            return View();
        }

        [HttpPost]
        [Route("AddProductImages/{id}")]
        public async Task<IActionResult> AddProductImages(string productId,IFormFile productImage)
        {
            var client = _httpClientFactory.CreateClient();

            var serializeData = JsonConvert.SerializeObject(new CreateProductImageDto
            {
                ProductImages = productImage != null ? AddImageToFile(productImage) : "null",
                ProductId = productId
            });

            var stringContent = new StringContent(serializeData, Encoding.UTF8, "application/json");
            var responseMessage =await client.PostAsync("https://localhost:7000/api/ProductImages", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Product/Index");
            }

            return View();
        }


        //HELPER METHOD
        private string AddImageToFile(IFormFile image)
        {
            var fileExtension = Path.GetExtension(image.FileName);
            var fileName = Guid.NewGuid() + fileExtension;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","online-shop-website-template","img", fileName);

            using (var stream =new FileStream(filePath,FileMode.Create))
            {
                image.CopyTo(stream);
            }

            return $"/online-shop-website-template/img/{fileName}";
        }

    }
}
