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
    public class DeleteOrderingHandler
    {
        private readonly IRepository<Ordering> _repository;

        public DeleteOrderingHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handler(DeleteOrderingCommand delete)
        {
            var result = await _repository.GetByIdAsync(delete.ID);

            if(result is not null)
                await _repository.DeleteAsync(result);
        }
    }
}
