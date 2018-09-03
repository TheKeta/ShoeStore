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
    public class StoreService : IStoreService
    {
        private IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        public Store Add(Store item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Store> GetAll()
        {
            return _storeRepository.GetAll();
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
