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
        private SqlDataReader _reader;
        private string _connectionString;
        private string _insertCommand = "INSERT INTO StoreItems(Id, StoreId, ItemId, Price) VALUES(@Id, @StoreId, @ItemId, @Price)";
        private string _getAll = "SELECT (Id, StoreId, ItemId, Price) FROM StoreItems";
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
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_getAll, _connection))
                {
                    using (_reader = _command.ExecuteReader())
                    {
                        return CreateStoreItemList(_reader);
                    }
                }
            }
        }

        private IEnumerable<StoreItem> CreateStoreItemList(SqlDataReader reader)
        {
            List<StoreItem> list = new List<StoreItem>();
            while (reader.Read())
            {
                list.Add(CreateStoreItem(reader));
            }
            return list;
        }

        private StoreItem CreateStoreItem(SqlDataReader reader)
        {
            return new StoreItem()
            {
                Id = (Guid)reader[0],
                StoreId = (Guid)reader[1],
                ItemId = (Guid)reader[2],
                Price = (double)reader[3]
            };
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
