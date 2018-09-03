using ShoeStore.Models;
using System.Collections.Generic;

namespace ShoeShop.Presentation.Interfaces
{
    public interface IStoreItemService
    {
        StoreItem Add(StoreItem item);
        bool Remove(StoreItem itemID);
        void Update(StoreItem item);
        IEnumerable<Store> GetAll();
    }
}
