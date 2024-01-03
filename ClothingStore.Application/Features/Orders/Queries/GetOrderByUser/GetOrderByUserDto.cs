using AutoMapper;
using ClothingStore.Application.Common.Mappings;
using ClothingStore.Application.DTOs;
using ClothingStore.Application.Features.Products.Queries.GetAllProducts;
using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Orders.Queries.GetOrderByUser
{
    public class GetOrderByUserDto  :IMapFrom<Order>
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<OrderProductsDto> Products  { get; set; }
        public PaymentMethodGetOrderDto PaymentMethod { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, GetOrderByUserDto>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(order => order.CreatedDate.HasValue ? order.CreatedDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : ""))
           .ForMember(dest => dest.Products, opt => opt.MapFrom(order => order.ProductsLink));
           
               
            

        }
    }
}
