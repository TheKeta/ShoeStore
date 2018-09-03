using ShoeShop.Business.Interfaces;
using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShoeStore.DataAccess
{
    public class StoreItemRepository : IStoreItemRepository
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private string _connectionString;
        private string _insertCommand = "INSERT INTO AveableSize(Id, StoreId, ItemId, Price) VALUES(@Id, @StoreId, @ItemId, @Price)";
        private string _getAll = "SELECT (Id, StoreId, ItemId, Price) FROM AveableSize";
        public StoreItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public StoreItem Add(StoreItem item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StoreItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(StoreItem itemID)
        {
            throw new NotImplementedException();
        }

        public void Update(StoreItem item)
        {
            throw new NotImplementedException();
        }
    }
}
