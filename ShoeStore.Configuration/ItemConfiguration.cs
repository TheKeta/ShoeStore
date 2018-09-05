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

        public IStoreService GetStoreService()
        {
            return new StoreService(GetStoreRepository(), GetItemService(), GetStoreItemService());
        }

        public IStoreRepository GetStoreRepository()
        {
            return new StoreRepository(Configuration.Configurations.ConnectionString);
        }

        public IStoreItemService GetStoreItemService()
        {
            return new StoreItemService(GetStoreItemRepository());
        }

        public IStoreItemRepository GetStoreItemRepository()
        {
            return new StoreItemRepository(Configuration.Configurations.ConnectionString);
        }
    }
}
