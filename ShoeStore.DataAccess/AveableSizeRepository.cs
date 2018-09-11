using ShoeShop.Business.Interfaces;
using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShoeStore.DataAccess
{
    public class AveableSizeRepository : IAveableSizeRepository
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private string _connectionString;
        private string _insertCommand = "INSERT INTO AveableSizes(Id, SIId, Size) VALUES(@Id, @SIId, @Size)";
        private string _findBySIId = "SELECT * FROM AveableSizes WHERE SIId=@SIId";

        public AveableSizeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public AveableSize Add(AveableSize item)
        {
            throw new NotImplementedException();
        }

        public ICollection<AveableSize> FindBySIId(Guid siId)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand(_findBySIId, _connection))
                {
                    _command.Parameters.AddWithValue("@SIId", siId);

                    using (_reader = _command.ExecuteReader())
                    {
                        return CreateAveableSizeList(_reader);
                    }
                }
            }
        }

        public bool Remove(AveableSize itemID)
        {
            throw new NotImplementedException();
        }

        public void Update(AveableSize item)
        {
            throw new NotImplementedException();
        }

        private ICollection<AveableSize> CreateAveableSizeList(SqlDataReader reader)
        {
            List<AveableSize> list = new List<AveableSize>();
            while (reader.Read())
            {
                list.Add(CreateAveableSize(reader));
            }
            return list;
        }

        private AveableSize CreateAveableSize(SqlDataReader reader)
        {
            return new AveableSize()
            {
                Id = (Guid)reader[0],
                SIId = (Guid)reader[1],
                Size = (double)reader[2]
            };
        }
    }
}
