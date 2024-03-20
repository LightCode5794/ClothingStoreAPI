using ClothingStore.Domain.Common;
using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Categories.Commands.UpdateCategory
{

    public class CategoryUpdatedEvent : BaseEvent
    {
        public Category Category { get; }
        public CategoryUpdatedEvent(Category category)
        {
            Category = category;
        }
    }
}
