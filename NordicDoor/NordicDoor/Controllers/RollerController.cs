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
        if (obj.Rolle == obj.Bruker_ID.ToString())
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

    //GET
    public IActionResult Rediger(int? Rolle_ID)
    {
        {
            if (Rolle_ID == null || Rolle_ID == 0)
                return NotFound();
        }
        var rollerFromFirst = _first.Roller.Find(Rolle_ID);
        //var brukerFromFirstFirst = _first.Bruker.FirstOrDefault(u => u.id == id);
        //var brukerFromFirstSingle = _first.Bruker.SingleOrDefault(u => u.id == id);

        if (rollerFromFirst == null)
        {
            return NotFound();
        }


        return View(rollerFromFirst);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Rediger(Roller obj)
    {
        if (obj.Rolle == obj.Rolle_ID.ToString())
        {
            ModelState.AddModelError("CustomError", "Rolle og Rolle_ID kan ikke inneholde like verdier");
        }

        if (ModelState.IsValid)
        {
            _first.Roller.Update(obj);
            _first.SaveChanges();
            TempData["suksess"] = "Oppdateringen av rollen var vellykket";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    //GET
    public IActionResult Slett(int? Rolle_ID)
    {
        {
            if (Rolle_ID == null || Rolle_ID == 0)
                return NotFound();
        }
        var rollerFromFirst = _first.Roller.Find(Rolle_ID);
        //var brukerFromFirstFirst = _first.Bruker.FirstOrDefault(u => u.id == id);
        //var brukerFromFirstSingle = _first.Bruker.SingleOrDefault(u => u.id == id);

        if (rollerFromFirst == null)
        {
            return NotFound();
        }

        return View(rollerFromFirst);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult SlettPOST(int? Rolle_ID)
    {
        var obj = _first.Roller.Find(Rolle_ID);
        if (obj == null)
        {
            return NotFound();
        }

        _first.Roller.Remove(obj);
        _first.SaveChanges();
        TempData["suksess"] = "Slettingen av brukeren var vellykket";
        return RedirectToAction("Index");
    }

}

