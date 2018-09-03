using ShoeShop.Business.Interfaces;
using ShoeShop.Business.Services;
using ShoeShop.Presentation.Interfaces;
using ShoeStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeStore.Configuration
{
    public class ItemConfiguration
    {
        public IItemService GetItemService()
        {
            return new ItemService(GetItemRepository());
        }

        public IItemRepository GetItemRepository()
        {
            return new ItemRepository(Configuration.Configurations.ConnectionString);
        }
        
    }
}
