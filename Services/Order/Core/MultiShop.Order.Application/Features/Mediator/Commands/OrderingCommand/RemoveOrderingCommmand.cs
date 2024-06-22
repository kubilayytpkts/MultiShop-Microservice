using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommand
{
    public class RemoveOrderingCommmand : IRequest
    {
        public int ID { get; set; }

        public RemoveOrderingCommmand(int id)
        {
            ID = id;
        }
    }
}
