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
                DishesList = new List<string>(InitInfo.DishesCount),
                MembersList = new List<string>(InitInfo.MembersCount)
            };
            //InitList.MembersList.Add("");
            //InitList.MembersList.Add("");
            //InitList.MembersList.Add("");
            //InitList.DishesList.Add("");
            //InitList.DishesList.Add("");
            //InitList.DishesList.Add("");

            return View(InitList);
        }

        [HttpPost]
        public IActionResult GetList(InitialLists InitLists)
        {
            return RedirectToAction(nameof(GetDigits),new Boose(InitLists.MembersList.ToArray(), InitLists.MembersList.ToArray()));
        }
        
        [HttpGet]
        public IActionResult GetDigits(Boose BS)
        {
            return View(BS);
        }
        [HttpPost]
        public IActionResult GetDigits_Post(Boose BS)
        {
            BS.Calcultate();
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
