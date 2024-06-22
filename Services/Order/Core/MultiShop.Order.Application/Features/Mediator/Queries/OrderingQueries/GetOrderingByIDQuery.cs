﻿using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByIDQuery : IRequest<GetOrderingByIdResult>
    {
        public int ID { get; set; }

        public GetOrderingByIDQuery(int id)
        {
            ID = id;
        }
    }
}
