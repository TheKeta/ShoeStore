using ShoeShop.Presentation.Interfaces;
using ShoeStore.Configuration;
using ShoeStore.Models;
using System.Web.Mvc;

namespace ShoeStore.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private IItemService _itemService;
        private ItemConfiguration _itemConfig;
        public HomeController()
        {
            _itemConfig = new ItemConfiguration();
            _itemService = _itemConfig.GetItemService();
        }

        public ActionResult Index()
        {
            //Item item = new Item()
            //{
            //    Brand = "Nike",
            //    Description = "Letnje patike",
            //    Model = "R90",
            //    Sex = "Muske"
            //};
            //_itemService.Add(item);
            return View();
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