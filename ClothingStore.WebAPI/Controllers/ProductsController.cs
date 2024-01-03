
using ClothingStore.Application.Features.Products.Commands.CreateProduct;
using ClothingStore.Application.Features.Products.Commands.LikeProduct;
using ClothingStore.Application.Features.Products.Commands.UnlikeProduct;
using ClothingStore.Application.Features.Products.Queries.CheckProductLikeByUser;
using ClothingStore.Application.Features.Products.Queries.GetAllProducts;
using ClothingStore.Application.Features.Products.Queries.GetProductDetailById;
using ClothingStore.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        public async Task<ActionResult<Result<GetProductDetailByIdDto>>> GetProductById(int id)
        {
            return await _mediator.Send(new GetProductDetailByIdQuery(id));
        }

       
        [HttpPost]
        [Route("{id}/like")]
        public async Task<ActionResult<Result<int>>> Like( int id, [FromQuery][Required] int userId)
        {
            var command = new LikeProductCommand
            {
                ProductId = id,
                UserId = userId,
            };

            return await _mediator.Send(command);
        }

        [HttpGet]
        [Route("{id}/isLiked")]
        public async Task<ActionResult<Result<bool>>> IsLike(int id, [FromQuery][Required] int userId)
        {
            var request = new CheckProductLikedByUserQuery
            {
                ProductId = id,
                UserId = userId,
            };

            return await _mediator.Send(request);
        }

        [HttpPost]
        [Route("{id}/unlike")]
        public async Task<ActionResult<Result<int>>> Unlike(int id, [FromQuery][Required] int userId)
        {
            var command = new UnlikeProductCommand
            {
                ProductId = id,
                UserId = userId,
            };

            return await _mediator.Send(command);
        }
    }
}
