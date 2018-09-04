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
    public class ItemService : IItemService
    {
        private IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public Item Add(Item item)
        {
            item.Id = Guid.NewGuid();
            if (Validate(item))
            {
                return _itemRepository.Add(item);
            }
            return null;
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Item id)
        {
            throw new NotImplementedException();
        }

        private bool Validate(Item item)
        {
            return true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_itemRepository != null) _itemRepository.Dispose();
            }
        }

        public ICollection<Item> GetAll()
        {
            return _itemRepository.GetAll();
        }

        public Item FindById(Guid id)
        {
            return _itemRepository.FindById(id);
        }
    }
}
