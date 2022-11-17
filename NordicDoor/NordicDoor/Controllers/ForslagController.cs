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
    public ActionResult Index(string sortOrder)
    {
        ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Team_ID_desc" : "";
        ViewBag.DateSortParm = sortOrder == "Frist" ? "frist_desc" : "Frist";
        var Forslag = from s in _first.Forslag
                      select s;
        switch (sortOrder)
        {
            case "Team_ID_desc":
                Forslag = Forslag.OrderByDescending(s => s.Team_ID);
                break;
            case "Frist":
                Forslag = Forslag.OrderBy(s => s.Frist);
                break;
            case "frist_desc":
                Forslag = Forslag.OrderByDescending(s => s.Frist);
                break;
            default:
                Forslag = Forslag.OrderBy(s => s.Team_ID);
                break;
        }
        return View(Forslag.ToList());
    }

    //GET
    public IActionResult Opprett()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Opprett(Bruker obj)
    {
        if (obj.Navn == obj.Bruker_ID.ToString())
        {
            ModelState.AddModelError("CustomError", "Navn og Ansatt_ID kan ikke inneholde like verdier");
        }

        if (ModelState.IsValid)
        {
            _first.Bruker.Add(obj);
            _first.SaveChanges();
            TempData["suksess"] = "Opprettingen av brukeren var vellykket";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    

}

