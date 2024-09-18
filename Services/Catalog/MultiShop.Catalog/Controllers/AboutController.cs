using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Services.AboutService;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAbout(string id)
        {
            var resultAbout = await _aboutService.GetByIdAbout(id);
            return Ok(resultAbout);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAbout()
        {
           var resultAboutList = await _aboutService.GetAllAbout();
            return Ok(resultAboutList); 
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto about)
        {
            await _aboutService.CreateAbout(about);
            return Ok("Hakkımızda ekleme başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto about)
        {
            await _aboutService.UpdateAbout(about);
            return Ok("Hakkımızda düzenleme başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAboutAsync(string id)
        {
            await _aboutService.DeleteAbout(id);
            return Ok("Hakkımızda silme işlemi başarılı");
        }

    }
}
