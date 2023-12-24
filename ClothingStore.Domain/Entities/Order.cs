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

        [RegularExpression("pending|completed|canceled", ErrorMessage = "Invalid status. Valid values are 'pending', completed or'canceled'.")]
        public string Status { get; set; } = "pending";
        public required User Customer { get; set; } 
        public ICollection<OrderDetail>? ProductsLink { get; set; }

        public Review? Review { get; set; }
        public required Transaction Transaction { get; set; }
        public Voucher? Voucher { get; set; }
    }
}
