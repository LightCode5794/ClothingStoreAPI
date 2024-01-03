using AutoMapper;
using ClothingStore.Application.Common.Mappings;
using ClothingStore.Application.DTOs;
using ClothingStore.Domain.Entities;
using ClothingStore.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Products.Queries.GetProductDetailById
{
    public class GetProductDetailByIdDto : IMapFrom<Product>
    {       
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public string Thumbnail { get; set; }
            public decimal DiscountPercent { get; set; }
            //public decimal FixedPrice { get; set; } = 0;
            public string Status { get; set; }
        
            public string[]? Images { get; set; }
            public List<CategoryInEachProductDto> Categories { get; set; }
            public List<ProductDetailDto> Variations { get; set; }
         

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, GetProductDetailByIdDto>()
                .ForMember(dto => dto.Categories, opt => opt.MapFrom(product => product.CategoriesLink.Select(cl => cl.Category)))
                .ForMember(dto => dto.Variations, opt => opt.MapFrom(product => product.ProductDetails.Select(pd => pd)));
            profile.CreateMap<Category, CategoryInEachProductDto>();           
            profile.CreateMap<ProductDetail, ProductDetailDto>();
               
        }

    }
}
