using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderingCommands
{
    public class DeleteOrderingCommand
    {
        public int ID { get; set; }

        public DeleteOrderingCommand(int id)
        {
            ID = id;
        }

    }
}
