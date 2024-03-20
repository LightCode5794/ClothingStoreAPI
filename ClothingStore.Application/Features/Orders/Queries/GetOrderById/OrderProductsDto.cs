using AutoMapper;
using ClothingStore.Application.Common.Mappings;
using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Orders.Queries.GetOrderById
{
    public class OrderProductsDto :  IMapFrom<OrderDetail>
    {
        public int SizeColorId { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public int ColorId { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderDetail, OrderProductsDto>()
                .ForMember(dest => dest.SizeColorId, opt => opt.MapFrom(p => p.SizeOfColorId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.SizeOfColor.Size))
                .ForMember(dest => dest.ColorId, opt => opt.MapFrom(src => src.SizeOfColor.ProductDetail.Id))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.SizeOfColor.ProductDetail.Color))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.SizeOfColor.ProductDetail.Image))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.SizeOfColor.ProductDetail.Product.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.SizeOfColor.ProductDetail.Product.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.SizeOfColor.ProductDetail.Product.Price));
        }
    }
}
