using ClothingStore.Domain.Common;

namespace ClothingStore.Domain.Entities
{
    public class Category : BaseAuditableEntity
    {
      
        public string Name { get; set; }
        public ICollection<ProductCategory>? ProductsLink { get; set; }
    }
}
