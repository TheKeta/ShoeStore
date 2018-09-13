using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Presentation.Interfaces
{
    public interface IStoreService
    {
        Store Add(Store item);
        bool Remove(Guid itemID);
        void Update(Store item);
        ICollection<Store> GetAll();
        Store FindById(Guid id);
        ICollection<Store> Search(string name);
    }
}
