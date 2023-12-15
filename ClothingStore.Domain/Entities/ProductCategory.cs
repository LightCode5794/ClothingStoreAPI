using ClothingStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{

    public class ProductCategory : BaseAuditableEntity
    {
        public  int ProductId { get; set; }
        public  int CategoryId { get; set; }
        public  Product Product { get; set; }
        public  Category Category { get; set; }
    }
}
