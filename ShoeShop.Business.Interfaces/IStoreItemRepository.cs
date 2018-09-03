using ShoeStore.Models;
using System.Collections.Generic;

namespace ShoeShop.Business.Interfaces
{
    public interface IStoreItemRepository
    {
        StoreItem Add(StoreItem item);
        bool Remove(StoreItem itemID);
        void Update(StoreItem item);
        IEnumerable<StoreItem> GetAll();
    }
}
