using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;

        public AddressesController(CreateAddressCommandHandler createAddressCommandHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler = null, GetAddressQueryHandler getAddressQueryHandler = null, RemoveAddressCommandHandler removeAddressCommandHandler = null, UpdateAddressCommandHandler updateAddressCommandHandler = null)
        {
            _createAddressCommandHandler = createAddressCommandHandler;
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _getAddressQueryHandler = getAddressQueryHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand address)
        {
            await _createAddressCommandHandler.Handle(address);
            return Ok("Ekleme İşlemi başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand address)
        {
            await _updateAddressCommandHandler.Handle(address);
            return Ok("Günceleme İşlemi başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet]
        public async Task<IActionResult> ListAllAddress()
        {
            var value =await _getAddressQueryHandler.Handle();
            return Ok(value);
        }
            
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var value = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(value);
        }

    }
}
