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
        ViewBag.ForslagIDSortParm = String.IsNullOrEmpty(sortOrder) ? "Forslag_ID_desc" : "";
        ViewBag.BrukerIDSortParm = sortOrder == "Bruker_ID" ? "Bruker_ID_desc" : "Bruker_ID";
        ViewBag.TeamIDSortParm = sortOrder == "Team_ID" ? "Team_ID_desc" : "Team_ID";
        ViewBag.KategoriIDSortParm = sortOrder == "Kategori_ID" ? "Kategori_ID_desc" : "Kategori_ID";
        ViewBag.StartSortParm = sortOrder == "Start_Tid" ? "Start_Tid_desc" : "Start_Tid";
        ViewBag.FristSortParm = sortOrder == "Frist" ? "Frist_desc" : "Frist";
        ViewBag.TittelSortParm = sortOrder == "Tittel" ? "Tittel_desc" : "Tittel";
        ViewBag.AnsvarligSortParm = sortOrder == "Ansvarlig" ? "Ansvarlig_desc" : "Ansvarlig";
        var Forslag = from s in _first.Forslag
                      select s;
        switch (sortOrder)
        {
            case "Forslag_ID_desc":
                Forslag = Forslag.OrderByDescending(s => s.Forslag_ID);
                break;

            case "Bruker_ID":
                Forslag = Forslag.OrderBy(s => s.Bruker_ID);
                break;

            case "Team_ID":
                Forslag = Forslag.OrderBy(s => s.Team_ID);
                break;

            case "Kategori_ID":
                Forslag = Forslag.OrderBy(s => s.Kategori_ID);
                break;

            case "Start_Tid":
                Forslag = Forslag.OrderBy(s => s.Start_Tid);
                break;

            case "Frist":
                Forslag = Forslag.OrderBy(s => s.Frist);
                break;

            case "Tittel":
                Forslag = Forslag.OrderBy(s => s.Tittel);
                break;

            case "Ansvarlig":
                Forslag = Forslag.OrderBy(s => s.Ansvarlig);
                break;

            case "Bruker_ID_desc":
                Forslag = Forslag.OrderByDescending(s => s.Bruker_ID);
                break;

            case "Team_ID_desc":
                Forslag = Forslag.OrderByDescending(s => s.Team_ID);
                break;

            case "Kategori_ID_desc":
                Forslag = Forslag.OrderByDescending(s => s.Kategori_ID);
                break;

            case "Start_Tid_desc":
                Forslag = Forslag.OrderByDescending(s => s.Start_Tid);
                break;

            case "ansvarlig_desc":
                Forslag = Forslag.OrderByDescending(s => s.Ansvarlig);
                break;

            case "frist_desc":
                Forslag = Forslag.OrderByDescending(s => s.Frist);
                break;

            default:
                Forslag = Forslag.OrderBy(s => s.Forslag_ID);
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
    public IActionResult Opprett(Forslag obj)
    {
        if (obj.Ansvarlig == obj.Forslag_ID.ToString())
        {
            ModelState.AddModelError("CustomError", "Forslag_ID og Ansvarlig kan ikke inneholde like verdier");
        }

        if (ModelState.IsValid)
        {
            _first.Forslag.Add(obj);
            _first.SaveChanges();
            TempData["suksess"] = "Opprettingen av forslaget var vellykket";
            return RedirectToAction("Index");
        }
        return View(obj);
    }


    //GET
     public IActionResult Rediger(int? Forslag_ID)
    {
        {
            if (Forslag_ID == null || Forslag_ID == 0)
                return NotFound();
        }
        var forslagFromFirst = _first.Forslag.Find(Forslag_ID);
        //var brukerFromFirstFirst = _first.Bruker.FirstOrDefault(u => u.id == id);
        //var brukerFromFirstSingle = _first.Bruker.SingleOrDefault(u => u.id == id);

        if (forslagFromFirst == null)
        {
            return NotFound();
        }


        return View(forslagFromFirst);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Rediger(Forslag obj)
    {
        if (obj.Ansvarlig == obj.Forslag_ID.ToString())
        {
            ModelState.AddModelError("CustomError", "Navn og Ansatt_ID kan ikke inneholde like verdier");
        }

        if (ModelState.IsValid)
        {
            _first.Forslag.Update(obj);
            _first.SaveChanges();
            TempData["suksess"] = "Oppdateringen av brukeren var vellykket";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    //GET
    public IActionResult Slett(int? Forslag_ID)
    {
        {
            if (Forslag_ID == null || Forslag_ID == 0)
                return NotFound();
        }
        var forslagFromFirst = _first.Bruker.Find(Forslag_ID);
        //var brukerFromFirstFirst = _first.Bruker.FirstOrDefault(u => u.id == id);
        //var brukerFromFirstSingle = _first.Bruker.SingleOrDefault(u => u.id == id);

        if (forslagFromFirst == null)
        {
            return NotFound();
        }

        return View(forslagFromFirst);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult SlettPOST(int? Forslag_ID)
    {
        var obj = _first.Forslag.Find(Forslag_ID);
        if (obj == null)
        {
            return NotFound();
        }

        _first.Forslag.Remove(obj);
        _first.SaveChanges();
        TempData["suksess"] = "Slettingen av brukeren var vellykket";
        return RedirectToAction("Index");
    } 




}

