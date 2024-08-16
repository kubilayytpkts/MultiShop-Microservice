using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailsResults;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommand;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrdering(CreateOrderingCommand ordering)
        {
            await _mediator.Send(ordering);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand ordering)
        {
            await _mediator.Send(ordering);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommmand(id));
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderings()
        {
            var value = await _mediator.Send(new GetOrderingQuery());
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(int id)
        {
            var value = await _mediator.Send(new GetOrderingByIDQuery(id));
            return Ok(value);
        }
        //REGİSTİR
    }
}
