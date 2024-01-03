using ClothingStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{

    public class Order : BaseAuditableEntity
    {
        public string Address { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal TotalAmount { get; set; }

        [RegularExpression("pending|completed|canceled", ErrorMessage = "Invalid status. Valid values are 'pending', completed or'canceled'.")]
        public string Status { get; set; } = "pending";
        
        public  User Customer { get; set; } 
        public ICollection<OrderDetail> ProductsLink { get; set; }

        public Review? Review { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        //public Transaction? Transaction { get; set; }
        public Voucher? Voucher { get; set; }
    }
}
