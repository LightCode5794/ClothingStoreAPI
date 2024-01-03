using AutoMapper;
using ClothingStore.Application.Common.Mappings;
using ClothingStore.Application.Features.Products.Commands.CreateProduct;
using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Domain.Entities;
using ClothingStore.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Orders.Commands.CreateOrder
{
   
        public record CreateOrderCommand : IRequest<Result<int>>
        {
            [Required]
            public ItemDto[] Products { get; set; }
            
            public int UserId { get; set; } = -1;
            [Required]
            public string Email { get; set; } = string.Empty;
            [Required]
            public string FullName { get; set; }
            [Required]
            public string PhoneNumber { get; set; }
            [Required]
            public string Address { get; set; }
            [Required]
            public decimal TotalAmount { get; set; }
            [Required]
            public int PaymentMethodId { get; set; }
        }
        internal class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<Result<int>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
            {

                var paymentMetthod = await _unitOfWork.Repository<PaymentMethod>().GetByIdAsync(command.PaymentMethodId);
                if(paymentMetthod == null) {
                    return Result<int>.Failure( "Payment method not found!");
                }

                var newOder = new Order()
                {
                    Address = command.Address,
                    PhoneNumber = command.PhoneNumber,
                    FullName = command.FullName,
                    Email = command.Email,               
                    ProductsLink = new List<OrderDetail>(),
                    TotalAmount = command.TotalAmount,
                    PaymentMethod = paymentMetthod
                };

                foreach (var item in command.Products)
                {
                    var product = await _unitOfWork.Repository<SizeOfColor>().GetByIdAsync(item.Id);

                    if (product == null) {
                        return Result<int>.Failure("Product not found");
                    }

                    var newOrderDetail = new OrderDetail()
                    {
                        Oder = newOder,
                        SizeOfColor = product,
                        Quantity = item.Quantity,
                    };
                
                   newOder.ProductsLink.Add(newOrderDetail);
                }

                if(command.UserId != -1)
                {
                    var user = await _unitOfWork.Repository<User>().GetByIdAsync(command.UserId);
                    if(user != null)
                    {
                        newOder.Customer = user;
                    }

                }

                await _unitOfWork.Repository<Order>().AddAsync(newOder);
                newOder.AddDomainEvent(new OrderCreatedEvent(newOder));
                await _unitOfWork.Save(cancellationToken);

                return await Result<int>.SuccessAsync(newOder.Id, "Product Created");

         
            }
        }
    
}
