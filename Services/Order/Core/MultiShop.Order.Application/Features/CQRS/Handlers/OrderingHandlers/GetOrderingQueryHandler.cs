using MultiShop.Order.Application.Features.CQRS.Results.OrderingResults;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers
{
    public class GetOrderingQueryHandler
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderingQueryResult>> Handler()
        {
            var result = await _repository.GetAllAsync();

            return result.Select(x => new GetOrderingQueryResult
            {
                OrderingID = x.OrderingID,
                OrderDate = x.OrderDate,
                TotalPrice = x.TotalPrice,
                UserID =x.UserID,
            }).ToList();
        }
    }
}
