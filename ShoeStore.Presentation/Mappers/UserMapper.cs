using ShoeStore.Models;
using ShoeStore.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeStore.Presentation.Mappers
{
    public class UserMapper
    {
        public User ConvertToUser(UserVM user)
        {
            return new User()
            {
                Address = user.Address,
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                Password = user.Password
            };
        }
    }
}