using ShoeStore.Models;
using System;
using System.Collections.Generic;

namespace ShoeShop.Presentation.Interfaces
{
    public interface IStoreItemService
    {
        StoreItem Add(StoreItem item);
        bool Remove(StoreItem itemID);
        void Update(StoreItem item);
        ICollection<StoreItem> GetAll();
        StoreItem FindByStoreIdAndItemId(Guid storeId, Guid itemId);
        StoreItem FindByStoreIdAndItemIdAndPriceBetween(Guid storeId, Guid itemId, double minPrice, double maxPrice);
        StoreItem FindById(Guid id);
        void RemoveByStoreId(Guid storeId);
        void RemoveByItemId(Guid itemId);
        void RemoveByStoreIdAndItemId(Guid storeId, Guid itemId);
    }
}
