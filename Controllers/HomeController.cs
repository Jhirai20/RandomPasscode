using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandomPasscode.Models;

using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("Password", new PasswordGen().GetPassword(14));
            HttpContext.Session.SetInt32("Count", PasswordGen.GetCount());
            ViewBag.Password =  HttpContext.Session.GetString("Password");
            ViewBag.Count = HttpContext.Session.GetInt32("Count");
            return View();
        }
        [HttpGet("/password")]
        public JsonResult Password()
        {
            return Json(new PasswordGen().GetPassword(14));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
