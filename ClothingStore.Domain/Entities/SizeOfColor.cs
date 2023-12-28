using ClothingStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public class SizeOfColor : BaseAuditableEntity
    {
        public string Size { get; set; }
      
        public ProductDetail ProductDetail { get; set; }
        public ICollection<ImportOrderDetail>? ImportOdersLink { get; set; }
        public ICollection<OrderDetail> OdersLink { get; set; }
        public ICollection<CartDetail>? CartsLink { get; set; }

    }
}
