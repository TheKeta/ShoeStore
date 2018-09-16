using ShoeShop.Business.Interfaces;
using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShoeStore.DataAccess
{
    public class PictureRepository : IPictureRepository
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private string _connectionString;
        private string _insertCommand = "INSERT INTO Pictures(Id, ItemId, Image) VALUES(@Id, @ItemId, @Image)";
        private string _removeByItemId = "DELETE FROM Pictures WHERE ItemId=@ItemId";
        private string _findByItemId = "SELECT * FROM Pictures WHERE ItemId=@ItemId";

        public PictureRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Picture Add(Picture item)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_insertCommand, _connection))
                {
                    _command.Parameters.AddWithValue("@Id", item.Id);
                    _command.Parameters.AddWithValue("@ItemId", item.ItemId);
                    _command.Parameters.AddWithValue("@Image", item.Image);

                    _command.ExecuteNonQuery();
                    return item;
                }
            }
        }

        public bool RemoveByItemId(Guid itemID)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_removeByItemId, _connection))
                {
                    _command.Parameters.AddWithValue("@ItemId", itemID);

                    _command.ExecuteNonQuery();
                    return true;
                }
            }
        }

        private ICollection<Picture> CreatePictureList(SqlDataReader reader)
        {
            List<Picture> list = new List<Picture>();
            while (reader.Read())
            {
                list.Add(CreatePicture(reader));
            }
            return list;
        }

        private Picture CreatePicture(SqlDataReader reader)
        {
            return new Picture()
            {
                Id = (Guid)reader[0],
                ItemId = (Guid)reader[1],
                Image = (byte[])reader[2]
            };
        }

            public void Update(Picture item)
        {
            throw new NotImplementedException();
        }

        public ICollection<Picture> FindByItemId(Guid itemId)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_findByItemId, _connection))
                {
                    _command.Parameters.AddWithValue("@ItemId", itemId);
                    using (_reader = _command.ExecuteReader())
                    {
                        return CreatePictureList(_reader);
                    }
                }
            }
        }
    }
}
