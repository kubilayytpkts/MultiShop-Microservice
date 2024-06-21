using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAddressCommand update)
        {
            var value = await _repository.GetByIdAsync(update.AddressID);
            if (value is not null)
            {
                value.Detail = update.Detail;
                value.City = update.City;
                value.Discrit = update.Discrit;
                value.UserID = update.UserID;

                await _repository.UpdateAsync(value);
            }
        }

    }
}
