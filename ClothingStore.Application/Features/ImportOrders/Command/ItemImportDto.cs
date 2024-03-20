using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.ImportOrders.Command
{
    public class ItemImportDto
    {
      
        public int? Id { get; set; }
        [Required]
        public int Quantity { get; set; }
       
        public int ColorId { get; set; }
        public string? Image { get; set; }
    }
}
