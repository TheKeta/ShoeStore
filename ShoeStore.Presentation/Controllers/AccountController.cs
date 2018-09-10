using ShoeShop.Presentation.Interfaces;
using ShoeStore.Presentation.Mappers;
using ShoeStore.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeStore.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private Configuration.Configurations _itemConfig;
        private IUserService _userService;
        private UserMapper _userMapper;
        public AccountController()
        {
            _itemConfig = new Configuration.Configurations();
            _userService = _itemConfig.GetUserService();
            _userMapper = new UserMapper();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View(new UserVM());
        }

        [HttpPost]
        public ActionResult Register(UserVM user)
        {
            if (ModelState.IsValid)
            {
                _userService.Add(_userMapper.ConvertToUser(user));
                return Redirect("/");
            }
            return View();
        }
        
        private bool ValidUser(UserVM user)
        {
            if(string.IsNullOrWhiteSpace( user.FirstName))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(user.LastName))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(user.Address))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(user.Password))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(user.PasswordConfirmation))
            {
                return false;
            }
            if (!user.Password.Equals(user.PasswordConfirmation))
            {
                return false;
            }
            return true;
        }
    }
}