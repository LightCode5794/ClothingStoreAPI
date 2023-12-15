using ClothingStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public class PaymentMethod : BaseAuditableEntity
    {
        public required string Name {  get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
    }
}
