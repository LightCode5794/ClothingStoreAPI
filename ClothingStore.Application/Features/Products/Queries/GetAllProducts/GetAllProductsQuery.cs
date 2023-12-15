using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Domain.Entities;
using ClothingStore.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Products.Queries.GetAllProducts
{
    public record GetAllProductsQuery : IRequest<Result<List<GetAllProductDto>>> { 
    
    
    
    };

    internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, Result<List<GetAllProductDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllProductDto>>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.Repository<Product>().Entities
                   .ProjectTo<GetAllProductDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);
         

            

            return await Result<List<GetAllProductDto>>.SuccessAsync(products);
        }
    }
}
