using System;
using Dapper;
using NordicDoor.Context;
using System.Data;
using NordicDoor.Models.Users;

namespace NordicDoor.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;
        private readonly ILogger<FileRepository> _logger;

        public UserRepository(DapperContext context, ILogger<FileRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task createUserModel(UserModel userModel)
        {
            var query = "INSERT INTO UserModel (Brukernavn,Epost, Passord, Rolle) VALUES (@Brukernavn,@Epost, @Passord, @Rolle)";

            var parameters = new DynamicParameters();
            parameters.Add("Brukernavn", userModel.Brukernavn, DbType.String);
            //parameters.Add("Bruker_ID", userModel.Bruker_ID, DbType.Int32);
            parameters.Add("Epost", userModel.Epost, DbType.String);
            parameters.Add("Passord", userModel.Passord, DbType.String);
            parameters.Add("Rolle", userModel.Rolle, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public Task<IReadOnlyList<UserModel>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> validateUser(UserModel userModel)
        {
            var parameters = new DynamicParameters();
            var query = "SELECT Brukernavn, Passord, Rolle FROM UserModel WHERE Brukernavn = @Brukernavn AND Passord = @Passord AND Rolle = @Rolle";

            parameters.Add("Rolle", userModel.Rolle, DbType.String);
            parameters.Add("Brukernavn", userModel.Brukernavn, DbType.String);
            parameters.Add("Passord", userModel.Passord, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var wf = connection.QuerySingleOrDefaultAsync<UserModel>(query, parameters);
                var flag = false;
                {
                    flag = true;
                    return flag;
                }
                return flag;
            }
        }
    }
}

