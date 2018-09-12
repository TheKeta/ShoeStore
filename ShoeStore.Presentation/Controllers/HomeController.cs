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
        private Configuration.Configurations _itemConfig;
        private StoreMapper _storeMapper;

        public HomeController()
        {
            _itemConfig = new Configuration.Configurations();
            _storeMapper = new StoreMapper(_itemConfig);
        }

        public ActionResult Index()
        {
            ICollection<ItemVM> itemsVM = _storeMapper.SortByPriceDES();
            return View(itemsVM);
        }

        public ActionResult Ascending()
        {
            ICollection<ItemVM> itemsVM = _storeMapper.SortByPriceASC();
            return View("Index",itemsVM);
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