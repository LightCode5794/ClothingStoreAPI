﻿using ClothingStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public class ImportOrderDetail : BaseAuditableEntity
    {
        public int ImportOderId { get; set; }
        public int SizeOfColorId { get; set; }
        //public int UnitPrice { get; set; }
        public required SizeOfColor SizeOfColor { get; set; }
        public required ImportOrder ImportOder { get; set; }
        public required int Quantity { get; set; }
        public Voucher? Voucher { get; set; }
    }
}
