using AutoMapper;
using ClothingStore.Application.Common.Mappings;
using ClothingStore.Application.Features.Products.Queries.GetAllProducts;
using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.DTOs
{
    public class SizeOfColorDto 
    {
      
        public int Quantity { get; set; }
        public string Size { get; set; }
    
    }
}
