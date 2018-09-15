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
        private string _getAll = "SELECT * FROM StoreItems";
        private string _findByStoreIdAndItemId = "SELECT * FROM StoreItems WHERE StoreId=@StoreId AND ItemId=@ItemId";
        private string _findByStoreIdAndItemIdAndPriceBetween = "SELECT * FROM StoreItems WHERE StoreId=@StoreId AND ItemId=@ItemId AND Price BETWEEN @MinPrice AND @MaxPrice";
        private string _findById = "SELECT * FROM StoreItems WHERE Id=@Id";
        private string _removeByStoreId = "DELETE FROM StoreItems WHERE StoreId=@StoreId";
        private string _removeByItemId = "DELETE FROM StoreItems WHERE ItemId=@ItemId";
        private string _remove = "DELETE FROM StoreItems WHERE Id=@Id";

        public StoreItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public StoreItem Add(StoreItem item)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_insertCommand, _connection))
                {
                    _command.Parameters.AddWithValue("@Id", item.Id);
                    _command.Parameters.AddWithValue("@StoreId", item.StoreId);
                    _command.Parameters.AddWithValue("@ItemId", item.ItemId);
                    _command.Parameters.AddWithValue("@Price", item.Price);

                    _command.ExecuteNonQuery();
                    return item;
                }
            }
        }

        public ICollection<StoreItem> GetAll()
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

        private ICollection<StoreItem> CreateStoreItemList(SqlDataReader reader)
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

        public bool Remove(Guid itemID)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_remove, _connection))
                {
                    _command.Parameters.AddWithValue("@Id", itemID);

                    _command.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public void Update(StoreItem item)
        {
            throw new NotImplementedException();
        }

        public StoreItem FindByStoreIdAndItemId(Guid storeId, Guid itemId)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_findByStoreIdAndItemId, _connection))
                {
                    _command.Parameters.AddWithValue("@StoreId", storeId);
                    _command.Parameters.AddWithValue("@ItemId", itemId);
                    using (_reader = _command.ExecuteReader())
                    {
                        return _reader.Read() ? CreateStoreItem(_reader) : null;
                    }
                }
            }
        }

        public StoreItem FindById(Guid id)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_findById, _connection))
                {
                    _command.Parameters.AddWithValue("@Id", id);
                    using (_reader = _command.ExecuteReader())
                    {
                        return _reader.Read() ? CreateStoreItem(_reader) : null;
                    }
                }
            }
        }

        public void RemoveByStoreId(Guid storeId)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_removeByStoreId, _connection))
                {
                    _command.Parameters.AddWithValue("@StoreId", storeId);

                    _command.ExecuteNonQuery();
                    return;
                }
            }
        }

        public void RemoveByItemId(Guid itemId)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_removeByItemId, _connection))
                {
                    _command.Parameters.AddWithValue("@ItemId", itemId);

                    _command.ExecuteNonQuery();
                    return;
                }
            }
        }

        public StoreItem FindByStoreIdAndItemIdAndPriceBetween(Guid storeId, Guid itemId, double minPrice, double maxPrice)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_findByStoreIdAndItemIdAndPriceBetween, _connection))
                {
                    _command.Parameters.AddWithValue("@StoreId", storeId);
                    _command.Parameters.AddWithValue("@ItemId", itemId);
                    _command.Parameters.AddWithValue("@MinPrice", minPrice);
                    _command.Parameters.AddWithValue("@MaxPrice", maxPrice);

                    using (_reader = _command.ExecuteReader())
                    {
                        return _reader.Read() ? CreateStoreItem(_reader) : null;
                    }
                }
            }
        }
    }
}
