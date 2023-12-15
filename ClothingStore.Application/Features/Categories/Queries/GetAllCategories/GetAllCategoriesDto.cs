using ClothingStore.Application.Common.Mappings;
using ClothingStore.Domain.Entities;


namespace ClothingStore.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesDto : IMapFrom<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
