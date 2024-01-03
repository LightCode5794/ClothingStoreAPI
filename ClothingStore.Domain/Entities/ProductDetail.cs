using ClothingStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public class ProductDetail : BaseAuditableEntity
    {
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string Image {  get; set; } 
        public required Product Product { get; set; }
        public  ICollection<SizeOfColor> Sizes { get; set; }
        
    }
}
