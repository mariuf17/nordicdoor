using Microsoft.AspNetCore.Mvc;
using NordicDoor.Controllers.Data;
using NordicDoor.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicDoor.Controllers;

public class ForslagController : Controller
{
    private readonly ApplicationDbContext _first;

    public ForslagController(ApplicationDbContext first)
    {
        _first = first;
    }
    public IActionResult Index()
    {

        IEnumerable<Forslag> objForslagList = _first.Forslag;
        return View(objForslagList);
    }

}

