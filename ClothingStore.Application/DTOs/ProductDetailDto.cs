using AutoMapper;
using ClothingStore.Application.Common.Mappings;
using ClothingStore.Application.Features.Products.Queries.GetProductDetailById;
using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.DTOs
{
    public class ProductDetailDto : IMapFrom<ProductDetail>
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public List<SizeColorDto> SizesColor { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductDetail, ProductDetailDto>()
                .ForMember(dto => dto.SizesColor, opt => opt.MapFrom(p => p.Sizes.Select(s => s)));                       
            profile.CreateMap<SizeOfColor, SizeColorDto>();

        }


    }
}
