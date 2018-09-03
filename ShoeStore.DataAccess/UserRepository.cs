using ShoeShop.Business.Interfaces;
using ShoeStore.Models;
using System;
using System.Data.SqlClient;

namespace ShoeStore.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private string _connectionString;
        private string _insertCommand = "INSERT INTO AveableSize(Id, FirstName, LastName, Address, Email, Password) VALUES(@Id, @SIId, @Size)";

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public User Add(User user)
        {
            throw new NotImplementedException();
        }

        public bool Remove(User userID)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
