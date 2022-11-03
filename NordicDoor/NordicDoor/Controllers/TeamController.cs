using Microsoft.AspNetCore.Mvc;
using NordicDoor.Controllers.Data;
using NordicDoor.Models;

namespace NordicDoor.Controllers
{
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext _first;

        public TeamController(ApplicationDbContext first)
        {
            _first = first;
        }
        public IActionResult Index()
        {
            IEnumerable<Team> objTeamList = _first.Team;
            return View(objTeamList);
        }                                                                                                   
    }
}
