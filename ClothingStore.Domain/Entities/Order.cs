using ClothingStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{

    public class Order : BaseAuditableEntity
    {
        public required string Address { get; set; }

        [EnumDataType(typeof(StatusOder))]
        public StatusOder Status { get; set; } = StatusOder.PENDING;
        public required User Customer { get; set; } 
        public ICollection<OrderDetail>? ProductsLink { get; set; }

        public Review? Review { get; set; }
        public required Transaction Transaction { get; set; }
        public Voucher? Voucher { get; set; }
    }
}
