using System;
using System.Collections.Generic;
using System.Text;
using enigma_core.Enums;
using enigma_core.Interfaces;

namespace enigma_core.Models
{
    public class TableFieldValue : IMysqlEntityModels
    {
        public string Field { get => _field; set => _field=value; }
        public string Value { get => _value; set => _value = value; }
        public FieldTypes Type { get => _type; set => _type=value; }
        private string _field { set; get; }
        private string _value { set; get; }
        private string _valueSqlParam { set; get; }
        private FieldTypes _type { set; get; }
        private string _idTable;

        public IMysqlEntityModels addField(string field)
        {
            _field = field;
            return this;
        }

        public IMysqlEntityModels addValue(string value)
        {
            _value = value;
            return this;
        }

        public string getId()
        {
            return _idTable;
        }

        public string getValueSqlParam()
        {
            return "@sql_Param_" + Field;
        }

        public IMysqlEntityModels setId(string id)
        {
            _idTable = id;
            return this;
        }

        public IMysqlEntityModels setType(FieldTypes type)
        {
            _type = type;
            return this;
        }
    }
}
