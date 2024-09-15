using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureSlider;
using MultiShop.Catalog.Services.FeatureSliderService;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSliderController : ControllerBase
    {
        private readonly IFeatureSliderService _featureSliderService;
            
        public FeatureSliderController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFeatureSliderAsync()
        {
            var featureSliderList = await _featureSliderService.GetAllFeatureSliderAsync();
            return Ok(featureSliderList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureSliderAsync(string id)
        {
            var featureSliderById =await _featureSliderService.GetFeatureSliderById(id);
            return Ok(featureSliderById);
        }

        [HttpPost]
        public async Task<IActionResult> PostFeatureSliderAsync(CreateFeatureSliderDto createFeatureSlider)
        {
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSlider);
            return Ok("Slider ekleme işlemi başarılı !");
        }

        [HttpPut]
        public async Task<IActionResult> PutFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSlider)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSlider);
            return Ok("Slider güncelleme işlemi başarılı !");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeatureAsync(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return Ok("Slider silme işlemi başarılı !");
        }
    }
}
