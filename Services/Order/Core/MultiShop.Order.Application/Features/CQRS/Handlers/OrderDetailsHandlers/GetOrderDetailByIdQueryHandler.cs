using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailsQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailsResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailsHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdResult> Handle(GetOrderDetailByIdQuery ID)
        {
            var value = await _repository.GetByIdAsync(ID.ID);

            return new GetOrderDetailByIdResult
            {
                OrderDetailID=value.OrderDetailID,
                OrderingID=value.OrderingID,
                ProductAmount=value.ProductAmount,
                ProductID = value.ProductID,
                ProductName=value.ProductName,
                ProductPrice = value.ProductPrice,
                ProductTotalPrice= value.ProductTotalPrice
            };
        }
    }
}
