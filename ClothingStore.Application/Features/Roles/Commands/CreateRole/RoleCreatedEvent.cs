using ClothingStore.Domain.Common;
using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Roles.Commands.CreateRole
{
    public class RoleCreatedEvent : BaseEvent
    {
        public Role Role { get; }

        public RoleCreatedEvent(Role role)
        {
            Role = role;
        }
    }
}
