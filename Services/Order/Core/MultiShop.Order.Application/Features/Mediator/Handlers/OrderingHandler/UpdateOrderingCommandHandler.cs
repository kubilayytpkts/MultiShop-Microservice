using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommand;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandler
{
    internal class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;
        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.OrderingID);

            if (request is not null)
            {
                value.OrderDate = request.OrderDate;
                value.OrderingID = request.OrderingID;
                value.TotalPrice = request.TotalPrice;
                value.UserID = request.UserID;
            }

            await _repository.UpdateAsync(value);
        }
    }
}
