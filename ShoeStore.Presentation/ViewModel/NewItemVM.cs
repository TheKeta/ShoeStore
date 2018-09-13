using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeStore.Presentation.ViewModel
{
    public class NewItemVM
    {
        public ItemVM Item { get; set; }
        public ICollection<Item> AllItems { get; set; }

        public NewItemVM()
        {
            Item = new ItemVM();
            AllItems = new List<Item>();
        }
    }
}