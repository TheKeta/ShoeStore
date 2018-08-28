using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Business.Interfaces
{
    public interface IItemRepository
    {
        Item add(Item item);
        bool remove(Guid itemID);
        void update(Item item);
    }
}
