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
            //Построить по начальному объекту формы ввода
            //Инициализировать объект Booze. Свойство booze. Инициализация в контейнере.
            //Возвращает объект с параметрами
            return View(InitInfo);
        }
        [HttpPost]
        public IActionResult GetList()
        {
            //Принимает объект с параметрами, инициализирует объект.
            return RedirectToAction(nameof(GetList), InitInfo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
