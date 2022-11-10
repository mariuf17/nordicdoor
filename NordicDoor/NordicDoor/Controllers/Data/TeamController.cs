using Microsoft.AspNetCore.Mvc;
using NordicDoor.Controllers.Data;
using NordicDoor.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicDoor.Controllers;

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

    //GET
    public IActionResult Opprett()
    {
        return View();
    }

}

