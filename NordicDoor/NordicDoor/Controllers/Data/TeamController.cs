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

    //GET
    public IActionResult Rediger(int? Ansatt_ID)
    {
        {
            if (Ansatt_ID == null || Ansatt_ID == 0)
                return NotFound();
        }
        var teamFromFirst = _first.Team.Find(Ansatt_ID);
        //var teamFromFirstFirst = _first.Team.FirstOrDefault(u => u.id == id);
        //var teamFromFirstSingle = _first.Team.SingleOrDefault(u => u.id == id);

        if (teamFromFirst == null)
        {
            return NotFound();
        }


        return View(teamFromFirst);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Rediger(Team obj)
    {
        if (obj.Teamnavn == obj.Team_ID.ToString())
        {
            ModelState.AddModelError("CustomError", "Teamnavn og Team_ID kan ikke inneholde like verdier");
        }

        if (ModelState.IsValid)
        {
            _first.Team.Update(obj);
            _first.SaveChanges();
            TempData["suksess"] = "Oppdateringen av brukeren var vellykket";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    //GET
    public IActionResult Slett(int? Ansatt_ID)
    {
        {
            if (Ansatt_ID == null || Ansatt_ID == 0)
                return NotFound();
        }
        var teamFromFirst = _first.Team.Find(Ansatt_ID);
        //var teamFromFirstFirst = _first.Team.FirstOrDefault(u => u.id == id);
        //var teamFromFirstSingle = _first.Team.SingleOrDefault(u => u.id == id);

        if (teamFromFirst == null)
        {
            return NotFound();
        }

        return View(teamFromFirst);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult SlettPOST(int? Ansatt_ID)
    {
        var obj = _first.Team.Find(Ansatt_ID);
        if (obj == null)
        {
            return NotFound();
        }

        _first.Team.Remove(obj);
        _first.SaveChanges();
        TempData["suksess"] = "Slettingen av brukeren var vellykket";
        return RedirectToAction("Index");
    }

}

