using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NordicDoor.Controllers.Data;
using NordicDoor.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicDoor.Controllers;

public class Forslag_StatusController : Controller
{
    //Links the the database server to the data model classes

    private readonly ApplicationDbContext _first;

    public Forslag_StatusController(ApplicationDbContext first)
    {
        _first = first;
    }

    //Returns the statuslist from the database through an IEnumerable to allow readonly access to the list. 
    
    public IActionResult Index()
    {
        IEnumerable<Forslag_Status> objForslag_StatusList = _first.Forslag_Status;
        return View(objForslag_StatusList);
    }

}