using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeStore.Presentation.ViewModel
{
    public class StoreVM : Store
    {
        public ICollection<ItemVM> Items { get; set; }
    }
}