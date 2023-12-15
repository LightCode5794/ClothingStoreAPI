using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingStore.Domain.Common;

namespace ClothingStore.Domain.Entities
{
    public class User : BaseAuditableEntity
    {
        public string Email { get; set; } = string.Empty;
        public required string FullName { get; set; }
        public  string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public string Avatar { get; set; } = string.Empty;
        public required string Address { get; set; } = string.Empty;
        public required Role Role { get; set; }
        public ICollection<FavoriteProduct>? FavoriteProductsLink { get; set; }
        public ICollection<Review>? ProductReviews { get; set; }
        public Cart Cart { get; set; }
        public ICollection<Order>? OdersList { get; set; }
    }
}
