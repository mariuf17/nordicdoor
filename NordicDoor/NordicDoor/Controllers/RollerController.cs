using Microsoft.AspNetCore.Mvc;
using NordicDoor.Controllers.Data;
using NordicDoor.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicDoor.Controllers;

public class RollerController : Controller
{
    private readonly ApplicationDbContext _first;

    public RollerController(ApplicationDbContext first)
    {
        _first = first;
    }
    public IActionResult Index()
    {
        IEnumerable<Roller> objRollerList = _first.Roller;
        return View(objRollerList);
    }

    //GET
    public IActionResult Opprett()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Opprett(Roller obj)
    {
        if (obj.Ansvar == obj.Bruker_ID.ToString())
        {
            ModelState.AddModelError("CustomError", "Ansvar og Ansattnummer kan ikke inneholde like verdier");
        }

        if (ModelState.IsValid)
        {
            _first.Roller.Add(obj);
            _first.SaveChanges();
            TempData["suksess"] = "Opprettingen av rollen var vellykket";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

}

