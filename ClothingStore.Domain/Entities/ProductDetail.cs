using ClothingStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public class ProductDetail : BaseAuditableEntity
    {
        public string Size { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;

        public string Image {  get; set; } = string.Empty;
        public required Product Product { get; set; }
        public ICollection<CartDetail>? CartsLink { get; set; }
        public ICollection<OrderDetail> OdersLink { get; set; }
        public ICollection<ImportOrderDetail>? ImportOdersLink { get; set; }
     
    }
}
