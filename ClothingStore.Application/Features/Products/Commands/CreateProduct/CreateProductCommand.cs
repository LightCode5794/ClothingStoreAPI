
using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Domain.Entities;

using MediatR;
using ClothingStore.Shared;
using AutoMapper;
using ClothingStore.Application.Common.Mappings;
using ClothingStore.Application.Features.Products.Queries.GetAllProducts;

namespace ClothingStore.Application.Features.Products.Commands.CreateProduct
{
    public record CreateProductCommand : IRequest<Result<int>>, IMapFrom<Product>
    {
        public string Name { get; set; }
       public string Description { get; set; }
        public decimal Price { get; set; }
        public string Thumbnail { get; set; }
        public decimal DiscountPercent { get; set; }
        //public decimal FixedPrice { get; set; } = 0;
        public string Status { get; set; }
        public int[] Categories { get; set; }
        public string[]? Images { get; set; }
        public List<VariationsDto> Variations { get; set; }
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

            var linkedCategory = await _unitOfWork.Repository<Category>().GetByIdsAsync(command.Categories);


            if(linkedCategory == null)
            {
                return await Result<int>.FailureAsync("Categories id not found");
            }

           
                var newProduct = new Product()
                {
                    Name = command.Name,
                    Description = command.Description,
                    Price = (decimal)command.Price,
                    Images = command.Images,
                    Thumbnail = command.Thumbnail,
                    DiscountPercent = command.DiscountPercent,
                    //FixedPrice = command.FixedPrice,
                    Status = command.Status,
                    CategoriesLink = new List<ProductCategory>(),
                    ProductDetails = new List<ProductDetail>(),
                    ImportOrders = new List<ImportOrder>(),

                };

                linkedCategory.ForEach(lc =>
                    newProduct.CategoriesLink.Add(
                        new ProductCategory
                        {
                            Product = newProduct,
                            Category = lc
                        })
                );

                var importOder = new ImportOrder()
                {
                    Product = newProduct,
                    ProductsDetailsLink = new List<ImportOrderDetail>(),
                    TotalAmount = 0

                };

                foreach (var pd in command.Variations)
                {
                    var newPd = new ProductDetail()
                    {
                        Image = pd.Image,
                        Color = pd.Color,
                        Product = newProduct,
                        Price = pd.Price ,
                        Sizes = new List<SizeOfColor>(),

                    };

                    foreach (var item in pd.SizesColor)
                    {

                        var newSize = new SizeOfColor()
                        {
                            Size = item.Size,
                            ProductDetail = newPd,
                            ImportOdersLink = new List<ImportOrderDetail>()

                        };
                        var newImportOderDetail = new ImportOrderDetail()
                        {
                            Quantity = (int)item.Quantity,
                            SizeOfColor = newSize,
                            ImportOder = importOder,

                        };
                        importOder.TotalAmount += newProduct.Price * newImportOderDetail.Quantity;
                        newSize.ImportOdersLink.Add(newImportOderDetail);
                        newPd.Sizes.Add(newSize);
                        importOder.ProductsDetailsLink.Add(newImportOderDetail);
                    }

                    newProduct.ProductDetails.Add(newPd);

                }

                newProduct.ImportOrders.Add(importOder);

                await _unitOfWork.Repository<Product>().AddAsync(newProduct);


                newProduct.AddDomainEvent(new ProductCreatedEvent(newProduct));
                await _unitOfWork.Save(cancellationToken);

                return await Result<int>.SuccessAsync(newProduct.Id, "Product Created");
            
           
            // return await Result<int>.SuccessAsync(newProduct.Id, "Product Created");
        }
    }
}