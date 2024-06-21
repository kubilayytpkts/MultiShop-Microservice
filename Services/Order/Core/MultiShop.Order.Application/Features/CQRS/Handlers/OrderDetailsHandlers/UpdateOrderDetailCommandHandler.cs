using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailsHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;       
        }

        public async Task Handle(UpdateOrderDetailCommand detailCommand)
        {
            if (detailCommand is not null)
            {
                var value = await _repository.GetByIdAsync(detailCommand.OrderDetailID);

                if(value is not null )
                {
                    value.OrderDetailID = detailCommand.OrderDetailID;
                    value.OrderingID = detailCommand.OrderingID;
                    value.ProductAmount = detailCommand.ProductAmount;
                    value.ProductID = detailCommand.ProductID;
                    value.ProductName = detailCommand.ProductName;
                    value.ProductPrice = detailCommand.ProductPrice;
                    value.ProductTotalPrice = detailCommand.ProductTotalPrice;

                    await _repository.UpdateAsync(value);
                }

            }
        }

    }
}
