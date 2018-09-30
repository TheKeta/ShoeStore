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
        public List<AvailableSize> AvailableSizes { get; set; }
        public AvailableSize SelectedAverableSize { get; set; }
        public ICollection<HttpPostedFileBase> Images { get; set; }
        public ICollection<string> ImagesBit { get; set; }
    }
}