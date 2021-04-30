using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace RedArbor.DAL.Admin
{
    public abstract class Base 
    {
        private readonly string _stringConnection;
        private readonly SqlConnection _sqlConnection;
        protected SqlConnection sqlConnection
        {
            get
            {
                return _sqlConnection;
            }
        }
        public Base(IConfiguration configuration)
        {
            _stringConnection = configuration.GetConnectionString("redarborDatabase");
            _sqlConnection = new SqlConnection(_stringConnection);
        }

    }
}
