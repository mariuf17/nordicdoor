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

    public ActionResult Index(string sortOrder)
    {
        ViewBag.Bruker_ID_SortParm = String.IsNullOrEmpty(sortOrder) ? "Team_ID_desc" : "";
        ViewBag.Team_ID_SortParm = sortOrder == "Bruker_ID" ? "Bruker_ID_desc" : "Bruker_ID";

        var Team_Medlemmer = from s in _first.Team_Medlemmer
                             select s;
        switch (sortOrder)
        {
            case "Bruker_ID_desc":
                Team_Medlemmer = Team_Medlemmer.OrderByDescending(s => s.Bruker_ID);
                break;

            case "Team_ID":
                Team_Medlemmer = Team_Medlemmer.OrderBy(s => s.Team_ID);
                break;
            case "Team_ID_desc":
                Team_Medlemmer = Team_Medlemmer.OrderByDescending(s => s.Team_ID);
                break;
            default:
                Team_Medlemmer = Team_Medlemmer.OrderBy(s => s.Bruker_ID);
                break;
        }
        return View(Team_Medlemmer.ToList());
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

