﻿using ShoeShop.Presentation.Interfaces;
using ShoeStore.Models;
using ShoeStore.Presentation.Mappers;
using ShoeStore.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeStore.Presentation.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private IUserService _userService;
        private Configuration.Configurations _itemConfig;
        private CartMapper _cartMapper;

        public CartController()
        {
            _itemConfig = new Configuration.Configurations();
            _userService = _itemConfig.GetUserService();
            _cartMapper = new CartMapper();
        }

        public ActionResult MyItems()
        {
            return View((ICollection<ItemVM>)Session["cart"]);
        }

        public ActionResult Order()
        {
            User u = Session["userId"] == null ? new Models.User() : _userService.FindById((Guid)Session["userId"]);
            return View(u);
        }

        [HttpPost]
        public ActionResult Order(User user)
        {
            //save delivery?
            _cartMapper.ResetCart(Session);
            return Redirect("/");
        }
    }
}