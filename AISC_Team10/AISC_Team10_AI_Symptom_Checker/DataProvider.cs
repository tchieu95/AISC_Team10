using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;
using System.Collections;

namespace AISC_Team10_AI_Symptom_Checker
{
    class DataProvider
    {
        protected static string _connectionString;

        protected SqlConnection connection;
        protected SqlDataAdapter adapter;
        protected SqlCommand command;


        public static string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        public DataProvider()
        {
            connect();
        }

        public void connect()
        {
            _connectionString = ConfigurationSettings.AppSettings["AISC_Team10_Database_ConnectionString"].ToString();
            connection = new SqlConnection(ConnectionString);
            connection.Open();
        }

        public void disconnect()
        {
            connection.Close();
        }

        public void createStoreProcedure(string sProcName)
        {
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = sProcName;
            command.CommandType = CommandType.StoredProcedure;
        }

        public void addParamStoreProcedure(string paramName, Object value)
        {
            command.Parameters.Add(new SqlParameter(paramName, value));
        }

        public void addParamStoreProcedure(SqlParameter param)
        {
            command.Parameters.Add(param);
        }

        public DataTable executeQuery(string sqlString)
        {
            DataSet ds = new DataSet();
            adapter = new SqlDataAdapter(sqlString, connection);
            adapter.Fill(ds);
            return ds.Tables[0];
        }

        public DataTable executeQuery(SqlCommand sqlCommand)
        {
            DataSet ds = new DataSet();
            adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(ds);
            return ds.Tables[0];
        }

        public DataTable executeQuery_StoreProdedure()
        {
            DataSet ds = new DataSet();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            return ds.Tables[0];
        }

        public IDataReader executeQuery_Reader(string sqlString)
        {
            command = new SqlCommand(sqlString, connection);
            return command.ExecuteReader();
        }

        public IDataReader executeQuery_Reader(SqlCommand cmd)
        {
            return cmd.ExecuteReader();
        }

        public IDataReader executeQuery_Reader_StoreProcedure()
        {
            return command.ExecuteReader();
        }

        public void executeNonQuery(string sqlString)
        {
            command = new SqlCommand(sqlString, connection);
            command.ExecuteNonQuery();
        }

        public void executeNonQuery(SqlCommand sqlCommand)
        {
            sqlCommand.ExecuteNonQuery();
        }

        public void executeNonQuery_StoreProdedure()
        {
            command.ExecuteNonQuery();
        }

        public object executeScalar(string sqlString)
        {
            command = new SqlCommand(sqlString, connection);
            return command.ExecuteScalar();
        }

        public object executeScalar(SqlCommand sqlCommand)
        {
            return sqlCommand.ExecuteScalar();
        }

        public object executeScalar_StoreProcedure()
        {
            return command.ExecuteScalar();
        }

        protected ArrayList ConvertDataSetToArrayList(DataSet dataset)
        {
            ArrayList arr = new ArrayList();
            DataTable dt = dataset.Tables[0];
            int i, n = dt.Rows.Count;
            for (i = 0; i < n; i++)
            {
                object obj = GetDataFromDataRow(dt, i);
                arr.Add(obj);

            }
            return arr;
        }

        protected virtual object GetDataFromDataRow(DataTable dt, int i)
        {
            return null;
        }
    }
}
