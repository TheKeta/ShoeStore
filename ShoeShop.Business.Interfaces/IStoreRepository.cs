using ShoeStore.Models;
using System;
using System.Collections.Generic;

namespace ShoeShop.Business.Interfaces
{
    public interface IStoreRepository
    {
        Store Add(Store item);
        bool Remove(Store itemID);
        void Update(Store item);
        ICollection<Store> GetAll();
        Store FindById(Guid id);
    }
}
