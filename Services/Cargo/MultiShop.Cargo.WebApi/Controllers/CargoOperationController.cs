using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLogicLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using MultiSop.Cargo.DtosLayer.CargoOperationDtos;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpPost]
        public IActionResult CargoOperation(AddCargoOperationDto addCargoOperation)
        {
            _cargoOperationService.BInsert(new CargoOperations
            {
                Barcode = addCargoOperation.Barcode,
                Description = addCargoOperation.Description,
                OperationDate = addCargoOperation.OperationDate
            });
            return Ok("Kargo Operasyon ekleme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult CargoOperation(UpdateCargoOperationDto updateCargoOperation)
        {
            _cargoOperationService.BUpdate(new CargoOperations
            {
                Barcode= updateCargoOperation.Barcode,
                Description= updateCargoOperation.Description,
                CargoOperationId = updateCargoOperation.CargoOperationId,
                OperationDate = updateCargoOperation.OperationDate
            });
            return Ok("Kargo Operasyon güncelleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult CargoOperation(int id)
        {
            _cargoOperationService.BDelete(id);
            return Ok("Kargo Silme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperation(int id)
        {
            var resultCargoOperation = _cargoOperationService.BGetById(id);
            return Ok(resultCargoOperation);    
        }

        [HttpGet]
        public IActionResult CargoOperation()
        {
            var resultCargoOperation = _cargoOperationService.BGetAll();
            return Ok(resultCargoOperation);
        }

    }
}
