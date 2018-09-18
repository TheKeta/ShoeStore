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
        private string _insertCommand = "INSERT INTO Users(Id, FirstName, LastName, Address, Email, Role, Password) VALUES(@Id, @FirstName, @LastName, @Address, @Email, @Role, @Password)";
        private string _findUser = "SELECT * FROM Users WHERE Email=@Email AND Password=@Password";
        private string _findById = "SELECT * FROM Users WHERE Id=@Id";
        private string _updateUser = "UPDATE Users SET FirstName=@FirstName, LastName=@LastName, Address=@Address WHERE Id=@Id";

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
                    _command.Parameters.AddWithValue("@Role", "ADMIN");

                    _command.ExecuteNonQuery();
                    return user;
                }
            }
        }

        public User FindById(Guid id)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_findById, _connection))
                {
                    _command.Parameters.AddWithValue("@Id", id);
                    using (_reader = _command.ExecuteReader())
                    {
                        return _reader.Read() ? CreateUser(_reader) : null;
                    }
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
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_updateUser, _connection))
                {
                    _command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    _command.Parameters.AddWithValue("@LastName", user.LastName);
                    _command.Parameters.AddWithValue("@Address", user.Address);
                    _command.Parameters.AddWithValue("@Id", user.Id);

                    _command.ExecuteNonQuery();
                    return;
                }
            }
        }

        private User CreateUser(SqlDataReader reader)
        {
            return new User()
            {
                Id = (Guid)reader[0],
                FirstName = (string)reader[1],
                LastName = (string)reader[2],
                Address = (string)reader[3],
                Email = (string)reader[4],
                Role = (string)reader[5]
            };
        }
    }
}
