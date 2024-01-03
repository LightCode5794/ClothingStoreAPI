﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Orders.Commands.CreateOrder
{
    public class ItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
   
    }
}
