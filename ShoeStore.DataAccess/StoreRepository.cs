using ShoeShop.Business.Interfaces;
using ShoeStore.Models;
using System;
using System.Data.SqlClient;

namespace ShoeStore.DataAccess
{
    public class StoreRepository : IStoreRepository
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private string _connectionString;
        private string _insertCommand = "INSERT INTO AveableSize(Id, Name, Address, PhoneNumber) VALUES(@Id, @Name, @Address, @PhoneNumber)";

        public StoreRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Store Add(Store item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Store itemID)
        {
            throw new NotImplementedException();
        }

        public void Update(Store item)
        {
            throw new NotImplementedException();
        }
    }
}
