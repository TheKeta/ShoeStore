using ShoeShop.Presentation.Interfaces;
using ShoeStore.Configuration;
using ShoeStore.Models;
using ShoeStore.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            ases = ases == null ? new List<AveableSize>() : ases as List<AveableSize>;
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
                AveableSizes = ases as List<AveableSize>
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
            List<AveableSize> ases = (List<AveableSize>) _availableSizeService.FindBySIId(si.Id);
            ases.Sort((x, y) => x.Size.CompareTo(y.Size));
            return ConvertToVM(item, si.Price, store.Name, si.Id, ases);
        }

        public ICollection<ItemVM> Search(string storeName, string model, string brand,
            string sex, double minPrice, double maxPrice, double size)
        {
            ICollection<ItemVM> _items = new List<ItemVM>();
            //VALIDATION OF STRINGS, FOR SEX ONLY FIRST LETTER
            storeName = string.IsNullOrWhiteSpace(storeName) ? "" : storeName;
            model = string.IsNullOrWhiteSpace(model) ? "" : model;
            brand = string.IsNullOrWhiteSpace(brand) ? "" : brand;
            sex = string.IsNullOrWhiteSpace(sex) ? "" : sex.Substring(0,1);
            maxPrice = maxPrice <= 0 ? Double.MaxValue : maxPrice;
            size = size <= 0 ? 0 : size;

            ICollection<Item> items = _itemService.Search(model, brand, sex);
            ICollection<Store> stores = _storeService.Search(storeName);

            //possible optimization
            foreach( Store s in stores)
            {
                foreach(Item i in items)
                {
                    StoreItem si = _storeItemService.FindByStoreIdAndItemIdAndPriceBetween(s.Id, i.Id,minPrice, maxPrice);
                    if (si != null)
                    {
                        if (size > 0)
                        {
                            AveableSize asa = _availableSizeService.FindBySIIdAndSize(si.Id, size);
                            if (asa != null)
                            {
                                _items.Add(ConvertToVM(i, si.Price, s.Name, si.Id));
                            }
                        }
                        else
                        {
                            _items.Add(ConvertToVM(i, si.Price, s.Name, si.Id));
                        }
                    }
                }
            }
            return _items;
        }
    }
}