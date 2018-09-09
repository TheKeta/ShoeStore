using ShoeShop.Presentation.Interfaces;
using ShoeStore.Configuration;
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
        private Configurations _itemConfig;
        private IItemService _itemService;
        private IStoreService _storeService;
        private IStoreItemService _storeItemService;

        public ItemMapper(Configurations conf)
        {
            _itemConfig = conf;
            _itemService = _itemConfig.GetItemService();
            _storeService = _itemConfig.GetStoreService();
            _storeItemService = _itemConfig.GetStoreItemService();
        }
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

        public ItemVM GetItemByStoreItemId(Guid storeItemId)
        {
            StoreItem si = _storeItemService.FindById(storeItemId);
            Item item = _itemService.FindById(si.ItemId);
            Store store = _storeService.FindById(si.StoreId);

            return ConvertToVM(item, si.Price, store.Name, si.Id);
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