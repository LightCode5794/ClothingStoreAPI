using ClothingStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public class ImportOrder : BaseAuditableEntity
    { 
        public required Product Product { get; set; }
        
        public decimal? TotalAmount { get; set; }

        public required ICollection<ImportOrderDetail> ProductsDetailsLink { get; set; }

    }
}
