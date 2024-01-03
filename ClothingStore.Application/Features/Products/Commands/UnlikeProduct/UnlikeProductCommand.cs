using AutoMapper;
using ClothingStore.Application.Features.Products.Commands.LikeProduct;
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

namespace ClothingStore.Application.Features.Products.Commands.UnlikeProduct
{
    
    public record UnlikeProductCommand : IRequest<Result<int>>
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }

    }
    internal class UnlikeProductCommandHandler : IRequestHandler<UnlikeProductCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UnlikeProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UnlikeProductCommand command, CancellationToken cancellationToken)

        {
            var user = await _unitOfWork.Repository<User>().GetByIdAsync(command.UserId);
            if (user == null)
            {
                return Result<int>.Failure("User not found");
            }

            var product = await _unitOfWork.Repository<Product>().Entities
             .Include(p => p.FavoriteUsersLink)
             .Where(p => p.Id == command.ProductId)
             .FirstAsync(cancellationToken: cancellationToken);

            if (product == null)
            {
                return Result<int>.Failure("Product not found");
            }

            var favariteProductToRemove = product.FavoriteUsersLink.Single(u => u.UserId == command.UserId);

            if (favariteProductToRemove is null)
            {
                return Result<int>.Failure("Data not found");
            }

            product.FavoriteUsersLink.Remove(favariteProductToRemove);
         
            await _unitOfWork.Repository<Product>().UpdateAsync(product);
            product.AddDomainEvent(new ProductUnlikedEvent(product));
            await _unitOfWork.Save(cancellationToken);
            return await Result<int>.SuccessAsync($"user {user.Id} unliked product {product.Id}");
        }
    }
}
