using Microsoft.AspNetCore.Mvc;
using NordicDoor.Controllers.Data;
using NordicDoor.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicDoor.Controllers;

public class BrukerController : Controller
{
    private readonly ApplicationDbContext _first;

    public BrukerController(ApplicationDbContext first)
    {
        _first = first;
    }

    public IActionResult Index()
    {
        IEnumerable<Bruker> objBrukerList = _first.Bruker;
        return View(objBrukerList);
    }

    //GET
    public IActionResult Opprett()
    {
        return View();
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Opprett(Bruker obj )
    {
        if (ModelState.IsValid)
        {
            _first.Bruker.Add(obj);
            _first.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(obj);
    }
}
