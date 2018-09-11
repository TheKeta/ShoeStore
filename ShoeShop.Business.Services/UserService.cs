using ShoeShop.Business.Interfaces;
using ShoeShop.Presentation.Interfaces;
using ShoeStore.Business.Services;
using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Business.Services
{
    public class UserService : IUserService
    {
        private PasswordService _passwordService;
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _passwordService = new PasswordService();
        }
        public User Add(User user)
        {
            user.Id = Guid.NewGuid();
            user.Password = _passwordService.HashPassword(user.Password);
            return _userRepository.Add(user);
        }

        public User FindUser(User user)
        {
            user.Password = _passwordService.HashPassword(user.Password);
            return _userRepository.FindUser(user);
        }

        public bool Remove(User userID)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
