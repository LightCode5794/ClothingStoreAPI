using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Domain.Entities;
using ClothingStore.Application.Common.Mappings;
using MediatR;
using ClothingStore.Shared;
using AutoMapper;

namespace ClothingStore.Application.Features.Roles.Commands.CreateRole
{
    public record CreateRoleCommand : IRequest<Result<int>>, IMapFrom<Role>
    {
        public required string Name { get; set; }
        /*
        public ICollection<User>? Users { get; set; }
        public ICollection<Permission>? Permissions { get; set; }*/

    }
    internal class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(CreateRoleCommand command, CancellationToken cancellationToken)
        {
           
          
            var role = new Role()
            {
                Name = command.Name,
            };

            await _unitOfWork.Repository<Role>().AddAsync(role);
            role.AddDomainEvent(new RoleCreatedEvent(role));

            await _unitOfWork.Save(cancellationToken);

            return  await Result<int>.SuccessAsync(role.Id, "Role Created.");
        }

    }
}
