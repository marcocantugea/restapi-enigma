using System;
using System.Collections.Generic;
using System.Text;

namespace enigma_core.Interfaces
{
    public interface IMysqlModel
    {
        string getRepositoryTable();
        string getIdTable();
        string getSQLparamId();
        int getIdValue();
    }
}
