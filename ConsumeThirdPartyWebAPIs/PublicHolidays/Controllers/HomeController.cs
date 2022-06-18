using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PublicHolidays.Models;
using PublicHolidays.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PublicHolidays.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHolidaysApiService _holidaysApiService;

        public HomeController(IHolidaysApiService holidaysApiService)
        {
            _holidaysApiService = holidaysApiService;
        }

        public async Task<IActionResult> Index(string countryCode, int year)
        {
            var holiday = new List<HolidayModel>();

            if (!string.IsNullOrEmpty(countryCode) && year > 0)
            {
                holiday = await _holidaysApiService.GetHolidaysAsync(countryCode, year);
            }

            return View(holiday);
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
