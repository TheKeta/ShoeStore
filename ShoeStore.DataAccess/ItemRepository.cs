using ShoeShop.Business.Interfaces;
using ShoeStore.Models;
using System;
using System.Data.SqlClient;

namespace ShoeStore.DataAccess
{
    public class ItemRepository : IItemRepository
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private string _connectionString;
        private string _insertCommand = "INSERT INTO Items(Id, Brand, Model, Description, Sex) VALUES(@Id, @Brand, @Model, @Description, @Sex)";
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
    }
}