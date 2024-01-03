using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Application.Interfaces.Repositories.GenericRepository;
using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly IGenericRepository<Order> _repository;

        public OrderRepository(IGenericRepository<Order> repository)
        {
            _repository = repository;
        }

       
        public async Task<List<Order>> GetOrdersByUserAsync(int userId)
        {
            return await _repository.Entities
                .Include(o => o.Customer)
                .Where(o => o.Customer.Id == userId)
                .Include(o => o.PaymentMethod)
                .Include(o => o.ProductsLink)
                .ThenInclude(od => od.SizeOfColor)
                .ThenInclude(s => s.ProductDetail)
                .ThenInclude(pd => pd.Product)
                .ToListAsync();
        }
    }
}
