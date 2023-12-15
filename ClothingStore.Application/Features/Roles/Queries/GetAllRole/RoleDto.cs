using ClothingStore.Application.Common.Mappings;
using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Roles.Queries.GetAllRole
{
    public class RoleDto : IMapFrom<Role>
    {
        public string Name { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<Permission>? Permissions { get; set; }
    }
}
