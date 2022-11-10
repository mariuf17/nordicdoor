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
        IEnumerable<Team_Medlemmer> objTeam_MedlemmerList = _first.Team_Medlemmer;
        return View(objTeam_MedlemmerList);
    }

    //GET
    public IActionResult Opprett()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Opprett(Team_Medlemmer obj)
    {
        
        if (ModelState.IsValid)
        {
            _first.Team_Medlemmer.Add(obj);
            _first.SaveChanges();
            TempData["suksess"] = "Opprettingen av brukeren var vellykket";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    //GET
    public IActionResult Rediger(int? Team_ID)
    {
        {
            if (Team_ID == null || Team_ID == 0)
                return NotFound();
        }
        var team_medlemmerFromFirst = _first.Team_Medlemmer.Find(Team_ID);
        //var team_medlemmerFromFirstFirst = _first.Team_Medlemmer.FirstOrDefault(u => u.id == id);
        //var team_medlemmerFromFirstSingle = _first.Team_Medlemmer.SingleOrDefault(u => u.id == id);

        if (team_medlemmerFromFirst == null)
        {
            return NotFound();
        }


        return View(team_medlemmerFromFirst);
    }

    //GET
    public IActionResult Slett(int? Ansatt_ID)
    {
        {
            if (Ansatt_ID == null || Ansatt_ID == 0)
                return NotFound();
        }
        var team_medlemmerFromFirst = _first.Team_Medlemmer.Find(Ansatt_ID);
        //var team_medlemmerFromFirstFirst = _first.Team_Medlemmer.FirstOrDefault(u => u.id == id);
        //var team_medlemmerFromFirstSingle = _first.Team_Medlemmer.SingleOrDefault(u => u.id == id);

        if (team_medlemmerFromFirst == null)
        {
            return NotFound();
        }

        return View(team_medlemmerFromFirst);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult SlettPOST(int? Ansatt_ID)
    {
        var obj = _first.Team_Medlemmer.Find(Ansatt_ID);
        if (obj == null)
        {
            return NotFound();
        }

        _first.Team_Medlemmer.Remove(obj);
        _first.SaveChanges();
        TempData["suksess"] = "Slettingen av brukeren var vellykket";
        return RedirectToAction("Index");
    }
}

