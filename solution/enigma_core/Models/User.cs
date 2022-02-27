using enigma_core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace enigma_core.Models
{
    public class User : IMysqlModel
    {
        public string userlogin { get; set; }
        public int userid { get; set; } = -1;
        public string password { get; set; }
        public string rol { get; set; }

        public string getIdTable()
        {
            return "userid";
        }

        public int getIdValue()
        {
            return userid;
        }

        public string getRepositoryTable()
        {
            return "usuarios";
        }

        public string getSQLparamId()
        {
            return "@sql_Param_userid";
        }
    }
}
