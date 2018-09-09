﻿using ShoeShop.Business.Interfaces;
using ShoeShop.Presentation.Interfaces;
using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Business.Services
{
    public class StoreService : IStoreService
    {
        private IStoreRepository _storeRepository;
        private IItemService _itemService;
        private IStoreItemService _storeItemService;

        public StoreService(IStoreRepository storeRepository, IItemService itemService, IStoreItemService storeItemService)
        {
            _storeRepository = storeRepository;
            _itemService = itemService;
            _storeItemService = storeItemService;

        }
        public Store Add(Store item)
        {
            throw new NotImplementedException();
        }

        public Store FindById(Guid id)
        {
            return _storeRepository.FindById(id);
        }

        public ICollection<Store> GetAll()
        {
            ICollection<Store> stores = _storeRepository.GetAll();

            //foreach(Store s in stores)
            //{
            //    ICollection<StoreItem> si = _storeItemService.FindByStoreId(s.Id);
            //    foreach(StoreItem sit in si)
            //    {
            //        Item item = _itemService.FindById(sit.ItemId);
            //        item.Price = sit.Price;
            //        s.Items.Add(item);
            //    }
            //}
            return stores;
        }

        public bool Remove(Store itemID)
        {
            throw new NotImplementedException();
        }

        public void Update(Store item)
        {
            throw new NotImplementedException();
        }
    }
}
