using ClothingStore.Domain.Common;
using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Products.Commands.CreateProduct
{
    public class ProductCreatedEvent : BaseEvent
    {
        public Product Product { get; }
        public ProductCreatedEvent(Product product)
        {
            Product = product;
        }
    }
}
