using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeStore.Presentation.ViewModel
{
    public class HomeModel
    {
        public SearchItem SearchModel { get; set; }
        public ICollection<ItemVM> ItemsVM { get; set; }
        public HomeModel()
        {
            SearchModel = new SearchItem();
            ItemsVM = new List<ItemVM>();
        }
    }
}