
using ClothingStore.Application.Features.Products.Commands.CreateProduct;
using ClothingStore.Application.Features.Products.Queries.GetAllProducts;
using ClothingStore.Application.Features.Products.Queries.GetProductDetailById;
using ClothingStore.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.WebAPI.Controllers
{
    public class ProductsController : ApiControllerBase
    {


        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateProductCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet]
        
        public async Task<ActionResult<Result<List<GetAllProductDto>>>> Get()
        {
            return await _mediator.Send(new GetAllProductsQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<GetProductDetailByIdDto>>> GetPlayersById(int id)
        {
            return await _mediator.Send(new GetProductDetailByIdQuery(id));
        }
    }
}
