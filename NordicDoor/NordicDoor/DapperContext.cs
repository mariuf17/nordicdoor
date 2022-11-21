using System;
using MySqlConnector;
using System.Data;

namespace NordicDoor
{
        public class DapperContext
        {
            private readonly IConfiguration _configuration;
            private readonly string _connectionString;
            public DapperContext(IConfiguration configuration)
            {
                _configuration = configuration;
                _connectionString = _configuration.GetConnectionString("DefaultConnection");
            }
            public IDbConnection CreateConnection()
                => new MySqlConnection(_connectionString);
        }
 }


