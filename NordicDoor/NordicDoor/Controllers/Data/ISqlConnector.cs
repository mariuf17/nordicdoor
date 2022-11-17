using System;
using System.Data;

namespace NordicDoor.Controllers.Data
{
    public interface ISqlConnector
    {
        IDbConnection GetDbConnection();
    }
}

