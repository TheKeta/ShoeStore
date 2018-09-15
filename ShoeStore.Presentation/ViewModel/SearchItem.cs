using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeStore.Presentation.ViewModel
{
    public class SearchItem : Item
    {
        public double MaxPrice { get; set; }
        public double MinPrice { get; set; }
        public string StoreName { get; set; }
        public double Size { get; set; }
    }
}