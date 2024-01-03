using ClothingStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public class Product : BaseAuditableEntity
    {
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;

        //[Column(TypeName = "Money")]
        public required decimal Price { get; set; } = 0;
        public string Thumbnail { get; set; }
        public string[]? Images { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal FixedPrice { get; set; } = 0;

        [RegularExpression("pending|published|deleted", ErrorMessage = "Invalid status. Valid values are 'pending' or 'published'.")]
        public string Status { get; set; } = "pending";

        public ICollection<ImportOrder> ImportOrders { get; set; }
        public ICollection<FavoriteProduct> FavoriteUsersLink { get; set; }
        public ICollection<Review> UserReviews { get; set; }
        public ICollection<ProductDetail> ProductDetails { get; set; }
        public ICollection<ProductCategory> CategoriesLink { get; set; }
    }
}
