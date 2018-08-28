using ShoeShop.Business.Interfaces;
using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeStore.DataAccess
{
    public class ItemRepository : IItemRepository
    {
        public Item add(Item item)
        {
            throw new NotImplementedException();
        }

        public bool remove(Guid itemID)
        {
            throw new NotImplementedException();
        }

        public void update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}