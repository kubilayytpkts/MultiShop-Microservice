using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Services.FeatureService;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpPost]
        public async Task<IActionResult> AddFeatureAsync(CreateFeatureDto createFeature)
        {
            await _featureService.AddFeatureAsync(createFeature);
            return Ok("Özellik ekleme işlemi başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeatureAsync(UpdateFeatureDto updateFeature)
        {
            await _featureService.UpdateFeatureAsync(updateFeature);
            return Ok("Özellik güncelleme işlemi başarılı");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeatureAsync(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return Ok("Özellik silme işlemi başarışı");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdFeatureAsync(string id)
        {
            var featureData = await _featureService.GetByIdFeatureAsync(id);
            return Ok(featureData);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFeatureAsync()
        {
            var featureList = await _featureService.ListFeatureAsync();
            return Ok(featureList);
        }
    }
}
