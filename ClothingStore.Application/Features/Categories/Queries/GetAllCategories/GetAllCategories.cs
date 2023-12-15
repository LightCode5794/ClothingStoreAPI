using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Domain.Entities;
using ClothingStore.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Application.Features.Categories.Queries.GetAllCategories
{
    public record GetAllCategories : IRequest<Result<List<GetAllCategoriesDto>>>;
    internal class GetAllCategoriesHandler : IRequestHandler<GetAllCategories, Result<List<GetAllCategoriesDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllCategoriesDto>>> Handle(GetAllCategories query, CancellationToken cancellationToken)
        {
            var categories = await _unitOfWork.Repository<Category>().Entities
                   .ProjectTo<GetAllCategoriesDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);

            return await Result<List<GetAllCategoriesDto>>.SuccessAsync(categories);
        }
    }
}
