using ShoeStore.Presentation.Mappers;
using ShoeStore.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeStore.Presentation.Controllers
{
    public class SearchController : Controller
    {
        private Configuration.Configurations _itemConfig;
        private ItemMapper _itemMapper;

        public SearchController()
        {
            _itemConfig = new Configuration.Configurations();
            _itemMapper = new ItemMapper(_itemConfig);
        }

        public ActionResult Search()
        {
            ICollection<ItemVM> items = _itemMapper.Search("N", "9", "Nike", "Male");
            return View(items);
        }
    }
}