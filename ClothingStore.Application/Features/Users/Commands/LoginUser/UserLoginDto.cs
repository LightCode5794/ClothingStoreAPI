using ClothingStore.Application.Common.Mappings;
using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Features.Users.Commands.LoginUser
{
    public class UserLoginDto : IMapFrom<User>
    {
        public string? Email { get; set; }
        public  string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string? Avatar { get; set; }
        public  int RoleId { get; set; }

       // public ICollection<Food>? FavoriteFoods { get; set; }

     
    }
}
