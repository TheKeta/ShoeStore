using ShoeStore.Models;

namespace ShoeShop.Presentation.Interfaces
{
    public interface IUserService
    {

        User Add(User user);
        bool Remove(User userID);
        void Update(User user);
        User FindUser(User user);
    }
}
