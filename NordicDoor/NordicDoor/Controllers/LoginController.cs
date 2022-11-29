using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NordicDoor.Models.Users;
using NordicDoor.Repositories;


namespace NordicDoor.Controllers

    //Routes the request to the controller, and automatically checks the model state
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller

    //Implements the logger and userrepository
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUserRepository _userRepository;

        
        public LoginController(ILogger<LoginController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        //Returns the login view

        public ActionResult Index()
        {
            return View();
        }


        //Redirects the user to the homepage if the login is successfull 
        [HttpPost("/Validate")]
        public async Task<IActionResult> Validation([FromForm] UserModel userModel)
        {
            try
            {
                _logger.LogInformation(userModel.Brukernavn);
                _logger.LogInformation(userModel.Passord);

                var flag = await _userRepository.validateUser(userModel);
                if (flag == true)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return BadRequest("Incorrect details....");
                }

            }
            catch (Exception ex)
            {
                //log error
                _logger.LogInformation(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}

