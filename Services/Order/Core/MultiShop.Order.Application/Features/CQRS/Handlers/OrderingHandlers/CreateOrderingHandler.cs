using MultiShop.Order.Application.Features.CQRS.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers
{
    public class CreateOrderingHandler
    {
        private readonly IRepository<Ordering> _repository;

        public CreateOrderingHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handler(CreateOrderCommand command)
        {
            await _repository.CreateAsync(new Ordering
            {
                OrderDate = command.OrderDate,
                TotalPrice = command.TotalPrice,
                UserID = command.UserID,
            });

        }
    }
}
