using ShoeShop.Business.Interfaces;
using ShoeShop.Presentation.Interfaces;
using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Business.Services
{
    class StoreItemService : IStoreItemService
    {
        private IStoreItemRepository _storeItemRepository;

        public StoreItemService(IStoreItemRepository storeItemRepository)
        {
            _storeItemRepository = storeItemRepository;
        }

        public StoreItem Add(StoreItem item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Store> GetAll()
        {
            return _storeRepository.GetAll();
        }

        public bool Remove(StoreItem itemID)
        {
            throw new NotImplementedException();
        }

        public void Update(StoreItem item)
        {
            throw new NotImplementedException();
        }
    }
}
