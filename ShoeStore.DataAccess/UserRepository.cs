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
        private SqlDataReader _reader;
        private string _connectionString;
        private string _insertCommand = "INSERT INTO Users(Id, FirstName, LastName, Address, Email, Password) VALUES(@Id, @FirstName, @LastName, @Address, @Email, @Password)";
        private string _findUser = "SELECT * FROM Users WHERE Email=@Email AND Password=@Password";

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public User Add(User user)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_insertCommand, _connection))
                {
                    _command.Parameters.AddWithValue("@Id", user.Id);
                    _command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    _command.Parameters.AddWithValue("@LastName", user.LastName);
                    _command.Parameters.AddWithValue("@Address", user.Address);
                    _command.Parameters.AddWithValue("@Email", user.Email);
                    _command.Parameters.AddWithValue("@Password", user.Password);

                    _command.ExecuteNonQuery();
                    return user;
                }
            }
        }

        public User FindUser(User user)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_findUser, _connection))
                {
                    _command.Parameters.AddWithValue("@Email", user.Email);
                    _command.Parameters.AddWithValue("@Password", user.Password);
                    using (_reader = _command.ExecuteReader())
                    {
                        return _reader.Read() ? CreateUser(_reader) : null;
                    }
                }
            }
        }

        public bool Remove(User userID)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        private User CreateUser(SqlDataReader reader)
        {
            return new User()
            {
                Id = (Guid)reader[0],
                FirstName = (string)reader[1],
                LastName = (string)reader[2],
                Address = (string)reader[3],
                Email = (string)reader[4]
            };
        }
    }
}
