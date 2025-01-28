﻿using System.Data;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Context
{
    public class DapperDbContext
    {
        private readonly string _connectionString;

        public DapperDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
