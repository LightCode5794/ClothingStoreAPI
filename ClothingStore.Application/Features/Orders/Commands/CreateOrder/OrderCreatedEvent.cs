using ClothingStore.Domain.Common;
using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Orders.Commands.CreateOrder
{
    public class OrderCreatedEvent : BaseEvent
    {
        public Order Order { get; }
        public OrderCreatedEvent(Order order)
        {
            Order = order;
        }
    }
}
