
using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Domain.Entities;
using MediatR;
using ClothingStore.Shared;
using AutoMapper;
using ClothingStore.Application.Common.Mappings;


namespace ClothingStore.Application.Features.Products.Commands.LikeProduct
{
    public record LikeProductCommand : IRequest<Result<int>>, IMapFrom<Product>
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
     
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
             return await Result<int>.SuccessAsync("liked");
        }
    }
}