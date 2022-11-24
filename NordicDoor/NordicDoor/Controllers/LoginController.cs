using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NordicDoor.Models.Users;
using NordicDoor.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicDoor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUserRepository _userRepository;


        public LoginController(ILogger<LoginController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }
        
        //https://localhost:5100/Login
        public IActionResult Index()
        {
            return View();
        }


        //https://localhost:5100/Registration
        [HttpPost("/Registration")]
        public async Task<IActionResult> Registration([FromForm] UserModel userModel)
        {
            try
            {
                _logger.LogInformation(userModel.Epost);
                _logger.LogInformation(userModel.Brukernavn);

                await _userRepository.createUserModel(userModel);

                return Ok("Inserted........");
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogInformation(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        //https://localhost:5100/Registration
        [HttpPost("/Validate")]
        public async Task<IActionResult> Validation([FromForm] UserModel userModel)
        {
            try
            {
                _logger.LogInformation(userModel.Epost);
                _logger.LogInformation(userModel.Brukernavn);

                var flag = await _userRepository.validateUser(userModel);
                if (flag == true)
                {
                    return Ok("Validate........");
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

