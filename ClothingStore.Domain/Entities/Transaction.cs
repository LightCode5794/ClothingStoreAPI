using ClothingStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public class Transaction :BaseAuditableEntity
    {
   
     
        public int OrderId { get; set; }
        public required Order Order { get; set; } = null!; // Required reference navigation to principal
        public required PaymentMethod PaymentMethod { get; set; }
        public decimal TotalAmount { get; set; }


    }
}
