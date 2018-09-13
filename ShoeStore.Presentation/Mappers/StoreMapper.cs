using ShoeShop.Presentation.Interfaces;
using ShoeStore.Configuration;
using ShoeStore.Models;
using ShoeStore.Presentation.ViewModel;
using System;
using System.Collections.Generic;

namespace ShoeStore.Presentation.Mappers
{
    public class StoreMapper
    {
        private Configurations _itemConfig;
        private IItemService _itemService;
        private IStoreService _storeService;
        private IStoreItemService _storeItemService;
        private ItemMapper _itemsMapper;

        public StoreMapper(Configurations conf)
        {
            _itemConfig = conf;
            _itemService = _itemConfig.GetItemService();
            _storeService = _itemConfig.GetStoreService();
            _storeItemService = _itemConfig.GetStoreItemService();
            _itemsMapper = new ItemMapper(_itemConfig);
        }
        public StoreVM ConvertToStoreVM(Store store, ICollection<ItemVM> items)
        {
            return new StoreVM()
            {
                Address = store.Address,
                Id = store.Id,
                Name = store.Name,
                PhoneNumber = store.PhoneNumber,
                Items = items
            };
        }

        public Store ConvertFromStoreVM(StoreVM store)
        {
            return new Store()
            {
                Address = store.Address,
                Id = store.Id,
                Name = store.Name,
                PhoneNumber = store.PhoneNumber
            };
        }

        private ICollection<StoreVM> InitializeStoresVM()
        {
            ICollection<Store> stores = _storeService.GetAll();
            ICollection<StoreItem> storeItems = _storeItemService.GetAll();

            ICollection<StoreVM> _stores = new List<StoreVM>();
            foreach(Store s in stores)
            {
                ICollection<StoreItem> st = FindStoreItemsForStore(storeItems, s.Id);
                ICollection<ItemVM> itemsOfStore = new List<ItemVM>();
                foreach(StoreItem stItem in st)
                {
                    itemsOfStore.Add(_itemsMapper.GetItemByStoreItemId(stItem.Id));
                }
                _stores.Add(ConvertToStoreVM(s, itemsOfStore));
            }
            return _stores;
        }

        public StoreVM FindItemsForStore(Store store)
        {
            ICollection<StoreItem> storeItems = _storeItemService.GetAll();
            ICollection<StoreItem> st = FindStoreItemsForStore(storeItems, store.Id);
            ICollection<ItemVM> itemsOfStore = new List<ItemVM>();
            foreach (StoreItem stItem in st)
            {
                itemsOfStore.Add(_itemsMapper.GetItemByStoreItemId(stItem.Id));
            }
            return ConvertToStoreVM(store, itemsOfStore);
        }

        public ICollection<ItemVM> SortByPriceASC(List<ItemVM> items = null)
        {
            items = items ==null ? GetItemsVM() : items;
            items.Sort((x, y) => x.AveableSizes[0].Price.CompareTo(y.AveableSizes[0].Price));
            return items;
        }

        public ICollection<ItemVM> SortByPriceDES(List<ItemVM> items = null)
        {
            items = items == null ? GetItemsVM() : items;
            items.Sort((x, y) => y.AveableSizes[0].Price.CompareTo(x.AveableSizes[0].Price));
            return items;
        }

        private List<ItemVM> GetItemsVM()
        {
            ICollection<StoreVM> stores = InitializeStoresVM();
            List<ItemVM> items = new List<ItemVM>();
            foreach (StoreVM svm in stores)
            {
                items.AddRange(svm.Items);
            }
            return items;

        }
        private Item FindItemById(ICollection<Item> items,Guid itemID)
        {
            foreach(Item i in items)
            {
                if (i.Id.Equals(itemID))
                {
                    return i;
                }
            }
            return null;
        }

        private ICollection<StoreItem> FindStoreItemsForStore(ICollection<StoreItem> storeItems, Guid storeId)
        {
            ICollection<StoreItem> st = new List<StoreItem>();
            foreach(StoreItem si in storeItems)
            {
                if (si.StoreId.Equals(storeId))
                {
                    st.Add(si);
                }
            }
            return st;
        }
    }
}