using System;
using System.Collections.Generic;
using System.Text;
using enigma_core.Interfaces;

namespace enigma_core.Models
{
    public class Settings : IMysqlModel
    {
        public int id { set; get; } = -1;
        public string key { set; get; }
        public string display_name { set; get; }
        public string value { set; get; }
        public string details { set; get; }
        public string type { set; get; }
        public int order { set; get; }
        public string group { set; get; }

        private string _repositoryTable = "settings";

        public string getIdTable()
        {
            return "id";
        }

        public string getRepositoryTable()
        {
            return _repositoryTable;
        }

        public string getSQLparamId()
        {
            return "@sql_Param_id";
        }

        public int getIdValue()
        {
            return id;
        }
    }
}
