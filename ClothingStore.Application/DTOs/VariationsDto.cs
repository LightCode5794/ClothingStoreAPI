using AutoMapper;
using ClothingStore.Application.Common.Mappings;
using ClothingStore.Application.Features.Products.Queries.GetAllProducts;
using ClothingStore.Domain.Entities;
using ClothingStore.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.DTOs
{
    public class VariationsDto 
    {
        public string Color { get; set; }
        public string Image { get; set; }
        public List<SizeOfColorDto> SizesColor { get; set; }
        



    }
}
