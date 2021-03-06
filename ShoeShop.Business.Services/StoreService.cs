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
            item.Id = Guid.NewGuid();
            return _storeRepository.Add(item);
        }

        public Store FindById(Guid id)
        {
            return _storeRepository.FindById(id);
        }

        public ICollection<Store> GetAll()
        {
            return _storeRepository.GetAll();
        }

        public bool Remove(Guid itemID)
        {
            return _storeRepository.Remove(itemID);
        }

        public ICollection<Store> Search(string name)
        {
            return _storeRepository.Search(name);
        }

        public void Update(Store item)
        {
            _storeRepository.Update(item);
        }
    }
}
