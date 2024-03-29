﻿using ClothingStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public class FavoriteProduct : BaseAuditableEntity
    {
        public  int UserId { get; set; }
        public  int ProductId { get; set; }
        public required User User { get; set; }
        public required Product Product { get; set; }
    }
}
