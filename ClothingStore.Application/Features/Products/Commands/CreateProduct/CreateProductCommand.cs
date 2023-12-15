
using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Domain.Entities;

using MediatR;
using ClothingStore.Shared;
using AutoMapper;

namespace ClothingStore.Application.Features.Products.Commands.CreateProduct
{
    public record CreateProductCommand : IRequest<Result<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int[] CategoryIds { get; set; }
        public string[]? Images { get; set; }

    }
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
   
        public async Task<Result<int>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var linkedCategory = await _unitOfWork.Repository<Category>().GetByIdsAsync(command.CategoryIds);
           

            var newProduct = new Product()
            {
                Name = command.Name,
                Description = command.Description,
                Price = command.Price,
                Images = command.Images,
                CategoriesLink = new List<ProductCategory>()
            };

            linkedCategory.ForEach(lc => 
                newProduct.CategoriesLink.Add(
                    new ProductCategory {
                        Product = newProduct,
                        Category = lc
                    })
            );
           
            // Console.WriteLine(newProduct.CategoriesLink);


            await _unitOfWork.Repository<Product>().AddAsync(newProduct);
            newProduct.AddDomainEvent(new ProductCreatedEvent(newProduct));
            await _unitOfWork.Save(cancellationToken);

            return await Result<int>.SuccessAsync(newProduct.Id, "Product Created");
        }
    }
}