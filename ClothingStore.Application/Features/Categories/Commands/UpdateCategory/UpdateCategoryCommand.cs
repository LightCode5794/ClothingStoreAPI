using AutoMapper;
using ClothingStore.Application.Common.Mappings;
using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Domain.Entities;
using ClothingStore.Shared;
using MediatR;


namespace ClothingStore.Application.Features.Categories.Commands.UpdateCategory
{
 
    public record UpdateCategoryCommand : IRequest<Result<int>>, IMapFrom<Category>
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public UpdateCategoryCommand()
        {
           
        }
       

    }
    internal class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {

            var category = await _unitOfWork.Repository<Category>().GetByIdAsync(command.Id);
            if(category == null)
            {
                return Result<int>.Failure( "Category not found");
            }

            try
            {
                category.Name = command.Name;
                await _unitOfWork.Save(cancellationToken);

                return Result<int>.Success(category.Id, "Category updated");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về đối tượng kết quả thất bại
                return Result<int>.Failure(ex.Message);
            }
        }

    }
}
