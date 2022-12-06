using HelpMeFixIt.Models;
using HelpMeFixIt.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HelpMeFixIt.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFixersService fixers;

        public HomeController(IFixersService _fixers)
        {
            this.fixers = _fixers;
        }

        public async Task<IActionResult> Index()
        {
            var fixers = await this.fixers.TopThreeFixers();
            return View(fixers);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}