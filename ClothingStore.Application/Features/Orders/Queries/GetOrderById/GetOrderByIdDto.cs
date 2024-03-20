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
    public class GetOrderByIdDto : IMapFrom<Order>
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public List<OrderProductsDto> Products { get; set; }
        public PaymentMethodGetOrderByIdDto PaymentMethod { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, GetOrderByIdDto>()
                 .ForMember(dest => dest.Products, opt => opt.MapFrom(order => order.ProductsLink))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(order => order.CreatedDate.HasValue ? order.CreatedDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : ""));
            profile.CreateMap<OrderDetail, OrderProductsDto>();
        }
    }
}
