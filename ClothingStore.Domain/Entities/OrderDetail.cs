﻿using ClothingStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public class OrderDetail 
    {
        public int OderId { get; set; }
        public int SizeOfColorId { get; set; }
        public required SizeOfColor SizeOfColor{ get; set; }
        public required Order Oder { get; set; }
        public required int Quantity { get; set; }
        public  Voucher? Voucher { get; set; }
      

    }
}
