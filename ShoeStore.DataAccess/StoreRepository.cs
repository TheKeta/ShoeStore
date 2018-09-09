using ShoeShop.Business.Interfaces;
using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShoeStore.DataAccess
{
    public class StoreRepository : IStoreRepository
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private string _connectionString;
        private string _insertCommand = "INSERT INTO Store(Id, Name, Address, PhoneNumber) VALUES(@Id, @Name, @Address, @PhoneNumber)";
        private string _getAll = "SELECT * FROM Stores";
        private string _findById = "SELECT * FROM Stores WHERE Id=@Id";
        private string _search = "SELECT * FROM Stores WHERE Name LIKE @Name";

        public StoreRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Store Add(Store item)
        {
            throw new NotImplementedException();
        }

        public ICollection<Store> GetAll()
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_getAll, _connection))
                {
                    using (_reader = _command.ExecuteReader())
                    {
                        return CreateStoreList(_reader);
                    }
                }
            }
        }

        private ICollection<Store> CreateStoreList(SqlDataReader reader)
        {
            ICollection<Store> list = new List<Store>();
            while (reader.Read())
            {
                list.Add(CreateStore(reader));
            }
            return list;
        }

        private Store CreateStore(SqlDataReader reader)
        {
            return new Store()
            {
                Id = (Guid)reader[0],
                Name = (string)reader[1],
                Address = (string)reader[2],
                PhoneNumber = (string)reader[3]
            };
        }

        public bool Remove(Store itemID)
        {
            throw new NotImplementedException();
        }

        public void Update(Store item)
        {
            throw new NotImplementedException();
        }

        public Store FindById(Guid id)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_findById, _connection))
                {
                    _command.Parameters.AddWithValue("@Id", id);
                    using (_reader = _command.ExecuteReader())
                    {
                        return _reader.Read() ? CreateStore(_reader) : null;
                    }
                }
            }
        }

        public ICollection<Store> Search(string name)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_search, _connection))
                {
                    _command.Parameters.AddWithValue("@Name", "%" + name + "%");
                    using (_reader = _command.ExecuteReader())
                    {
                        return CreateStoreList(_reader);
                    }
                }
            }
        }
    }
}
