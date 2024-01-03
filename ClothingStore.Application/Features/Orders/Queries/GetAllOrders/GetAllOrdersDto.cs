using AutoMapper;
using ClothingStore.Application.Common.Mappings;
using ClothingStore.Domain.Entities;


namespace ClothingStore.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersDto : IMapFrom<Order>
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public PaymentMethodGetOrderDto PaymentMethod { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, GetAllOrdersDto>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(order => order.CreatedDate.HasValue ? order.CreatedDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : ""));
        }
    }
}
