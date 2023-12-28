using ClothingStore.Shared;
using ClothingStore.Application.Features.Users.Commands.CreateUser;
using ClothingStore.Application.Features.Users.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ClothingStore.Application.Features.Users.Commands.LoginUser;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ClothingStore.WebAPI.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public UsersController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<Result<string>>> Login(LoginUserCommand command)
        {

            var secret = Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!);
           
            var key = new SymmetricSecurityKey(secret);

            if(key == null)
            {
                return NotFound("Not found the private key");
            }
            var newCommand = new LoginUserCommand()
            {   
                PrivateKeyJwt = key,
                Email = command.Email,
                Password = command.Password,

            };
            return await _mediator.Send(newCommand);
        }



        /* [HttpGet]
        [Route("paged")]
        public async Task<ActionResult<PaginatedResult<GetPlayersWithPaginationDto>>> GetPlayersWithPagination([FromQuery] GetPlayersWithPaginationQuery query)
        {
            var validator = new GetPlayersWithPaginationValidator();

            // Call Validate or ValidateAsync and pass the object which needs to be validated
            var result = validator.Validate(query);

            if (result.IsValid)
            {
                return await _mediator.Send(query);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages); 
        } */
        [HttpGet]
        public async Task<ActionResult<Result<List<UserDto>>>> Get()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }


        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }

        

        /* [HttpPut("{id}")]
         public async Task<ActionResult<Result<int>>> Update(int id, UpdateUserCommand command)
         {
             if (id != command.Id)
             {
                 return BadRequest();
             }

             return await _mediator.Send(command); 
         }

         [HttpDelete("{id}")]
         public async Task<ActionResult<Result<int>>> Delete(int id)
         {
             return await _mediator.Send(new DeleteUserCommand(id)); 
         }*/
    }
}
