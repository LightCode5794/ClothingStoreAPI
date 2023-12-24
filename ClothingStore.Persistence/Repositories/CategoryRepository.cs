using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Application.Interfaces.Repositories.GenericRepository;
using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IGenericRepository<Category> _repository;

        public CategoryRepository(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }

        public Task<List<Category>> GetCategorysByClubAsync(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
