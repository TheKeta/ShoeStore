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
        private IAvailableSizeService _availableSizeService;
        private IPictureService _pictureService;

        public ItemMapper(Configurations conf)
        {
            _itemConfig = conf;
            _itemService = _itemConfig.GetItemService();
            _storeService = _itemConfig.GetStoreService();
            _storeItemService = _itemConfig.GetStoreItemService();
            _availableSizeService = _itemConfig.GetAvailableSizeService();
            _pictureService = _itemConfig.GetPictureService();
        }
        public ItemVM ConvertToVM(Item item, double price, string storeName, Guid siID, ICollection<AvailableSize> ases = null,
            ICollection<string> pics = null)
        {
            ases = ases == null ? new List<AvailableSize>() : ases as List<AvailableSize>;
            pics = pics == null ? new List<string>() : pics;

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
                AvailableSizes = ases as List<AvailableSize>,
                ImagesBit = pics
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
            List<AvailableSize> ases = (List<AvailableSize>) _availableSizeService.FindBySIId(si.Id);
            ases.Sort((x, y) => x.Size.CompareTo(y.Size));
            ICollection<string> pics = ConvertPictures(_pictureService.FindByItemId(si.ItemId));
            return ConvertToVM(item, si.Price, store.Name, si.Id, ases, pics);
        }

        private ICollection<string> ConvertPictures(ICollection<Picture> pictures)
        {
            ICollection<string> list = new List<string>();
            foreach (Picture pic in pictures)
            {
                var base64 = Convert.ToBase64String(pic.Image);
                var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
                list.Add(imgSrc);
            }
            return list;
        }

        public ICollection<ItemVM> Search(string storeName, string model, string brand,
            string sex, double minPrice, double maxPrice, double size, string sort = "ASC")
        {
            List<ItemVM> _items = new List<ItemVM>();
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
                        ICollection<string> pics = ConvertPictures(_pictureService.FindByItemId(si.ItemId));
                        if (size > 0)
                        {
                            AvailableSize asa = _availableSizeService.FindBySIIdAndSize(si.Id, size);
                            if (asa != null)
                            {
                                _items.Add(ConvertToVM(i, si.Price, s.Name, si.Id,null, pics));
                            }
                        }
                        else
                        {
                            _items.Add(ConvertToVM(i, si.Price, s.Name, si.Id, null, pics));
                        }
                    }
                }
            }
            if (sort.Equals("ASC"))
            {
                _items.Sort((x, y) => x.Price.CompareTo(y.Price));
            }
            else
            {
                _items.Sort((x, y) => y.Price.CompareTo(x.Price));
            }
            return _items;
        }
    }
}