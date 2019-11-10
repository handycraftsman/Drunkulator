using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Drunkulator.Models;
using Drunkulator.Models.ViewModels;

namespace Drunkulator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private Boose BS;
        public IActionResult Index()
        {
            return View(new InitialInfo());
        }

        [HttpPost]
        public IActionResult Index(InitialInfo InitInfo)
        {
            return RedirectToAction(nameof(GetList),InitInfo);
        }

        public IActionResult GetList(InitialInfo InitInfo)
        {
            InitialLists InitList = new InitialLists()
            {
                DishesList  = new string[InitInfo.DishesCount],
                MembersList = new string[InitInfo.MembersCount]
            };
            return View(InitList);
        }

        [HttpPost]
        public IActionResult GetList(InitialLists InitLists)
        {
            BS = new Boose(InitLists.MembersList, InitLists.DishesList);
            //Serialize to session
            return RedirectToAction(nameof(GetDigits));
        }
        
        public IActionResult GetDigits()
        {
            var a = BS.ToString();
            //Get from session
            return View(BS);
        }
        [HttpPost]
        public IActionResult GetDigits_Post(Boose BS)
        {
            BS.Calcultate();
            //Serialize to session
            return RedirectToAction(nameof(GetDigits), BS);
        }

        public IActionResult Result(Boose BS)
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
