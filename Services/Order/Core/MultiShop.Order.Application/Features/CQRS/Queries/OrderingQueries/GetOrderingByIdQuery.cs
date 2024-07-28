using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.OrderingQueries
{
    public class GetOrderingByIdQuery
    {
        public int ID { get; set; }

        public GetOrderingByIdQuery(int id)
        {
            ID = id;
        }
    }
}
