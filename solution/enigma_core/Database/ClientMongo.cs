using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace enigma_core.Database
{
    public class ClientMongo
    {
        private MongoClient _client;
        private IMongoDatabase _db;
        private string _connectionString;
        private string _dataBaseName = "enigma_db";

        protected MongoDB.Driver.MongoClient client { get =>_client; }
        protected IMongoDatabase db { get => _db; }
        public string connectionString { get => _connectionString; set => _connectionString = value; }
        public string dataBaseName { get => _dataBaseName; set => _dataBaseName = value;  }

        public ClientMongo(bool createDefaultDataBase=false)
        {
            string connectionString = (String.IsNullOrEmpty(_connectionString)) ? "mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false" : _connectionString;
            _client = new MongoClient(connectionString);
            if (createDefaultDataBase) createDataBase();
        }

        protected void createDataBase()
        {
            _db = _client.GetDatabase(_dataBaseName);
        }

    }
}
