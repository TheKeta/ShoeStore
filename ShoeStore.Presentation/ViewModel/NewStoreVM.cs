using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeStore.Presentation.ViewModel
{
    public class NewStoreVM
    {
        public StoreVM Store { get; set; }
        public ICollection<Store> AllStores { get; set; }
        public ItemVM ItemToAdd { get; set; }
        public NewStoreVM()
        {
            Store = new StoreVM();
            AllStores = new List<Store>();
            ItemToAdd = new ItemVM();
        }
    }
}