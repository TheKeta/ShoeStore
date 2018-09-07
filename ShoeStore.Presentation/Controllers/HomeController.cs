using ShoeShop.Presentation.Interfaces;
using ShoeStore.Configuration;
using ShoeStore.Models;
using ShoeStore.Presentation.Mappers;
using ShoeStore.Presentation.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ShoeStore.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private IItemService _itemService;
        private IStoreService _storeService;
        private IStoreItemService _storeItemService;
        private ItemConfiguration _itemConfig;
        private StoreMapper _storeMapper;

        public HomeController()
        {
            _itemConfig = new ItemConfiguration();
            _itemService = _itemConfig.GetItemService();
            _storeService = _itemConfig.GetStoreService();
            _storeItemService = _itemConfig.GetStoreItemService();
            _storeMapper = new StoreMapper();
        }

        public ActionResult Index()
        {
            ICollection<Store> stores =  _storeService.GetAll();
            ICollection<Item> items = _itemService.GetAll();
            ICollection<StoreItem> storeItems = _storeItemService.GetAll();

            ICollection<StoreVM> storesVM = _storeMapper.InitializeStoreVM(stores, items, storeItems);
            return View(storesVM);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}