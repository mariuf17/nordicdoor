using Microsoft.AspNetCore.Mvc;
using NordicDoor.Controllers.Data;
using NordicDoor.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicDoor.Controllers;

public class BrukerController : Controller
{
    //Links the the database server to the data model classes

    private readonly ApplicationDbContext _first;

    public BrukerController(ApplicationDbContext first)
    {
        _first = first;
    }

    // Returns a list of all users, and adds a sorting function by transfering temporary data from the viewbag

    public IActionResult Index(string sortOrder)
    {
        ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "navn_desc" : "";
        ViewBag.EmployeeSortParm = sortOrder == "Bruker_ID" ? "Bruker_ID_desc" : "Bruker_ID";
        ViewBag.EmailSortParm = sortOrder == "Epost" ? "epost_desc" : "Epost";
        ViewBag.PhoneSortParm = sortOrder == "Telefon" ? "telefon_desc" : "Telefon";
        ViewBag.PostSortParm = sortOrder == "Postnummer" ? "postnummer_desc" : "Postnummer";

        var Bruker = from s in _first.Bruker
                      select s;
        switch (sortOrder)
        {
            case "navn_desc":
                Bruker = Bruker.OrderByDescending(s => s.Navn);
                break;

            case "Bruker_ID":
                Bruker = Bruker.OrderBy(s => s.Bruker_ID);
                break;

            case "Epost":
            Bruker = Bruker.OrderBy(s => s.Epost);
                break;

            case "Telefon":
            Bruker = Bruker.OrderBy(s => s.Telefon);
                break;

            case "Postnummer":
            Bruker = Bruker.OrderBy(s => s.Postnummer);
                break;

            case "Bruker_ID_desc":
                Bruker = Bruker.OrderByDescending(s => s.Bruker_ID);
                break;

            case "epost_desc":
                Bruker = Bruker.OrderByDescending(s => s.Epost);
                break;

            case "telefon_desc":
                Bruker = Bruker.OrderByDescending(s => s.Telefon);
                break;

            case "postnummer_desc":
                Bruker = Bruker.OrderByDescending(s => s.Postnummer);
                break;

            default:
                Bruker = Bruker.OrderBy(s => s.Navn);
                break;
        }
        return View(Bruker.ToList());
    }

    //GET - Enables the user to view the data, but not change the state
    public IActionResult Opprett()
    {
        return View();
    }

    //POST - Enables the user to change the data and add a new user
    [HttpPost]
    [ValidateAntiForgeryToken] // Prevents cross site request forgeries
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


    //GET - Enables the user to view the data, but not change the state
    public IActionResult Rediger(int? Bruker_ID)
    {
        {
            if (Bruker_ID == null || Bruker_ID == 0)
                return NotFound();
        }
        var brukerFromFirst = _first.Bruker.Find(Bruker_ID);
        //var brukerFromFirstFirst = _first.Bruker.FirstOrDefault(u => u.id == id);
        //var brukerFromFirstSingle = _first.Bruker.SingleOrDefault(u => u.id == id);

        if(brukerFromFirst == null)
        {
            return NotFound();
        }


        return View(brukerFromFirst);
    }

    //POST - Enables the user to change the data and edit an existing user
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Rediger(Bruker obj)
    {
        if (obj.Navn == obj.Bruker_ID.ToString())
        {
            ModelState.AddModelError("CustomError", "Navn og Ansatt_ID kan ikke inneholde like verdier");
        }

        if (ModelState.IsValid)
        {
            _first.Bruker.Update(obj);
            _first.SaveChanges();
            TempData["suksess"] = "Oppdateringen av brukeren var vellykket";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    //GET - Enables the user to view the data, but not change the state
    public IActionResult Slett(int? Bruker_ID)
    {
        {
            if (Bruker_ID == null || Bruker_ID == 0)
                return NotFound();
        }
        var brukerFromFirst = _first.Bruker.Find(Bruker_ID);
        //var brukerFromFirstFirst = _first.Bruker.FirstOrDefault(u => u.id == id);
        //var brukerFromFirstSingle = _first.Bruker.SingleOrDefault(u => u.id == id);

        if (brukerFromFirst == null)
        {
            return NotFound();
        }

        return View(brukerFromFirst);
    }

    //POST - Enables the user to change the data and delete a user
    [HttpPost,ActionName("Slett")]
    [ValidateAntiForgeryToken]

    public IActionResult SlettPOST(int? Bruker_ID)
    {
        var obj = _first.Bruker.Find(Bruker_ID);
        if (obj == null)
        {
            return NotFound();
        }

        _first.Bruker.Remove(obj);
        _first.SaveChanges();
        TempData["suksess"] = "Slettingen av brukeren var vellykket";
        return RedirectToAction("Index");
    }

  
}