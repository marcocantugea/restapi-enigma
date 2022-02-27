using System;
using System.Collections.Generic;
using System.Text;
using enigma_core.Models;
using enigma_core.Database;
using enigma_core.Interfaces;
using System.Threading.Tasks;
using System.Reflection;
using MySql.Data.MySqlClient;
using enigma_core.Models.Helpers;

namespace enigma_core.Repository
{
    public class SettingsRepository : ClientMysql, IMysqlRepository<Settings>
    {
        private string repositoryTable = "settings";

        public SettingsRepository()
        {
            SetSettingsDb();
        }

        public Settings Add(Settings item)
        {

            TableFieldsHelper<Settings> tablehelper = new TableFieldsHelper<Settings>();
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

        public async Task<Settings> AddAsync(Settings item)
        {
            TableFieldsHelper<Settings> tablehelper = new TableFieldsHelper<Settings>();
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
            Settings deleteSetting = new Settings();
            deleteSetting.id = id;

            TableFieldsHelper<Settings> tablehelper = new TableFieldsHelper<Settings>();
            List<TableFieldValue> InsertFieldsAndValues = tablehelper.getFieldsValues(deleteSetting);

            string query = tablehelper.getDeleteQuery(deleteSetting);
            await openConnectionAsync();
            MySqlCommand cmd = new MySqlCommand(query, connector);
            cmd.Parameters.AddWithValue(deleteSetting.getSQLparamId(), id);
            await cmd.ExecuteNonQueryAsync();
            await closeConnectionAsync();
        }

        public void Detelete(int id)
        {
            if (id <= 0) throw new Exception("id is invalid");
            Settings deleteSetting = new Settings();
            deleteSetting.id = id;

            TableFieldsHelper<Settings> tablehelper = new TableFieldsHelper<Settings>();
            List<TableFieldValue> InsertFieldsAndValues = tablehelper.getFieldsValues(deleteSetting);

            string query = tablehelper.getDeleteQuery(deleteSetting);
            openConnection();
            MySqlCommand cmd = new MySqlCommand(query, connector);
            cmd.Parameters.AddWithValue(deleteSetting.getSQLparamId(), id);
            cmd.ExecuteNonQuery();
            closeConnection();

        }

        public List<Settings> Find(List<object> paremeters)
        {
            throw new NotImplementedException();
        }

        public Task<List<Settings>> FindAsync(List<object> paremeters)
        {
            throw new NotImplementedException();
        }

        public List<Settings> GetAll(int limitRecords)
        {
            throw new NotImplementedException();
        }

        public Task<List<Settings>> GetAllAsync(int limitRecors)
        {
            throw new NotImplementedException();
        }

        public Settings GetItemById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Settings> GetItemByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void SetSettingsDb()
        {
            server = "localhost";
            db = "cunimed";
            user = "root";
            password = "root";
            createConnection();
        }

        public Settings Update(int id, Settings item)
        {
            TableFieldsHelper<Settings> tablehelper = new TableFieldsHelper<Settings>();
            List<TableFieldValue> InsertFieldsAndValues = tablehelper.getFieldsValues(item);

            string query = tablehelper.getUpdateQuery(id,item);

            openConnection();
            MySqlCommand cmd = new MySqlCommand(query, connector);
            cmd.Parameters.AddWithValue(item.getSQLparamId(),id);
            foreach (TableFieldValue obj in InsertFieldsAndValues)
            {
                if (obj.Field == item.getIdTable()) continue;
                if (obj.Value == "-1") continue;
                cmd.Parameters.AddWithValue(obj.getValueSqlParam(), obj.Value);
            }
            cmd.ExecuteNonQuery();

            closeConnection();

            item.id = id;
            return item;
        }

        public async Task<Settings> UpdateAsync(int id, Settings item)
        {
            TableFieldsHelper<Settings> tablehelper = new TableFieldsHelper<Settings>();
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

            item.id = id;
            return item;
        }

        private static T Cast<T>(T typeHolder, Object x)
        {
            // typeHolder above is just for compiler magic
            // to infer the type to cast x to
            return (T)x;
        }
    }
}
