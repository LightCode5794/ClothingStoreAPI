using ClothingStore.Domain.Common;
using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.ImportOrders.Command
{
    public class ImportOrderCreatedEvent : BaseEvent
    {
        public ImportOrder ImportOrder { get;  }
        public ImportOrderCreatedEvent( ImportOrder importOrder ) { 
            ImportOrder = importOrder;
        }
    }
}
