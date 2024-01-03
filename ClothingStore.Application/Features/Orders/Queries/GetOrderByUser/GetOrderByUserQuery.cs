using AutoMapper;
using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Orders.Queries.GetOrderByUser
{

    public record GetOrderByUserQuery : IRequest<Result<List<GetOrderByUserDto>>>
    {
        public int UserId { get; set; }

        public GetOrderByUserQuery()
        {

        }

        public GetOrderByUserQuery(int userId)
        {
            UserId = userId;
        }
    }

    internal class GetOrderByUserQueryHandler : IRequestHandler<GetOrderByUserQuery, Result<List<GetOrderByUserDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderByUserQueryHandler(IUnitOfWork unitOfWork, IOrderRepository orderRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<GetOrderByUserDto>>> Handle(GetOrderByUserQuery query, CancellationToken cancellationToken)
        {
            var entities = await _orderRepository.GetOrdersByUserAsync(query.UserId);
            var orders = _mapper.Map<List<GetOrderByUserDto>>(entities);

            return await Result<List<GetOrderByUserDto>>.SuccessAsync(orders);
        }
    }
}
