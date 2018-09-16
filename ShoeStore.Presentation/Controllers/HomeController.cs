using PagedList;
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
        private static SearchItem _searchItem;

        public HomeController()
        {
            _itemConfig = new Configuration.Configurations();
            _storeMapper = new StoreMapper(_itemConfig);
            _itemMapper = new ItemMapper(_itemConfig);
        }

        public ActionResult Index(string search, int? page)
        {
            HomeModel hm = new HomeModel();
            if (string.IsNullOrWhiteSpace(search))
            {
                hm.ItemsVM = _storeMapper.SortByPriceDES().ToPagedList(page ?? 1, 3);
                return View(hm);
            }
            ICollection<ItemVM> items = _itemMapper.Search(_searchItem.StoreName, _searchItem.Model,
                _searchItem.Brand, _searchItem.Sex, _searchItem.MinPrice, _searchItem.MaxPrice, _searchItem.Size);
            hm.ItemsVM = items.ToPagedList(page ?? 1, 3);

            return View("Index", hm);
        }

        public ActionResult Ascending(string search, int? page)
        {
            HomeModel hm = new HomeModel();
            if (string.IsNullOrWhiteSpace(search))
            {
                hm.ItemsVM = _storeMapper.SortByPriceASC().ToPagedList(page ?? 1, 3);
                return View("Index", hm);
            }
            ICollection<ItemVM> items = _itemMapper.Search(_searchItem.StoreName, _searchItem.Model,
                _searchItem.Brand, _searchItem.Sex, _searchItem.MinPrice, _searchItem.MaxPrice, _searchItem.Size, "DSC");
            hm.ItemsVM = items.ToPagedList(page ?? 1, 3);

            return View("Index", hm);

        }

        [HttpPost]
        public ActionResult Search(SearchItem searchItem)
        {
            HomeModel hm = new HomeModel();

            ICollection<ItemVM> items = _itemMapper.Search(searchItem.StoreName, searchItem.Model,
                searchItem.Brand, searchItem.Sex, searchItem.MinPrice, searchItem.MaxPrice, searchItem.Size);
            hm.ItemsVM = items.ToPagedList(1, 3);
            _searchItem = searchItem;
            return View("Index", hm);
        }

        public ActionResult Search(int? page)
        {
            HomeModel hm = new HomeModel();

            ICollection<ItemVM> items = _itemMapper.Search(_searchItem.StoreName, _searchItem.Model,
                _searchItem.Brand, _searchItem.Sex, _searchItem.MinPrice, _searchItem.MaxPrice, _searchItem.Size);
            hm.ItemsVM = items.ToPagedList(page ?? 1, 3);

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