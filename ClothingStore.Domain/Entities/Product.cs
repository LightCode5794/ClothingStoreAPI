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
        public string Thumnail { get; set; }
        public string[]? Images { get; set; }
        [EnumDataType(typeof(StautusProduct))]
        public StautusProduct Status { get; set; } = StautusProduct.PENDING;
        public ICollection<FavoriteProduct>? FavoriteUsersLink { get; set; }
        public ICollection<Review>? UserReviews { get; set; }
        public ICollection<ProductDetail> ProductDetails { get; set; }
        public ICollection<ProductCategory> CategoriesLink { get; set; }
    }
}
