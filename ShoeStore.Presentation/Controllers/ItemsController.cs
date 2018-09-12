using ShoeShop.Presentation.Interfaces;
using ShoeStore.Configuration;
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
    public class ItemsController : Controller
    {
        private Configuration.Configurations _itemConfig;
        private IItemService _itemService;
        private ItemMapper _itemMapper;
        private CartMapper _cartMapper;

        public ItemsController()
        {
            _itemConfig = new Configuration.Configurations();
            _itemService = _itemConfig.GetItemService();
            _itemMapper = new ItemMapper(_itemConfig);
            _cartMapper = new CartMapper();
        }
        public ActionResult Item(Guid storeItemId)
        {
            ItemVM item = _itemMapper.GetItemByStoreItemId(storeItemId);
            return View(item);
        }

        [HttpPost]
        public ActionResult Item(ItemVM item)
        {
            //add to cart
            _cartMapper.AddItemToCart(item, Session);
            ItemVM oldItem = _itemMapper.GetItemByStoreItemId(item.StoreItemId);
            return View(oldItem);
        }
    }
}