using ClothingStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ClothingStore.Domain.Entities
{
    public class Category : BaseAuditableEntity
    {
      
        public required string Name { get; set; }
        public ICollection<ProductCategory>? ProductsLink { get; set; }
    }
}
