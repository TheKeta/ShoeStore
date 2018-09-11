using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Business.Interfaces
{
    public interface IUserRepository
    {
        User Add(User user);
        bool Remove(User userID);
        void Update(User user);
        User FindUser(User user);
    }
}
