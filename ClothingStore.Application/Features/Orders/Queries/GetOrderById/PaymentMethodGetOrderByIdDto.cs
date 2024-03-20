using ClothingStore.Application.Common.Mappings;
using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Orders.Queries.GetOrderById
{
    public class PaymentMethodGetOrderByIdDto : IMapFrom<PaymentMethod>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
