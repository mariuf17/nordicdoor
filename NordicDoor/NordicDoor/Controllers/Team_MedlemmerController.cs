using Microsoft.AspNetCore.Mvc;
using NordicDoor.Controllers.Data;
using NordicDoor.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicDoor.Controllers;

public class Team_MedlemmerController : Controller

    //Enables database connection
{
    private readonly ApplicationDbContext _first;

    public Team_MedlemmerController(ApplicationDbContext first)
    {
        _first = first;
    }

    //Returns a view of all the team members, including a function that allows the user to sort the team members in descending or ascending order
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
      
        //GET - Returns an updated view after creation of a new team member
        public IActionResult Opprett()
        {
            return View();
        }

        //POST - Allows the user to add a new team member
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

    }

