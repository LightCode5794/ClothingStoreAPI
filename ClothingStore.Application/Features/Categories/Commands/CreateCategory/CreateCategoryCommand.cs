﻿using AutoMapper;
using ClothingStore.Application.Common.Mappings;
using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Domain.Entities;
using ClothingStore.Shared;
using MediatR;



namespace ClothingStore.Application.Features.Categories.Commands.CreateCategory
{
    public record CreateCategoryCommand : IRequest<Result<int>>, IMapFrom<Category>
    {
        public string Name { get; set; }

    }
    internal class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {

            var category = new Category()
            {
                Name = command.Name,
            };

            await _unitOfWork.Repository<Category>().AddAsync(category);
            category.AddDomainEvent(new CreateCategoryEvent(category));
            await _unitOfWork.Save(cancellationToken);

            Console.WriteLine(category.Id);
            Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");


            return await Result<int>.SuccessAsync(category.Id, "Category Created");
        }

    }
}