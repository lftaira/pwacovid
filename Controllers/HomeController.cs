using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CovidInfo.Models;
using CovidInfo.Services.Interfaces;

namespace CovidInfo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICovidService _covidService;
        private readonly IPushService _pushService;

        public HomeController(ILogger<HomeController> logger, ICovidService CovidService, IPushService PushService)
        {
            _logger = logger;
            _covidService = CovidService;
            _pushService = PushService;
        }

        public async Task<IActionResult> Index()
        {
            var estados = await _covidService.GetEstados();
            return View(estados);
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
