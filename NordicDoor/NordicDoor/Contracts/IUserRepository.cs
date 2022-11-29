using System;
using NordicDoor.Models.Users;

namespace NordicDoor.Repositories
{
    public interface IUserRepository
    {
        public Task<IReadOnlyList<UserModel>> GetUsers();
        public Task<bool> validateUser(UserModel userModel);
        public Task createUserModel(UserModel userModel);
    }
}