using AutoMapper;
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

namespace ClothingStore.Application.Features.Products.Queries.CheckProductLikeByUser
{

    public record CheckProductLikedByUserQuery : IRequest<Result<bool>>
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }

    internal class CheckProductLikedByUserQueryHandler : IRequestHandler<CheckProductLikedByUserQuery, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public CheckProductLikedByUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;
        }

        public async Task<Result<bool>> Handle(CheckProductLikedByUserQuery request, CancellationToken cancellationToken)
        {

            var favourite = await _unitOfWork.Repository<FavoriteProduct>().Entities
                    .Where(f => f.ProductId == request.ProductId && f.UserId == request.UserId)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);

          

            if (favourite is null)
            {
                return await Result<bool>.SuccessAsync(false, $"user {request.UserId} not like {request.ProductId}");
            }

            return await Result<bool>.SuccessAsync(true, $"user {request.UserId} liked {request.ProductId}");
        }
    }
}
