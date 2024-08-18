using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLogicLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using MultiSop.Cargo.DtosLayer.CargoCustomerDtos;


namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomerController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpPost]
        public IActionResult CargoCustomer(AddCargoCustomerDto addCustomerDto)
        {
            _cargoCustomerService.BInsert(new CargoCustomer
            {
                Address = addCustomerDto.Address,
                City = addCustomerDto.City,
                District = addCustomerDto.District,
                Email = addCustomerDto.Email,
                Name = addCustomerDto.Name,
                Phone = addCustomerDto.Phone,
                Surname = addCustomerDto.Surname,
            });

            return Ok("Kargo Müşterisi ekleme başarılı");
        }

        [HttpPut]
        public IActionResult CargoCustomer(UpdateCargoCustomerDto updateCustomerDto)
        {
            _cargoCustomerService.BUpdate(new CargoCustomer
            {
                Address = updateCustomerDto.Address,
                City = updateCustomerDto.City,
                CargoCustomerId = updateCustomerDto.CargoCustomerId,
                District = updateCustomerDto.District,
                Email = updateCustomerDto.Email,
                Name = updateCustomerDto.Name,
                Phone = updateCustomerDto.Phone,
                Surname = updateCustomerDto.Surname,
            });
            return Ok("Kargo Müşteri Güncelleme işlemi başarılı");
        }
        [HttpDelete]
        public IActionResult CompanyCustomer(int id)
        {
            _cargoCustomerService.BDelete(id);
            return Ok("Kargo Müşteri silme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult CargoCustomer(int id)
        {
            var resultCargoCustomer = _cargoCustomerService.BGetById(id);
            return Ok(resultCargoCustomer);
        }

        [HttpGet]
        public IActionResult CargoCustomer()
        {
            var resultCargoCustomerList = _cargoCustomerService.BGetAll();
            return Ok(resultCargoCustomerList);
        }
    }
}
