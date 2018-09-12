using ShoeStore.Models;
using System;

namespace ShoeShop.Presentation.Interfaces
{
    public interface IUserService
    {

        User Add(User user);
        bool Remove(User userID);
        void Update(User user);
        User FindUser(User user);
        User FindById(Guid id);
    }
}
