﻿using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandler
{
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIDQuery, GetOrderingByIdResult>
    {
        private readonly IRepository<Ordering> _repository;
        public GetOrderingByIdQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderingByIdResult> Handle(GetOrderingByIDQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ID);
            
            return new GetOrderingByIdResult
            {
                OrderDate = value.OrderDate,
                OrderingID = value.OrderingID,
                TotalPrice = value.TotalPrice,
                UserID = value.UserID,
            };
        }
    }
}
