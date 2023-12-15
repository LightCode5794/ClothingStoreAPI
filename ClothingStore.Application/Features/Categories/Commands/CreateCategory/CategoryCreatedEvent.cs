using ClothingStore.Domain.Common;
using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
namespace ClothingStore.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryEvent : BaseEvent
    {
        public Category Category { get; }
        public CreateCategoryEvent(Category category)
        {
            Category = category;
        }
    }
}
