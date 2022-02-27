using System;
using System.Collections.Generic;
using System.Text;
using enigma_core.Models;
using enigma_core.Interfaces;
using enigma_core.Database;
using System.Threading.Tasks;
using enigma_core.Models.Helpers;
using MySql.Data.MySqlClient;

namespace enigma_core.Repository
{
    public class UserRepository : ClientMysql, IMysqlRepository<User>
    {
        public void SetSettingsDb()
        {
            server = "localhost";
            db = "erpsistema";
            user = "root";
            password = "root";
            createConnection();
        }

        public UserRepository()
        {
            SetSettingsDb();
        }

        public User Add(User item)
        {
            TableFieldsHelper<User> tablehelper = new TableFieldsHelper<User>();
            List<TableFieldValue> InsertFieldsAndValues = tablehelper.getFieldsValues(item);

            string query = tablehelper.getInsertQuery(item);

            openConnection();
            MySqlCommand cmd = new MySqlCommand(query, connector);
            foreach (TableFieldValue obj in InsertFieldsAndValues)
            {
                cmd.Parameters.AddWithValue(obj.getValueSqlParam(), obj.Value);
            }

            cmd.ExecuteNonQuery();

            closeConnection();
            return item;
        }

        public async Task<User> AddAsync(User item)
        {
            TableFieldsHelper<User> tablehelper = new TableFieldsHelper<User>();
            List<TableFieldValue> InsertFieldsAndValues = tablehelper.getFieldsValues(item);

            string query = tablehelper.getInsertQuery(item);

            await openConnectionAsync();
            MySqlCommand cmd = new MySqlCommand(query, connector);
            foreach (TableFieldValue obj in InsertFieldsAndValues)
            {
                cmd.Parameters.AddWithValue(obj.getValueSqlParam(), obj.Value);
            }

            await cmd.ExecuteNonQueryAsync();

            await closeConnectionAsync();

            return item;
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("id is invalid");
            User deleteUser = new User();
            deleteUser.userid= id;

            TableFieldsHelper<User> tablehelper = new TableFieldsHelper<User>();
            List<TableFieldValue> InsertFieldsAndValues = tablehelper.getFieldsValues(deleteUser);

            string query = tablehelper.getDeleteQuery(deleteUser);
            await openConnectionAsync();
            MySqlCommand cmd = new MySqlCommand(query, connector);
            cmd.Parameters.AddWithValue(deleteUser.getSQLparamId(), id);
            await cmd.ExecuteNonQueryAsync();
            await closeConnectionAsync();
        }

        public void Detelete(int id)
        {
            if (id <= 0) throw new Exception("id is invalid");
            User deleteUser = new User();
            deleteUser.userid = id;

            TableFieldsHelper<User> tablehelper = new TableFieldsHelper<User>();
            List<TableFieldValue> InsertFieldsAndValues = tablehelper.getFieldsValues(deleteUser);

            string query = tablehelper.getDeleteQuery(deleteUser);
            openConnection();
            MySqlCommand cmd = new MySqlCommand(query, connector);
            cmd.Parameters.AddWithValue(deleteUser.getSQLparamId(), id);
            cmd.ExecuteNonQuery();
            closeConnection();
        }

        public List<User> Find(List<object> paremeters)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> FindAsync(List<object> paremeters)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll(int limitRecords)
        {
            string query = "SELECT userid, userlogin, password from usuarios limit @sql_param_limit";
            openConnection();
            MySqlCommand cmd = new MySqlCommand(query, connector);
            cmd.Parameters.AddWithValue("@sql_param_limit", limitRecords);

            MySqlDataReader reader = cmd.ExecuteReader();

            List<User> users = new List<User>();
            while (reader.Read())
            {
                User itemuser = new User();
                itemuser.userid = reader.GetInt32(0);
                itemuser.userlogin = reader.GetString(1);
                itemuser.password = reader.GetString(2);
                users.Add(itemuser);
            }

            closeConnection();

            return users;
        }

        public async Task<List<User>> GetAllAsync(int limitRecors)
        {
            string query = "SELECT userid, userlogin, password from usuarios limit @sql_param_limit";
            await openConnectionAsync();
            MySqlCommand cmd = new MySqlCommand(query, connector);
            cmd.Parameters.AddWithValue("@sql_param_limit", limitRecors);

            var reader = await cmd.ExecuteReaderAsync();

            List<User> users = new List<User>();
            while (reader.Read())
            {
                User itemuser = new User();
                itemuser.userid = reader.GetInt32(0);
                itemuser.userlogin = reader.GetString(1);
                users.Add(itemuser);
            }

            await closeConnectionAsync();

            return users;
        }

        public User GetItemById(int id)
        {
            string query = "SELECT userid, userlogin, password from usuarios where userid=@sql_param_userid"; 
            openConnection();
            MySqlCommand cmd = new MySqlCommand(query, connector);
            cmd.Parameters.AddWithValue("@sql_param_userid", id);

            MySqlDataReader reader = cmd.ExecuteReader();

            User itemuser = new User();
            while (reader.Read())
            {
                itemuser.userid = reader.GetInt32(0);
                itemuser.userlogin = reader.GetString(1);
                itemuser.password = reader.GetString(2);
            }

            closeConnection();

            return itemuser;
        }

        public Task<User> GetItemByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public User Update(int id, User item)
        {
            TableFieldsHelper<User> tablehelper = new TableFieldsHelper<User>();
            List<TableFieldValue> InsertFieldsAndValues = tablehelper.getFieldsValues(item);

            string query = tablehelper.getUpdateQuery(id, item);

            openConnection();
            MySqlCommand cmd = new MySqlCommand(query, connector);
            cmd.Parameters.AddWithValue(item.getSQLparamId(), id);
            foreach (TableFieldValue obj in InsertFieldsAndValues)
            {
                if (obj.Field == item.getIdTable()) continue;
                if (obj.Value == "-1") continue;
                cmd.Parameters.AddWithValue(obj.getValueSqlParam(), obj.Value);
            }
            cmd.ExecuteNonQuery();

            closeConnection();

            item.userid = id;
            return item;
        }

        public async Task<User> UpdateAsync(int id, User item)
        {
            TableFieldsHelper<User> tablehelper = new TableFieldsHelper<User>();
            List<TableFieldValue> InsertFieldsAndValues = tablehelper.getFieldsValues(item);

            string query = tablehelper.getUpdateQuery(id, item);

            await openConnectionAsync();
            MySqlCommand cmd = new MySqlCommand(query, connector);
            cmd.Parameters.AddWithValue(item.getSQLparamId(), id);
            foreach (TableFieldValue obj in InsertFieldsAndValues)
            {
                if (obj.Field == item.getIdTable()) continue;
                if (obj.Value == "-1") continue;
                cmd.Parameters.AddWithValue(obj.getValueSqlParam(), obj.Value);
            }
            await cmd.ExecuteNonQueryAsync();

            await closeConnectionAsync();

            item.userid = id;
            return item;
        }
    }
}
