using DALContracts;
using DIContracts;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORDAL
{

    public class OracleParameterAdapter : IDBParameter
    {
        public OracleParameter Parameter { get; set; }

        public OracleParameterAdapter()
        {
            Parameter = new OracleParameter();
        }
        public string ParameterName { get => Parameter.ParameterName; set => Parameter.ParameterName = value; }
        public object Value { get => Parameter.Value; set => Parameter.Value = value; }
    }
}
