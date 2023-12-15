﻿using ClothingStore.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Common
{
    public abstract class BaseAuditableEntity : BaseEntity, IAuditableEntity
    {
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now.ToUniversalTime();
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; } = DateTime.Now.ToUniversalTime();
    }
}
