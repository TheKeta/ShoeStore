using ShoeShop.Presentation.Interfaces;
using ShoeStore.Configuration;
using ShoeStore.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ShoeStore.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private IItemService _itemService;
        private IStoreService _storeService;
        private ItemConfiguration _itemConfig;
        public HomeController()
        {
            _itemConfig = new ItemConfiguration();
            _itemService = _itemConfig.GetItemService();
            _storeService = _itemConfig.GetStoreService();
        }

        public ActionResult Index()
        {
            IEnumerable<Store> stores =  _storeService.GetAll();
            return View(stores);
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