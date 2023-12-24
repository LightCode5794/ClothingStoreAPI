using AutoMapper;
using ClothingStore.Application.Common.Mappings;
using ClothingStore.Application.DTOs;
using ClothingStore.Domain.Common;
using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductDto : IMapFrom<Product>
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string[]? Images { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal FixedPrice { get; set; }
        public string Status { get; set; }
        public string Thumbnail { get; set; }
        public List<CategoryInEachProductDto> Categories { get; set; }

        public void Mapping(Profile profile)
        {
             profile.CreateMap<Product, GetAllProductDto>()
                 .ForMember(dto => dto.Categories, opt => opt.MapFrom(product => product.CategoriesLink.Select(cl => cl.Category)));
             profile.CreateMap<Category, CategoryInEachProductDto>();
        }
            


    }
}
