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

        public ItemsController()
        {
            _itemConfig = new Configuration.Configurations();
            _itemService = _itemConfig.GetItemService();
            _itemMapper = new ItemMapper(_itemConfig);
        }
        public ActionResult Item(Guid storeItemId)
        {
            ItemVM item = _itemMapper.GetItemByStoreItemId(storeItemId);
            return View(item);
        }
    }
}