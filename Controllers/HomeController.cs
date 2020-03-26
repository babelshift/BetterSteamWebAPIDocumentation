using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BetterSteamWebAPIDocumentation.Models;
using SteamWebAPI2.Interfaces;
using Microsoft.Extensions.Configuration;
using SteamWebAPI2.Utilities;
using System.Net.Http;

namespace BetterSteamWebAPIDocumentation.Controllers
{
    public class HomeController : Controller
    {
        public static IConfiguration Configuration { get; set; }

        public HomeController(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        [ResponseCache(Duration = 86400, Location = ResponseCacheLocation.Client, NoStore = false)]
        public async Task<IActionResult> Index()
        {
            string steamWebApiKey = Configuration["SteamWebApiKey"];
            var factory = new SteamWebInterfaceFactory(steamWebApiKey);
            var session = factory.CreateSteamWebInterface<SteamWebAPIUtil>(new HttpClient());
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
