using ClothingStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public class Cart : BaseAuditableEntity
    {   

        public required int UserId { get; set; }
        public required User User { get; set; } = null!; // Required reference navigation to principal
        public ICollection<CartDetail>? ProductsLink { get; set; }

    }
}
