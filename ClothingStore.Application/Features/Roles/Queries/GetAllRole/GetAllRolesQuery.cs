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

namespace ClothingStore.Application.Features.Roles.Queries.GetAllRole
{
    public record GetAllRolesQuery : IRequest<Result<List<RoleDto>>>;

    internal class GetAllUsersQueryHandler : IRequestHandler<GetAllRolesQuery, Result<List<RoleDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<RoleDto>>> Handle(GetAllRolesQuery query, CancellationToken cancellationToken)
        {
            var roles = await _unitOfWork.Repository<Role>().Entities
                   .ProjectTo<RoleDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);

            return await Result<List<RoleDto>>.SuccessAsync(roles);
        }
    }
}
