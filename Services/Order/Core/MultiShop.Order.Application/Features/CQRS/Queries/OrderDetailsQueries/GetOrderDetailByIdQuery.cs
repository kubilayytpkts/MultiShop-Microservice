using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailsQueries
{
    public class GetOrderDetailByIdQuery
    {
        public int ID { get; set; }

        public GetOrderDetailByIdQuery(int id)
        {
            ID = id;
        }
    }
}
