using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeStore.Presentation.ViewModel
{
    public class ItemVM : Item
    {
        public string StoreName { get; set; }
        public Guid StoreItemId { get; set; }
        public double Price { get; set; }
    }
}