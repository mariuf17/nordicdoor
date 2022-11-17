using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NordicDoor.Models.Suggestions;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NordicDoor.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SuggestionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(SuggestionViewModel model)
        {
            if (!ModelState.IsValid)
                throw new Exception("Dette gikk dårlig");
            if (string.IsNullOrWhiteSpace(model.Name))
                throw new ArgumentException();
            return null;
        }
    }
}