using ClothingStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public class Voucher : BaseAuditableEntity
    {
        public string? Code { get; set; }
        public decimal DiscountPercentage { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set;}
        public ICollection<Order>? OdersUsed { get; set; }
    }
}
