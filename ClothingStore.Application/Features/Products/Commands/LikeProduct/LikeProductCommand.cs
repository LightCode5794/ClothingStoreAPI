
using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Domain.Entities;
using MediatR;
using ClothingStore.Shared;
using AutoMapper;
using ClothingStore.Application.Common.Mappings;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using ClothingStore.Application.Features.Products.Queries.GetAllProducts;

namespace ClothingStore.Application.Features.Products.Commands.LikeProduct
{
    public record LikeProductCommand : IRequest<Result<int>>
    {
        public required int ProductId { get; set; }
        public required int UserId { get; set; }
     
    }
    internal class LikeProductCommandHandler : IRequestHandler<LikeProductCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LikeProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
   
        public async Task<Result<int>> Handle(LikeProductCommand command, CancellationToken cancellationToken)

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

            
            //product.FavoriteUsersLink ??= new List<FavoriteProduct>();

           
            product.FavoriteUsersLink.Add(new FavoriteProduct
            {
                User = user,
                Product = product,
            });
            await _unitOfWork.Repository<Product>().UpdateAsync(product);
            product.AddDomainEvent(new ProductLikedEvent(product));
            await _unitOfWork.Save(cancellationToken);

            return await Result<int>.SuccessAsync($"user {user.Id} liked product {product.Id}");
        }
    }
}