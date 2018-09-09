﻿using ShoeShop.Presentation.Interfaces;
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

        //public ICollection<StoreVM> ConvertToStoreVM(ICollection<Store> stores)
        //{
        //    ICollection<StoreVM> _stores = new List<StoreVM>();
        //    foreach (Store i in stores)
        //    {
        //        _stores.Add(ConvertToStoreVM(i));
        //    }
        //    return _stores;
        //}

        public ICollection<StoreVM> InitializeStoresVM()
        {
            ICollection<Store> stores = _storeService.GetAll();
            ICollection<Item> items = _itemService.GetAll();
            ICollection<StoreItem> storeItems = _storeItemService.GetAll();

            ICollection<StoreVM> _stores = new List<StoreVM>();
            foreach(Store s in stores)
            {
                ICollection<StoreItem> st = FindStoreItemsForStore(storeItems, s.Id);
                ICollection<ItemVM> itemsOfStore = new List<ItemVM>();
                foreach(StoreItem stItem in st)
                {
                    Item ite =FindItemById(items,stItem.ItemId);
                    itemsOfStore.Add(_itemsMapper.ConvertToVM(ite, stItem.Price, s.Name, stItem.Id));
                }
                _stores.Add(ConvertToStoreVM(s, itemsOfStore));
            }
            return _stores;
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