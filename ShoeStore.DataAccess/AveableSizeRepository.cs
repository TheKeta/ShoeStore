using ShoeShop.Business.Interfaces;
using ShoeStore.Models;
using System;
using System.Data.SqlClient;

namespace ShoeStore.DataAccess
{
    public class AveableSizeRepository : IAveableSizeRepository
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private string _connectionString;
        private string _insertCommand = "INSERT INTO AveableSizes(Id, SIId, Size) VALUES(@Id, @SIId, @Size)";

        public AveableSizeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public AveableSize Add(AveableSize item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(AveableSize itemID)
        {
            throw new NotImplementedException();
        }

        public void Update(AveableSize item)
        {
            throw new NotImplementedException();
        }
    }
}
