using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Business.Interfaces
{
    public interface IItemRepository : IDisposable
    {
        Item Add(Item item);
        bool Remove(Guid itemID);
        void Update(Item item);
    }
}
