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
using Microsoft.AspNetCore.Http.HttpResults;
using ClothingStore.Application.Common.Exceptions;

namespace ClothingStore.Application.Features.Users.Commands.CreateUser
{
    public record CreateUserCommand : IRequest<Result<int>>, IMapFrom<User>
    {
        public required string FullName { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required string Gender { get; set; }
        public required int RoleId {  get; set; } 

    }
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            
            var role = _unitOfWork.Repository<Role>().Entities.FirstOrDefault(s => s.Id == command.RoleId) ?? throw new BadRequestException();


            string passwordHash = BCrypt.Net.BCrypt.HashPassword(command.Password);


            var user = new User()
            {
                FullName = command.FullName,
                Password = passwordHash,
                PhoneNumber = command.PhoneNumber,
                Email = command.Email,
                Role = role,
                Gender = command.Gender,
               
            };

            await _unitOfWork.Repository<User>().AddAsync(user);
            user.AddDomainEvent(new UserCreatedEvent(user));

            await _unitOfWork.Save(cancellationToken);

            return await Result<int>.SuccessAsync(user.Id, "User Created.");
        }

    }
}