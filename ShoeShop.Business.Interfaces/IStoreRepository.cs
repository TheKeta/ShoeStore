using ShoeStore.Models;
using System;
using System.Collections.Generic;

namespace ShoeShop.Business.Interfaces
{
    public interface IStoreRepository
    {
        Store Add(Store item);
        bool Remove(Guid itemID);
        void Update(Store item);
        ICollection<Store> GetAll();
        Store FindById(Guid id);
        ICollection<Store> Search(string name);
    }
}
