using AutoMapper;
using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Application.Libratires;
using ClothingStore.Domain.Entities;
using ClothingStore.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Orders.Commands.UpdateStatusOrder
{

    public record UpdateStatusOrderCommand : IRequest<Result<int>>
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        [RegularExpression("pending|completed|canceled", ErrorMessage = "Invalid status. Valid values are 'pending', completed or'canceled'.")]
        public string Status { get; set; }

        public UpdateStatusOrderCommand() { 
          
        }

    }

    internal class UpdateStatusOrderCommandHandler : IRequestHandler<UpdateStatusOrderCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateStatusOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(UpdateStatusOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Repository<Order>().GetByIdAsync(command.OrderId);

            if (order == null)
            {
               
               return await Result<int>.FailureAsync("Order not found");
            }
            if(order.Status == command.Status)
            {
                return await Result<int>.FailureAsync("Status of this order already exists in the database");
            }
            
            order.Status = command.Status;
            await _unitOfWork.Repository<Order>().UpdateAsync(order);
            await _unitOfWork.Save(cancellationToken);
            return  await Result<int>.SuccessAsync("Order status changed");

        }
    }
}
