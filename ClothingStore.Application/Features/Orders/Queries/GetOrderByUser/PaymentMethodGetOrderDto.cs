using ClothingStore.Application.Common.Mappings;
using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Orders.Queries.GetOrderByUser
{
    public class PaymentMethodGetOrderDto : IMapFrom<PaymentMethod>
    {
        public int Id { get; set; }
        public string Name { get; set; }


    }
}
