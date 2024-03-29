﻿using AutoMapper;
using ClothingStore.Application.Common.Mappings;
using ClothingStore.Domain.Entities;
using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Products.Queries.GetProductDetailById
{
    public class SizeColorDto : IMapFrom<SizeOfColor>
    {
        public int Id { get; set; }

        public string Size { get; set; }
        public int Inventory { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SizeOfColor, SizeColorDto>()
              .ForMember(dest => dest.Inventory, opt => opt.MapFrom(src =>
                    (src.ImportOdersLink != null ? src.ImportOdersLink.Sum(io => io.Quantity) : 0) -
                    (src.OdersLink != null ? src.OdersLink.Where(ol => ol.Oder.Status != "canceled").Sum(od => od.Quantity) : 0)));
        }
    }
}
