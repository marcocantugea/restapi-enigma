using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using enigma_core.Interfaces;
using enigma_core.Models;

namespace enigma_core.Models.Helpers
{
    public class TableFieldsHelper<IMIMysqlModel>
    {

        public List<TableFieldValue> getFieldsValues(IMysqlModel item)
        {
            //obtenemos que valores del modelo estan llenos
            List<TableFieldValue> InsertFildsAndValues = new List<TableFieldValue>();
            foreach (PropertyInfo pi in item.GetType().GetProperties())
            {
                var valueInModel = pi.GetValue(item, null)?.ToString();
                if (valueInModel == null) continue;
                if (valueInModel == "-1") continue;
                TableFieldValue obj = new TableFieldValue();
                obj.addField(pi.Name);
                obj.addValue(valueInModel);

                InsertFildsAndValues.Add(obj);
            }

            return InsertFildsAndValues;
        }

        public string getInsertQuery(IMysqlModel item)
        {
            //if (!hasItemsToInsert) throw new Exception("no values to insert");
            List<TableFieldValue> InsertFildsAndValues = (new TableFieldsHelper<IMysqlModel>()).getFieldsValues(item);

            if (InsertFildsAndValues.Count <= 0) throw new Exception("no values to insert");

            //construimos los campos a insertar y los valores a insertar
            string fields = "(";
            string valuesSqlParams = "(";
            int index = 0;
            foreach (TableFieldValue obj in InsertFildsAndValues)
            {

                fields += (index > 0) ? "," : "";
                valuesSqlParams += (index > 0) ? "," : "";
                fields += "`" + obj.Field + "`";
                valuesSqlParams += obj.getValueSqlParam();
                index++;
            }

            fields += ")";
            valuesSqlParams += ")";

            string query = "INSERT INTO " + item.getRepositoryTable() + fields + " VALUES " + valuesSqlParams + ";";

            return query;
        }

        public string getUpdateQuery(int id, IMysqlModel item)
        {
            List<TableFieldValue> InsertFildsAndValues = (new TableFieldsHelper<IMysqlModel>()).getFieldsValues(item);

            if (InsertFildsAndValues.Count <= 0) throw new Exception("no values to insert");

            //construimos los campos a insertar y los valores a insertar
            string fields = "(";
            string valuesSqlParams = "(";
            int index = 0;
            foreach (TableFieldValue obj in InsertFildsAndValues)
            {

                fields += (index > 0) ? "," : "";
                fields += "`" + obj.Field + "`=" + obj.getValueSqlParam();
                index++;
            }

            fields += ")";
            valuesSqlParams += ")";

            string query = "UPDATE " + item.getRepositoryTable() + " SET " + fields + " WHERE " + item.getIdTable() + "= @sql_Param_"+ item.getIdTable();

            return query;
        }

    }
}
