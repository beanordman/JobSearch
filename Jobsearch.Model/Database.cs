using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Jobsearch.Model
{
    public class Database : IDisposable
    {
        private const string AllClientsSql = "SELECT * FROM clients";
       
        private const string ClientJobJoinSql =
            "SELECT clients.Name, clients.Contact, jobs.Specification " +
            "FROM clients, jobs " +
            "WHERE jobs.ClientID = clients.ID " +
            "ORDER BY clients.Name";

        private const string ClientJobLeftJoinSql =
                "SELECT clients.Name, clients.Contact, jobs.Specification " +
                "FROM clients, jobs " +
                "LEFT JOIN jobs " +
                "ON clients.ID = jobs.ClientID" +
                "ORDER BY clients.Name";

        private MySqlConnection _connection;

        public Database()
        {
            const string myConString = "User ID=root;Password=root321;Host=localhost;Port=3306;Database=job_search;";

            _connection = new MySqlConnection(myConString);
        }

        public DataTable Clients
        {
            get { return ExecuteQuery(AllClientsSql); }
        }

        public DataTable ClientJobs
        {
            get { return ExecuteQuery(ClientJobJoinSql); }
        }

        private DataTable ExecuteQuery(string sql)
        {
            // TODO: Exception handling / logging

            using (var cmd = new MySqlCommand(sql, _connection))
            {
                var dataTable = new DataTable("ClientDataTable");
                var adapter = new MySqlDataAdapter(cmd);

                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        #region IDisposable implementation

        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            // TODO: might want to do some locking for MT access

            if (!disposing || _disposed) 
                return;

            if (_connection == null) 
                return;

            _connection.Close();
            _connection = null;
            _disposed = true;
        }

        ~Database()
        {
            Dispose(false);
        }

        #endregion
    }
}
