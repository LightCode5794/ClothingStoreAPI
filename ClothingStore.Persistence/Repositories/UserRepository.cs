using ClothingStore.Application.Interfaces.Repositories;
using ClothingStore.Application.Interfaces.Repositories.GenericRepository;
using ClothingStore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IGenericRepository<User> _repository;
        public UserRepository(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

    }
}
