using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommand;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers
{
    public class UpdateOrderingHandler
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handler(UpdateOrderingCommand command)
        {
            var result =await _repository.GetByIdAsync(command.OrderingID);
            if (result is not null)
            {
                _repository.UpdateAsync(new Ordering
                {
                    OrderDate = command.OrderDate,
                    TotalPrice = command.TotalPrice,
                    UserID = command.UserID,
                });
            }
            
        }
    }
}
