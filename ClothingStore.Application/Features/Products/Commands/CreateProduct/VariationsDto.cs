using AutoMapper;
using ClothingStore.Application.Common.Mappings;
using ClothingStore.Application.Features.Products.Queries.GetAllProducts;
using ClothingStore.Domain.Entities;
using ClothingStore.Shared;
using MediatR;



namespace ClothingStore.Application.Features.Products.Commands.CreateProduct
{
    public class VariationsDto
    {
        public string Color { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public List<SizeOfColorDto> SizesColor { get; set; }



    }
}
