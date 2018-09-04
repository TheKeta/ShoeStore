using ShoeShop.Business.Interfaces;
using ShoeStore.Models;
using System;
using System.Data.SqlClient;

namespace ShoeStore.DataAccess
{
    public class PictureRepository : IPictureRepository
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private string _connectionString;
        private string _insertCommand = "INSERT INTO Pictures(Id, ItemId, Image) VALUES(@Id, @ItemId, @Image)";

        public PictureRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Picture Add(Picture item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Picture itemID)
        {
            throw new NotImplementedException();
        }

        public void Update(Picture item)
        {
            throw new NotImplementedException();
        }
    }
}
