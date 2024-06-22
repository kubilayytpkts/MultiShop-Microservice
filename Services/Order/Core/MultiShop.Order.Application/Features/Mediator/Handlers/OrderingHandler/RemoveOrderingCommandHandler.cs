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
    public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommmand>
    {
        private readonly IRepository<Ordering> _repository;

        public RemoveOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderingCommmand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ID);

            if (value is not null)
            {
                await _repository.DeleteAsync(value);
            }
        }
    }
}
