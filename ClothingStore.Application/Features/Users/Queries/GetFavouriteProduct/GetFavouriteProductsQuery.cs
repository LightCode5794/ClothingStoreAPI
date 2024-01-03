using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Domain.Entities;
using ClothingStore.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Application.Features.Users.Queries.GetFavouriteProduct
{
    public record GetFavouriteProductsQuery : IRequest<Result<List<GetFavouriteProductsDto>>>
    {
        public int Id { get; set; }
        public GetFavouriteProductsQuery(int id)
        {
            Id = id;
        }


    };

    internal class GetFavouriteProductsQueryHandler : IRequestHandler<GetFavouriteProductsQuery, Result<List<GetFavouriteProductsDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFavouriteProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetFavouriteProductsDto>>> Handle(GetFavouriteProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.Repository<Product>().Entities
                 .Where(p => p.Status != "deleted")
                   .Include(p => p.FavoriteUsersLink)
                   .Where(p => p.FavoriteUsersLink.Any(f => f.UserId == query.Id))
                   .ProjectTo<GetFavouriteProductsDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);

            return await Result<List<GetFavouriteProductsDto>>.SuccessAsync(products);
        }
    }
}
