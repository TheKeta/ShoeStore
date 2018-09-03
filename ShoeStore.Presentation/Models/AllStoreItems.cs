using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeStore.Presentation.Models
{
    public class AllStoreItems : Store
    {
        public IEnumerable<Item> Items { get; set; }
    }
}