using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Interfaces.Repositories
{
    public interface IOrderRepository
    {
       Task<List<Order>> GetOrdersByUserAsync(int userId);
       
    }
}
