using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DALContracts
{
    public interface IInfraDAL
    {
        IDBConnection Connect(string strConnection);
        DataSet ExecuteSPQuery(IDBConnection connection, string spName, params IDBParameter[] parameters);
        DataSet ExecuteQuery(IDBConnection connection, string query);
        IDBParameter InParameter(string paramName, object value);
        IDBParameter OutParameter();
    }
}
