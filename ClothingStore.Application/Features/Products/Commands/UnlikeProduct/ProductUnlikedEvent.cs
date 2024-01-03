using ClothingStore.Domain.Common;
using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Products.Commands.UnlikeProduct
{
    internal class ProductUnlikedEvent : BaseEvent
    {
        public Product Product { get; }
        public ProductUnlikedEvent(Product product)
        {
            Product = product;
        }
    }

}
