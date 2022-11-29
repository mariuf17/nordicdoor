using Microsoft.AspNetCore.Mvc;
using NordicDoor.Controllers.Data;
using NordicDoor.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicDoor.Controllers;

public class TeamController : Controller

    //Enables database connection
{
    private readonly ApplicationDbContext _first;

    public TeamController(ApplicationDbContext first)
    {
        _first = first;
    }

    //Returns a list of all the teams
    public IActionResult Index()
    {
        IEnumerable<Team> objTeamList = _first.Team;
        return View(objTeamList);
    }

    //GET - Returns an updated view of the teams after addition of a new team
    public IActionResult Opprett()
    {
        return View();
    }

    //GET - Returns an updated view after editing a team
    public IActionResult Rediger(int? Avdeling_ID)
    {
        {
            if (Avdeling_ID == null || Avdeling_ID == 0)
                return NotFound();
        }
        var teamFromFirst = _first.Team.Find(Avdeling_ID);
        //var teamFromFirstFirst = _first.Team.FirstOrDefault(u => u.id == id);
        //var teamFromFirstSingle = _first.Team.SingleOrDefault(u => u.id == id);

        if (teamFromFirst == null)
        {
            return NotFound();
        }


        return View(teamFromFirst);
    }

    //POST - Allows the user to edit an existing team
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Rediger(Team obj)
    {
        if (obj.Teamnavn == obj.Avdeling_ID.ToString())
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

    //GET - Returns an updated view of the teams after removal of one
    public IActionResult Slett(int? Avdeling_ID)
    {
        {
            if (Avdeling_ID == null || Avdeling_ID == 0)
                return NotFound();
        }
        var teamFromFirst = _first.Team.Find(Avdeling_ID);
        //var teamFromFirstFirst = _first.Team.FirstOrDefault(u => u.id == id);
        //var teamFromFirstSingle = _first.Team.SingleOrDefault(u => u.id == id);

        if (teamFromFirst == null)
        {
            return NotFound();
        }

        return View(teamFromFirst);
    }

    //POST - Allows the user to delete a team
    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult SlettPOST(int? Avdeling_ID)
    {
        var obj = _first.Team.Find(Avdeling_ID);
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

