using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public class CartDetail
    {
        public int CartId { get; set; }
        public int SizeOfColorId { get; set; }
        public required int Quantity { get; set; }
        public required SizeOfColor SizeOfColor { get; set; }
        public required Cart Cart { get; set; }
 
    }
}
