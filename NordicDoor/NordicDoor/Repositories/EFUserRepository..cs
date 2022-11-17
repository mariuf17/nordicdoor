using System;
using Microsoft.AspNetCore.Identity;
using NordicDoor.Controllers.Data;
using NordicDoor.Entities;
using static NordicDoor.Controllers.Data.ApplicationDbContext;

namespace NordicDoor.Repositories
{
    public class EFUserRepository : UserRepositoryBase, IUserRepository
    {
        private readonly ApplicationDbContext dataContext;

        public EFUserRepository(ApplicationDbContext dataContext, UserManager<IdentityUser> userManager) : base(userManager)
        {
            this.dataContext = dataContext;
        }

        public void Delete(string email)
        {
            UserEntity? user = GetUserByEmail(email);
            if (user == null)
                return;
            dataContext.Users.Remove(user);
            dataContext.SaveChanges();
        }

        private UserEntity? GetUserByEmail(string email)
        {
            return dataContext.Users.FirstOrDefault(x => x.Email == email);
        }

        public List<UserEntity> GetUsers()
        {
            return dataContext.Users.ToList();
        }

        public void Add(UserEntity user)
        {
            var existingUser = GetUserByEmail(user.Email);
            if (existingUser != null)
            {
                throw new Exception("User already exists found");
            }
            dataContext.Users.Add(user);
            dataContext.SaveChanges();
        }
        public void Update(UserEntity user, List<string> roles)
        {
            var existingUser = GetUserByEmail(user.Email);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            existingUser.Email = user.Email;
            existingUser.EmployeeNumber = user.EmployeeNumber;
            existingUser.Name = user.Name;
            existingUser.Role = user.Role;
            existingUser.Team = user.Team;

            dataContext.SaveChanges();
            SetRoles(user.Email, roles);
        }
    }
}
