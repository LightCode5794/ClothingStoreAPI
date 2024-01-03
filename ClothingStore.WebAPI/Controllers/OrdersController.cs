using ClothingStore.Application.Features.Categories.Commands.CreateCategory;
using ClothingStore.Application.Features.Orders.Commands.CreateOrder;
using ClothingStore.Application.Features.Orders.Commands.PayOrder;
using ClothingStore.Application.Features.Orders.Commands.ValidateOrderPayment;
using ClothingStore.Application.Features.Orders.Queries.GetAllOrders;
using ClothingStore.Application.Features.Orders.Queries.GetOrderByUser;
using ClothingStore.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.WebAPI.Controllers
{
    public class OrdersController : ApiControllerBase
    {

        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateOrderCommand command)
        {
           
            return await _mediator.Send(command);
        }


        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllOrdersDto>>>> GetAll()
        {
         
            return await _mediator.Send(new GetAllOrdersQuery());
        }

        [HttpPost]
        [Route("create-url-payment")]
        public async Task<ActionResult<Result<string>>> GeneratePaymentUrl(CreatePayOrderUrlCommand command)
        {

            return await _mediator.Send(command);
        }
        [HttpPost]
        [Route("validate")]
        public async Task<ActionResult<Result<bool>>> GeneratePaymentUrl(ValidateOrderPaymentCommand command)
        {

            return await _mediator.Send(command);
        }

        [HttpGet]
        [Route("user/{userId}")]
        public async Task<ActionResult<Result<List<GetOrderByUserDto>>>> GetOdersByUser(int userId)
        {

            return await _mediator.Send(new GetOrderByUserQuery(userId));
        }
    }
}
