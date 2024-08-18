using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using MultiShop.Cargo.BusinessLogicLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using MultiSop.Cargo.DtosLayer.CargoDetailDtos;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;
        public CargoDetailController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpPost]
        public IActionResult CargoDetail(AddCargoDetailDto addCargoDetail)
        {
            _cargoDetailService.BInsert(new CargoDetail
            {
                Barcode = addCargoDetail.Barcode,
                CargoCompanyId = addCargoDetail.CargoCompanyId,
                ReceiverCustomer = addCargoDetail.ReceiverCustomer,
                SenderCustomer = addCargoDetail.ReceiverCustomer,
            });
            return Ok("Kargo Detay ekleme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult CargoDetail(UpdateCargoDetailDto updateCargoDetail)
        {
            _cargoDetailService.BUpdate(new CargoDetail
            {
                Barcode = updateCargoDetail.Barcode,
                CargoCompanyId = updateCargoDetail.CargoCompanyId,
                CargoDetailId = updateCargoDetail.CargoDetailId,
                ReceiverCustomer = updateCargoDetail.ReceiverCustomer,
                SenderCustomer = updateCargoDetail.ReceiverCustomer,
            });

            return Ok("Kargo Detay güncelleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult CargoDetail(int id)
        {
            _cargoDetailService.BDelete(id);
            return Ok("Kargo Detay silme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetail(int id)
        {
            var resultCargoDetail = _cargoDetailService.BGetById(id);
            return Ok(resultCargoDetail);
        }

        [HttpGet]
        public IActionResult CargoDetail()
        {
            var resultCargoDetailList = _cargoDetailService.BGetAll();
            return Ok(resultCargoDetailList);
        }

    }
}
