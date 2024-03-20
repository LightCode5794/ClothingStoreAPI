using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClothingStore.Application.Features.Orders.Queries.GetAllOrders;
using ClothingStore.Application.Features.Products.Queries.GetProductDetailById;
using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Domain.Entities;
using ClothingStore.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Orders.Queries.GetOrderById
{
    public record GetOrderByIdQuery : IRequest<Result<GetOrderByIdDto>>
    {
        public int Id { get; set; }
        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }

    internal class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Result<GetOrderByIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IUnitOfWork unitOfWork, IOrderRepository orderRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Result<GetOrderByIdDto>> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Repository<Order>().Entities
                .Where(o => o.Id == query.Id)
                .ProjectTo<GetOrderByIdDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if(order == null)
            {
                return  Result<GetOrderByIdDto>.Failure("Order not found!");
            }


            return await Result<GetOrderByIdDto>.SuccessAsync(order);
        }


    }

}
