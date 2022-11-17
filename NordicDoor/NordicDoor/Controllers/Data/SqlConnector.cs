using System;
using MySqlConnector;
using System.Data;
using Microsoft.EntityFrameworkCore;


namespace NordicDoor.Controllers.Data
{
    public class SqlConnector : ISqlConnector
    {
        private readonly IConfiguration config;

        public SqlConnector(IConfiguration config)
        {
            this.config = config;
        }

        public IDbConnection GetDbConnection()
        {
            return new MySqlConnection(config.GetConnectionString("DefaultConnection"));
        }

    }
}
