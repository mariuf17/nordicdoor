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
    public IActionResult Opprett(Bruker obj)
    {
        if (obj.Navn == obj.Ansatt_ID.ToString())
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


    //GET
    public IActionResult Rediger(int? Ansatt_ID)
    {
        {
            if (Ansatt_ID==null || Ansatt_ID==0)
                return NotFound();
        }
        var brukerFromFirst = _first.Bruker.Find(Ansatt_ID);
        //var brukerFromFirstFirst = _first.Bruker.FirstOrDefault(u => u.id == id);
        //var brukerFromFirstSingle = _first.Bruker.SingleOrDefault(u => u.id == id);

        if(brukerFromFirst == null)
        {
            return NotFound();
        }


        return View(brukerFromFirst);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Rediger(Bruker obj)
    {
        if (obj.Navn == obj.Ansatt_ID.ToString())
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

    //GET
    public IActionResult Slett(int? Ansatt_ID)
    {
        {
            if (Ansatt_ID == null || Ansatt_ID == 0)
                return NotFound();
        }
        var brukerFromFirst = _first.Bruker.Find(Ansatt_ID);
        //var brukerFromFirstFirst = _first.Bruker.FirstOrDefault(u => u.id == id);
        //var brukerFromFirstSingle = _first.Bruker.SingleOrDefault(u => u.id == id);

        if (brukerFromFirst == null)
        {
            return NotFound();
        }

        return View(brukerFromFirst);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult SlettPOST(int? Ansatt_ID)
    {
        var obj = _first.Bruker.Find(Ansatt_ID);
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