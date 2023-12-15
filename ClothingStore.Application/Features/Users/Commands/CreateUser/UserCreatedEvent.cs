using ClothingStore.Domain.Common;
using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Users.Commands.CreateUser
{
    public class UserCreatedEvent : BaseEvent
    {
        public User User { get; }

        public UserCreatedEvent(User user)
        {
            User = user;
        }
    }
}
