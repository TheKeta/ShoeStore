using ShoeStore.Models;
using ShoeStore.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeStore.Presentation.Mappers
{
    public class ItemMapper
    {
        public ItemVM ConvertToVM(Item item, double price, string storeName, Guid stID)
        {
            return new ItemVM()
            {
                Brand = item.Brand,
                Description = item.Description,
                Id = item.Id,
                Model = item.Model,
                Sex = item.Sex,
                Price = price,
                StoreName = storeName,
                StoreItemId = stID
            };
        }

        //public ICollection<ItemVM> ConvertToVM(ICollection<Item> items,string storeName)
        //{
        //    ICollection<ItemVM> _items = new List<ItemVM>();
        //    foreach(Item i in items)
        //    {
        //        _items.Add(ConvertToVM(i,2.2, storeName)); //HARD
        //    }
        //    return _items;
        //}
    }
}