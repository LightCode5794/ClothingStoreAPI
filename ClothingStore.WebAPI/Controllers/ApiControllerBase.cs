using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {

    }
}
