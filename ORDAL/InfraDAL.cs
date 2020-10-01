using DALContracts;
using DIContracts;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ORDAL
{
    [Register(Policy.Transient, typeof(IInfraDAL))]
    public class InfraDAL : IInfraDAL
    {

        public IDBConnection Connect(string strConnection)
        {
            var connection = new OracleConnectionAdapter();
            connection.connect(strConnection);
            return connection; //After Complete ctor complete here
        }

        public DataSet ExecuteQuery(IDBConnection connection, string query)
        {
            var command = new OracleCommand();
            command.CommandText = query;
            command.Connection = (connection as OracleConnectionAdapter).Connection;
            return getDataSet(command);
        }

        public DataSet ExecuteSPQuery(IDBConnection connection, string spName, params IDBParameter[] parameters)
        {
            var command = new OracleCommand();
            command.CommandText = spName;
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = (connection as OracleConnectionAdapter).Connection;

            foreach (var parameter in parameters)
                command.Parameters.Add((parameter as OracleParameterAdapter).Parameter);
            return getDataSet(command);
        }
        private DataSet getDataSet(OracleCommand command)
        {
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(command);
            da.Fill(ds);
            return ds;
        }

        public IDBParameter InParameter(string paramName, object value)
        {
            var inParam = new OracleParameterAdapter();
            inParam.ParameterName = paramName;
            inParam.Value = value;
            return inParam;
        }

        public IDBParameter OutParameter()
        {
            var outParam = new OracleParameter();
            outParam.ParameterName = "PARAM_RETVAL";
            outParam.OracleDbType = OracleDbType.RefCursor;
            outParam.Direction = ParameterDirection.Output;
            return new OracleParameterAdapter() { Parameter = outParam };
        }
    }
}
