using ShoeStore.Models;
using System;
using System.Collections.Generic;

namespace ShoeShop.Business.Interfaces
{
    public interface IStoreItemRepository
    {
        StoreItem Add(StoreItem item);
        bool Remove(StoreItem itemID);
        void Update(StoreItem item);
        ICollection<StoreItem> GetAll();
        StoreItem FindByStoreIdAndItemId(Guid storeId, Guid itemId);
        StoreItem FindById(Guid id);
    }
}
