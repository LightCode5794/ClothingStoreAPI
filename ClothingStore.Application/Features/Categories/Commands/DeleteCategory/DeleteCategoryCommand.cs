using AutoMapper;
using ClothingStore.Application.Common.Mappings;
using ClothingStore.Application.Features.Categories.Commands.UpdateCategory;
using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Domain.Entities;
using ClothingStore.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Categories.Commands.DeleteCategory
{

    public record DeleteCategoryCommand : IRequest<Result<int>>, IMapFrom<Category>
    {
        public int CategoryId { get; set; }
        public DeleteCategoryCommand()
        {

        }
        public DeleteCategoryCommand(int id)
        {
            CategoryId = id;
        }
        internal class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<Result<int>> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
            {

                var category = await _unitOfWork.Repository<Category>().GetByIdAsync(command.CategoryId);
                if (category == null)
                {
                    return Result<int>.Failure("Category not found");
                }

                try
                {

                    await _unitOfWork.Repository<Category>().DeleteAsync(category);
                    await _unitOfWork.Save(cancellationToken);

                    return Result<int>.Success(category.Id, "Category detelted");
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi và trả về đối tượng kết quả thất bại
                    return Result<int>.Failure(ex.Message);
                }
            }

        }

    }
}
