using ClothingStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public class Review : BaseAuditableEntity
    {

        public required int UserId { get; set; }
        public required int ProductId { get; set; }
        public required int OrderId { get; set; }
        public string? Comment { get; set; }
        [Range(1, 5)]
        public required int Rating { get; set; }
        public string[]? Images { get; set; }

        public required Order Order { get; set; } = null!; // Required reference navigation to principal
        public required User User { get; set; }
        public required Product Product { get; set; }

    }

}
