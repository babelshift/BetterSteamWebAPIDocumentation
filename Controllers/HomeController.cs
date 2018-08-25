using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BetterSteamWebAPIDocumentation.Models;
using SteamWebAPI2.Interfaces;
using Microsoft.Extensions.Configuration;

namespace BetterSteamWebAPIDocumentation.Controllers
{
    public class HomeController : Controller
    {
        public static IConfiguration Configuration { get; set; }

        public HomeController(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            string steamWebApiKey = Configuration.GetValue<string>("SteamWebApiKey");
            SteamWebAPIUtil session = new SteamWebAPIUtil(steamWebApiKey);
            var interfaces = await session.GetSupportedAPIListAsync();

            return View(interfaces.Data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
