using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLogicLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using MultiSop.Cargo.DtosLayer.CargoCompanyDtos;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpPost]
        public IActionResult CargoCompany(AddCargoCompanyDto addCargoCompany )
        {
            _cargoCompanyService.BInsert(new CargoCompany
            {
                CompanyName = addCargoCompany.CompanyName,
            });

            return Ok("Kargo Şirketi ekleme başarılı");
        }

        [HttpPut]
        public IActionResult CargoCompany(UpdateCargoCompanytDto updateCargo)
        {
            _cargoCompanyService.BUpdate(new CargoCompany
            {
                CompanyName = updateCargo.CompanyName,
                CompanyId = updateCargo.CompanyId
            });
            return Ok("Kargo Şirketi güncelleme başarılı");
        }

        [HttpDelete]
        public IActionResult actionResult(int id)
        {
            _cargoCompanyService.BDelete(id);
            return Ok("Kargo Şirketi Silme başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult CargoCompany(int id)
        {
            var resultCargoCompany = _cargoCompanyService.BGetById(id);
            return Ok(resultCargoCompany);
        }

        [HttpGet]
        public IActionResult GetAllCargoCompany()
        {
            var resultCargoCompanyList = _cargoCompanyService.BGetAll();
            return Ok(resultCargoCompanyList);
        }
    }
}
