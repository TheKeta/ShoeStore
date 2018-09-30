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
    public class StoreItemService : IStoreItemService
    {
        private IStoreItemRepository _storeItemRepository;
        private IAvailableSizeService _asService;

        public StoreItemService(IStoreItemRepository storeItemRepository, IAvailableSizeService asService)
        {
            _storeItemRepository = storeItemRepository;
            _asService = asService;
        }

        public StoreItem Add(StoreItem item)
        {
            StoreItem old = _storeItemRepository.FindByStoreIdAndItemId(item.StoreId, item.ItemId);
            if (old == null)
            {
                item.Id = Guid.NewGuid();
                return _storeItemRepository.Add(item);
            }
            return old;
        }

        public StoreItem FindByStoreIdAndItemId(Guid storeId, Guid itemId)
        {
            return _storeItemRepository.FindByStoreIdAndItemId(storeId, itemId);
        }

        public StoreItem FindById(Guid id)
        {
            return _storeItemRepository.FindById(id);
        }


        public ICollection<StoreItem> GetAll()
        {
            return _storeItemRepository.GetAll();
        }

        public bool Remove(StoreItem itemID)
        {
            throw new NotImplementedException();
        }

        public void Update(StoreItem item)
        {
            throw new NotImplementedException();
        }

        public void RemoveByStoreId(Guid storeId)
        {
            _storeItemRepository.RemoveByStoreId(storeId);
        }

        public void RemoveByItemId(Guid itemId)
        {
            _storeItemRepository.RemoveByItemId(itemId);
        }

        public void RemoveByStoreIdAndItemId(Guid storeId, Guid itemId)
        {
            StoreItem si = _storeItemRepository.FindByStoreIdAndItemId(storeId, itemId);
            ICollection<AvailableSize> sizes = _asService.FindBySIId(si.Id);
            foreach(AvailableSize a in sizes)
            {
                _asService.RemoveBySIIdAndSize(a.SIId, a.Size);
            }
            _storeItemRepository.Remove(si.Id);
        }

        public StoreItem FindByStoreIdAndItemIdAndPriceBetween(Guid storeId, Guid itemId, double minPrice, double maxPrice)
        {
            return _storeItemRepository.FindByStoreIdAndItemIdAndPriceBetween(storeId, itemId, minPrice, maxPrice);
        }
    }
}
