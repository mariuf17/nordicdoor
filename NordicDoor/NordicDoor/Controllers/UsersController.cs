﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NordicDoor.Entities;
using NordicDoor.Models.Users;
using NordicDoor.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicDoor.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult Index(string? email)
        {
            var model = new UserViewModel();
            model.Users = userRepository.GetUsers();
            if (email != null)
            {
                var currentUser = model.Users.FirstOrDefault(x => x.Email == email);
                if (currentUser != null)
                {
                    model.EmployeeNumber = currentUser.EmployeeNumber;
                    model.Email = currentUser.Email;
                    model.Name = currentUser.Name;
                    model.Role = currentUser.Role;
                    model.Team = currentUser.Team;
                    model.IsAdmin = userRepository.IsAdmin(currentUser.Email);
                }
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Save(UserViewModel model)
        {

            UserEntity newUser = new UserEntity
            {
                Name = model.Name,
                Email = model.Email,
                EmployeeNumber = model.EmployeeNumber,
                Role = model.Role,
                Team = model.Team,
            };
            var roles = new List<string>();
            if (model.IsAdmin)
                roles.Add("Administrator");
            userRepository.Update(newUser, roles);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(string email)
        {
            userRepository.Delete(email);
            return RedirectToAction("Index");
        }
    }
}