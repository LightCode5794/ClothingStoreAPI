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

namespace ClothingStore.Application.Features.Users.Queries.GetAllUsers
{
    public record GetAllUsersQuery : IRequest<Result<List<UserDto>>>;

    internal class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Result<List<UserDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<UserDto>>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.Repository<User>().Entities
                   .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);

            return await Result<List<UserDto>>.SuccessAsync(users);
        }
    }
}
