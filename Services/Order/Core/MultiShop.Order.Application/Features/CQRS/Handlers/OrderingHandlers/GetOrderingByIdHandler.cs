using MultiShop.Order.Application.Features.CQRS.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers
{
    public class GetOrderingByIdHandler
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingByIdHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }


        public async Task<GetOrderingByIdResult> Handler(GetOrderingByIdQuery query)
        {
            var result = await _repository.GetByIdAsync(query.ID);

            return new GetOrderingByIdResult
            {
              OrderingID= result.OrderingID,
              OrderDate=result.OrderDate,
              UserID=result.UserID,
              TotalPrice = result.TotalPrice,
            };
        }
    }
}
