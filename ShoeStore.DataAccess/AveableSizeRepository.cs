using ShoeShop.Business.Interfaces;
using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShoeStore.DataAccess
{
    public class AvailableSizeRepository : IAvailableSizeRepository
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private string _connectionString;
        private string _insertCommand = "INSERT INTO AvailableSizes(Id, SIId, Size) VALUES(@Id, @SIId, @Size)";
        private string _findBySIId = "SELECT * FROM AvailableSizes WHERE SIId=@SIId";
        private string _findBySIIdAndSize = "SELECT * FROM AvailableSizes WHERE SIId=@SIId AND Size=@Size";
        private string _removeBySIIdAndSize = "DELETE FROM AvailableSizes WHERE SIId=@SIId AND Size=@Size";
        private string _remove = "DELETE FROM AvailableSizes WHERE Id=@Id";


        public AvailableSizeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public AvailableSize Add(AvailableSize item)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_insertCommand, _connection))
                {
                    _command.Parameters.AddWithValue("@Id", item.Id);
                    _command.Parameters.AddWithValue("@SIId", item.SIId);
                    _command.Parameters.AddWithValue("@Size", item.Size);

                    _command.ExecuteNonQuery();
                    return item;
                }
            }
        }

        public bool RemoveBySIIdAndSize(Guid siId, double size)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_removeBySIIdAndSize, _connection))
                {
                    _command.Parameters.AddWithValue("@SIId", siId);
                    _command.Parameters.AddWithValue("@Size", size);
                    _command.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public ICollection<AvailableSize> FindBySIId(Guid siId)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_findBySIId, _connection))
                {
                    _command.Parameters.AddWithValue("@SIId", siId);

                    using (_reader = _command.ExecuteReader())
                    {
                        return CreateAvailableSizeList(_reader);
                    }
                }
            }
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

        public void Update(AvailableSize item)
        {
            throw new NotImplementedException();
        }

        private ICollection<AvailableSize> CreateAvailableSizeList(SqlDataReader reader)
        {
            List<AvailableSize> list = new List<AvailableSize>();
            while (reader.Read())
            {
                list.Add(CreateAvailableSize(reader));
            }
            return list;
        }

        private AvailableSize CreateAvailableSize(SqlDataReader reader)
        {
            return new AvailableSize()
            {
                Id = (Guid)reader[0],
                SIId = (Guid)reader[1],
                Size = (double)reader[2]
            };
        }

        public AvailableSize FindBySIIdAndSize(Guid siId, double size)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_findBySIIdAndSize, _connection))
                {
                    _command.Parameters.AddWithValue("@SIId", siId);
                    _command.Parameters.AddWithValue("@Size", size);
                    using (_reader = _command.ExecuteReader())
                    {
                        return _reader.Read() ? CreateAvailableSize(_reader) : null;
                    }
                }
            }
        }
    }
}
