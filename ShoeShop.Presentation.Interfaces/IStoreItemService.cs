using ShoeStore.Models;

namespace ShoeShop.Presentation.Interfaces
{
    public interface IStoreItemService
    {
        StoreItem Add(StoreItem item);
        bool Remove(StoreItem itemID);
        void Update(StoreItem item);
    }
}
