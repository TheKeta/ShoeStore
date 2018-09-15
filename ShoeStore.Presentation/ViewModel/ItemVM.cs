using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeStore.Presentation.ViewModel
{
    public class ItemVM : Item
    {
        public string StoreName { get; set; }
        public Guid StoreItemId { get; set; }
        public double Price { get; set; }
        public List<AveableSize> AveableSizes { get; set; }
        public AveableSize SelectedAverableSize { get; set; }
    }
}