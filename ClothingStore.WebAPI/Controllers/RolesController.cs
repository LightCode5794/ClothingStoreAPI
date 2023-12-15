using ClothingStore.Application.Features.Roles.Commands.CreateRole;
using ClothingStore.Application.Features.Roles.Queries.GetAllRole;
using ClothingStore.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.WebAPI.Controllers
{
    public class RolesController : ApiControllerBase 
    {


        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateRoleCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<RoleDto>>>> Get()
        {
            return await _mediator.Send(new GetAllRolesQuery());
        }
    }
}
