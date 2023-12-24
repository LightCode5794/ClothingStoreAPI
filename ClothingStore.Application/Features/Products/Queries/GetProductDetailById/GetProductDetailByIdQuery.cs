using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClothingStore.Application.DTOs;
using ClothingStore.Application.Features.Products.Queries.GetAllProducts;
using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Domain.Entities;
using ClothingStore.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ClothingStore.Application.Features.Products.Queries.GetProductDetailById
{
    public record GetProductDetailByIdQuery : IRequest<Result<GetProductDetailByIdDto>>
    {
        public  int  Id { get; set; }
        public GetProductDetailByIdQuery(int id)
        {
            Id = id;
        }
    }

    internal class GetProductDetailByIdQueryHandler : IRequestHandler<GetProductDetailByIdQuery, Result<GetProductDetailByIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        

        public GetProductDetailByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;
        }

        public async Task<Result<GetProductDetailByIdDto>> Handle(GetProductDetailByIdQuery request, CancellationToken cancellationToken)
        {


            /* var product = await _unitOfWork.Repository<Product>().Entities           
             .Where(p => p.Status != "deleted" && p.Id == request.Id)
             .Include(p => p.ProductDetails)
                 .ThenInclude(pd => pd.Sizes)
                     .ThenInclude(s => s.ImportOdersLink)
             .Include(p => p.ProductDetails)
                  .ThenInclude(pd => pd.Sizes)
                     .ThenInclude(s => s.OdersLink)                        
             //.ProjectTo<GetProductDetailByIdDto>(_mapper.ConfigurationProvider)
             .FirstOrDefaultAsync(cancellationToken);
             Console.WriteLine(product);*/


            // product.Variations = new List<VariationsDto>();



            var product = await _unitOfWork.Repository<Product>().Entities
                    .Where(p => p.Status != "deleted" && p.Id == request.Id)
                    .ProjectTo<GetProductDetailByIdDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken);
       
            return await Result<GetProductDetailByIdDto>.SuccessAsync(product);
        }
    }
}
