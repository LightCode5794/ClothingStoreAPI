﻿using ClothingStore.Application.Features.Categories.Commands.CreateCategory;
using ClothingStore.Application.Features.Categories.Queries.GetAllCategories;
using ClothingStore.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.WebAPI.Controllers
{
    public class CategoriesController : ApiControllerBase
    {

        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create( CreateCategoryCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllCategoriesDto>>>> Get()
        {
            return await _mediator.Send(new GetAllCategories());
        }
    }
}
