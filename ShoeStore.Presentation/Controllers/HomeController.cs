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
        private ItemMapper _itemMapper;

        public HomeController()
        {
            _itemConfig = new Configuration.Configurations();
            _storeMapper = new StoreMapper(_itemConfig);
            _itemMapper = new ItemMapper(_itemConfig);
        }

        public ActionResult Index()
        {
            HomeModel hm = new HomeModel();
            hm.ItemsVM = _storeMapper.SortByPriceDES();
            return View(hm);
        }

        public ActionResult Ascending()
        {
            HomeModel hm = new HomeModel();
            hm.ItemsVM = _storeMapper.SortByPriceASC();
            return View("Index",hm);
        }

        [HttpPost]
        public ActionResult Search(SearchItem searchItem)
        {
            HomeModel hm = new HomeModel();

            ICollection<ItemVM> items = _itemMapper.Search(searchItem.StoreName, searchItem.Model,
                searchItem.Brand, searchItem.Sex, searchItem.MinPrice, searchItem.MaxPrice, searchItem.Size);
            hm.ItemsVM = items;

            return View("Index", hm);
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