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
    public class Configurations
    {
        public IItemService GetItemService()
        {
            return new ItemService(GetItemRepository());
        }

        public IItemRepository GetItemRepository()
        {
            return new ItemRepository(ShoeStore.Configuration.StringConfigurations.ConnectionString);
        }

        public IStoreService GetStoreService()
        {
            return new StoreService(GetStoreRepository(), GetItemService(), GetStoreItemService());
        }

        public IStoreRepository GetStoreRepository()
        {
            return new StoreRepository(ShoeStore.Configuration.StringConfigurations.ConnectionString);
        }

        public IStoreItemService GetStoreItemService()
        {
            return new StoreItemService(GetStoreItemRepository());
        }

        public IStoreItemRepository GetStoreItemRepository()
        {
            return new StoreItemRepository(ShoeStore.Configuration.StringConfigurations.ConnectionString);
        }
    }
}
