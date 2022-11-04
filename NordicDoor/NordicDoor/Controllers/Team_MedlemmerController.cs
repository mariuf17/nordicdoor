using Microsoft.AspNetCore.Mvc;
using NordicDoor.Controllers.Data;
using NordicDoor.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicDoor.Controllers;

public class Team_MedlemmerController : Controller
{
    private readonly ApplicationDbContext _first;

    public Team_MedlemmerController(ApplicationDbContext first)
    {
        _first = first;
    }

    public IActionResult Index()
    {
        IEnumerable < Team_Medlemmer> objTeam_MedlemmerList = _first.Team_Medlemmer;
        return View(objTeam_MedlemmerList);
    }

    //GET
    public IActionResult Opprett()
    {
        return View();
    }

}
