using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Drunkulator.Models;
using Drunkulator.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Drunkulator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //private Boose BS;
        public IActionResult Index()
        {
            ViewBag.Digits1 = new SelectList( new List<int> { 2, 3, 4, 5 });
            ViewBag.Digits2 = new SelectList(new List<int> { 1, 2, 3, 4, 5 });
            return View(new InitialInfo());
        }
        //Получаем количество гостей и блюд
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
            Boose BS = new Boose(InitLists.MembersList, InitLists.DishesList);
            //return RedirectToAction(nameof(GetDigits),BS);
            return View(nameof(GetDigits), BS);
        }
        
        public IActionResult GetDigits(Boose BS)
        {
            var a = BS.ToString();
            return View(BS);
        }
        [HttpPost]
        public IActionResult GetDigits_Post(Boose BS)
        {
            BS.Calcultate();
            //return RedirectToAction(nameof(GetDigits), BS);
            return View(nameof(Result), BS);
        }

        public IActionResult Result(Boose BS)
        {
            return View(BS);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
