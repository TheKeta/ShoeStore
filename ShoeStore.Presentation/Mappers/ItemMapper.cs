using ShoeShop.Presentation.Interfaces;
using ShoeStore.Configuration;
using ShoeStore.Models;
using ShoeStore.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeStore.Presentation.Mappers
{
    public class ItemMapper
    {
        private Configurations _itemConfig;
        private IItemService _itemService;
        private IStoreService _storeService;
        private IStoreItemService _storeItemService;
        private IAveableSizeService _availableSizeService;

        public ItemMapper(Configurations conf)
        {
            _itemConfig = conf;
            _itemService = _itemConfig.GetItemService();
            _storeService = _itemConfig.GetStoreService();
            _storeItemService = _itemConfig.GetStoreItemService();
            _availableSizeService = _itemConfig.GetAveableSizeService();
        }
        public ItemVM ConvertToVM(Item item, double price, string storeName, Guid siID, ICollection<AveableSize> ases = null)
        {
            ases = ases == null ? new List<AveableSize>() : ases;
            
            ICollection<SelectListItem>  list = ases.Select(x => new SelectListItem() { Value = x.Size.ToString(), Text = x.Size.ToString() }).ToList();
            return new ItemVM()
            {
                Brand = item.Brand,
                Description = item.Description,
                Id = item.Id,
                Model = item.Model,
                Sex = item.Sex,
                Price = price,
                StoreName = storeName,
                StoreItemId = siID,
                AveableSizes = ases
            };
        }

        public Item ConvertFromVM(ItemVM item)
        {
            return new Item()
            {
                Brand = item.Brand,
                Description = item.Description,
                Id = item.Id,
                Model = item.Model,
                Sex = item.Sex
            };
        }

        public ItemVM GetItemByStoreItemId(Guid storeItemId)
        {
            StoreItem si = _storeItemService.FindById(storeItemId);
            Item item = _itemService.FindById(si.ItemId);
            Store store = _storeService.FindById(si.StoreId);
            ICollection<AveableSize> ases = _availableSizeService.FindBySIId(si.Id);

            return ConvertToVM(item, si.Price, store.Name, si.Id, ases);
        }

        public ICollection<ItemVM> Search(string storeName, string model, string brand, string sex)
        {
            ICollection<ItemVM> _items = new List<ItemVM>();
            //VALIDATION OF STRINGS, FOR SEX ONLY FIRST LETTER
            storeName = string.IsNullOrWhiteSpace(storeName) ? "" : storeName;
            model = string.IsNullOrWhiteSpace(model) ? "" : model;
            brand = string.IsNullOrWhiteSpace(brand) ? "" : brand;
            sex = string.IsNullOrWhiteSpace(sex) ? "" : sex.Substring(0,1);

            ICollection<Item> items = _itemService.Search(model, brand, sex);
            ICollection<Store> stores = _storeService.Search(storeName);

            //possible optimization
            foreach( Store s in stores)
            {
                foreach(Item i in items)
                {
                    StoreItem si = _storeItemService.FindByStoreIdAndItemId(s.Id, i.Id);
                    if (si != null)
                    {
                        _items.Add(ConvertToVM(i, si.Price, s.Name, si.Id));
                    }
                }
            }
            return _items;
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