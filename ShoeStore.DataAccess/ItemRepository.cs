using ShoeShop.Business.Interfaces;
using ShoeStore.Models;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ShoeStore.DataAccess
{
    public class ItemRepository : IItemRepository
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private string _connectionString;
        private string _insertCommand = "INSERT INTO Items(Id, Brand, Model, Description, Sex) VALUES(@Id, @Brand, @Model, @Description, @Sex)";
        private string _getAll = "SELECT * FROM Items";
        private string _findById = "SELECT * FROM Items WHERE Id=@Id";

        public ItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Item Add(Item item)
        {
            using(_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_insertCommand, _connection))
                {
                    _command.Parameters.AddWithValue("@Id", item.Id);
                    _command.Parameters.AddWithValue("@Brand", item.Brand);
                    _command.Parameters.AddWithValue("@Model", item.Model);
                    _command.Parameters.AddWithValue("@Description", item.Description);
                    _command.Parameters.AddWithValue("@Sex", item.Sex);

                    _command.ExecuteNonQuery();
                    return item;
                }
            }
        }

        public bool Remove(Guid itemID)
        {
            throw new NotImplementedException();
        }

        public void Update(Item item)
        {
            throw new NotImplementedException();
        }

        public ICollection<Item> GetAll()
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_getAll, _connection))
                {
                    using (_reader = _command.ExecuteReader())
                    {
                        return CreateItemList(_reader);
                    }
                }
            }
        }

        private ICollection<Item> CreateItemList(SqlDataReader reader)
        {
            List<Item> list = new List<Item>();
            while (reader.Read())
            {
                list.Add(CreateItem(reader));
            }
            return list;
        }

        private Item CreateItem(SqlDataReader reader)
        {
            return new Item()
            {
                Id = (Guid)reader[0],
                Brand = (string)reader[1],
                Model = (string)reader[2],
                Description = (string)reader[3],
                Sex = (string)reader[4]
            };
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_connection != null) _connection.Dispose();
            }
        }

        public Item FindById(Guid id)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_findById, _connection))
                {
                    _command.Parameters.AddWithValue("@Id", id);
                    using (_reader = _command.ExecuteReader())
                    {
                        return CreateItem(_reader);
                    }
                }
            }
        }
    }
}