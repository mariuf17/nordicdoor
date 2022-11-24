using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NordicDoor.Controllers.Data;
using NordicDoor.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicDoor.Controllers;

public class Forslag_StatusController : Controller
{
    private readonly ApplicationDbContext _first;

    public Forslag_StatusController(ApplicationDbContext first)
    {
        _first = first;
    }
    public IActionResult Index()
    {
        IEnumerable<Forslag_Status> objForslag_StatusList = _first.Forslag_Status;
        return View(objForslag_StatusList);
    }

    //GET
    public IActionResult Opprett()
    {
        return View();
    }

}