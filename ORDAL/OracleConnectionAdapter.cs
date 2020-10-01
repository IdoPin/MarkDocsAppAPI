using DALContracts;
using DIContracts;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORDAL
{
    [Register(Policy.Transient, typeof(IDBConnection))]
    public class OracleConnectionAdapter : IDBConnection
    {
        public OracleConnection Connection { get; set; }
        public OracleConnectionAdapter()///Todo Complete Contructor
        {

        }
        public void connect(string strConnection)
        {
            Connection = new OracleConnection(strConnection);
        }
    }
}
