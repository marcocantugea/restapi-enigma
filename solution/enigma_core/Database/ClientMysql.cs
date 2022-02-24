using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace enigma_core.Database
{
    public class ClientMysql
    {

        protected MySqlConnection _connector = new MySqlConnection();
        private string _server = "";
        private string _db = "";
        private string _user;
        private string _pass = "";
        private string _port = "3306";
        private string connectionString = "";

        public string server { set => _server = value; get => _server; }
        public string db { set => _db=value; get => _db; }
        public string user { set => _user = value; }
        public string password { set => _pass = value; }
        public string port { set => _port = value; }
        public MySqlConnection connector { get => _connector; }

        protected string createConnection()
        {
            connectionString = "Server="+ _server +";Port="+ _port +";Database="+ _db +";Uid="+ _user +";Pwd="+_pass+";";
            connector.ConnectionString = connectionString;
            return connectionString;
        }

        public ClientMysql()
        {
           
        }

        protected ClientMysql openConnection()
        {
            try
            {
                connector.Open();
            }
            catch (MySqlException sqlException)
            {
                throw;
            }catch (Exception e)
            {
                throw;
            }

            return this;
        }

        protected async Task<ClientMysql> openConnectionAsync()
        {
            try
            {
                await connector.OpenAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return this;
        }

        protected ClientMysql closeConnection()
        {

            if (connector.State == System.Data.ConnectionState.Closed) return this;

            connector.Close();

            return this;
        }

        protected async Task<ClientMysql> closeConnectionAsync()
        {
            if (connector.State == System.Data.ConnectionState.Closed) return this;

            await connector.CloseAsync();

            return this;
        }
    }
}
