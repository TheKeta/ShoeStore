using ShoeStore.Models;

namespace ShoeShop.Business.Interfaces
{
    public interface IStoreRepository
    {
        Store Add(Store item);
        bool Remove(Store itemID);
        void Update(Store item);
    }
}
