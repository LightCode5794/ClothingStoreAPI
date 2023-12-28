using AutoMapper;
using ClothingStore.Application.Common.Exceptions;
using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Domain.Entities;
using ClothingStore.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ClothingStore.Application.Features.Users.Commands.LoginUser
{
    public record LoginUserCommand : IRequest<Result<string>> {
       
        public string Email { get; set; }
        public string Password { get; set; }
        public SymmetricSecurityKey? PrivateKeyJwt { get; set; }
        
    };

    internal class LoginUserQueryQueryHandler : IRequestHandler<LoginUserCommand, Result<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LoginUserQueryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<string>> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
           

            var userEntity = await _unitOfWork.Repository<User>().Entities.FirstOrDefaultAsync(u => u.Email == command.Email, cancellationToken: cancellationToken);

            Console.WriteLine(userEntity);
            if(userEntity == null)
            {
                return Result<string>.Failure("User not found");
            };
           

            if(!BCrypt.Net.BCrypt.Verify(command.Password, userEntity.Password))
             {

                 return Result<string>.Failure("Wrong password");
             }
             // var user = _mapper.Map<UserLoginDto>(userEntity);
             string token = CreateToken(userEntity, command.PrivateKeyJwt);

             //return token;
             return await Result<string>.SuccessAsync(token, "Login succesful");
        }

        private string CreateToken(User user, SymmetricSecurityKey key)
        {
            List<Claim> claims = new()
            {
                new Claim("id", user.Id.ToString()),
                new Claim("email", user.Email ),
                new Claim("name", user.FullName ),
                
            };
            

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }

       
    }
}
