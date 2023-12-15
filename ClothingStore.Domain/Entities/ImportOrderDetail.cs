using ClothingStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public class ImportOrderDetail 
    {
        public int ImportOderId { get; set; }
        public int ProductDetailId { get; set; }
        public required ProductDetail ProductDetail { get; set; }
        public required ImportOrder ImportOder { get; set; }
        public required int Quantity { get; set; }
        public Voucher? Voucher { get; set; }
    }
}
