using System;
using System.Collections.Generic;
using System.Text;
using enigma_core.Enums;

namespace enigma_core.Interfaces
{
    public interface IMysqlEntityModels
    {
        string Field{set;get;}
        string Value { set; get; }
        FieldTypes Type { set; get; }

        IMysqlEntityModels addField(string field);
        IMysqlEntityModels addValue(string value);
        IMysqlEntityModels setType(FieldTypes type);
        string getValueSqlParam();
        IMysqlEntityModels setId(string id);
        string getId();
    }
}
