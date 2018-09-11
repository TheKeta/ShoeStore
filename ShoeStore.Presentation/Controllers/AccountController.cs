using ShoeShop.Presentation.Interfaces;
using ShoeStore.Models;
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

        public ActionResult Login()
        {
            return View(new UserVM());
        }

        [HttpPost]
        public ActionResult Login(UserVM user)
        {
            if(!string.IsNullOrWhiteSpace(user.Email) && !string.IsNullOrWhiteSpace(user.Password))
            {
                User u = _userService.FindUser(_userMapper.ConvertToUser(user));
                if (u == null)
                {
                    ModelState.AddModelError("", "Email and password does not match.");
                    return View();
                }
                Session["userId"] = u.Id;
                Session["userName"] = u.FirstName;
                return Redirect("/");
            }
            ModelState.AddModelError("", "Fill all fields.");
            return View();
        }
    }
}