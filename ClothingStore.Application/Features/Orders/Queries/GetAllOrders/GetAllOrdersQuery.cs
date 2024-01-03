using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClothingStore.Application.Features.Orders.Queries.GetOrderByUser;
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

namespace ClothingStore.Application.Features.Orders.Queries.GetAllOrders
{

    public record GetAllOrdersQuery : IRequest<Result<List<GetAllOrdersDto>>>;

    internal class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, Result<List<GetAllOrdersDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork, IOrderRepository orderRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllOrdersDto>>> Handle(GetAllOrdersQuery query, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.Repository<Order>().Entities
                .ProjectTo<GetAllOrdersDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

  

            return await Result<List<GetAllOrdersDto>>.SuccessAsync(orders);
        }
    }
}
