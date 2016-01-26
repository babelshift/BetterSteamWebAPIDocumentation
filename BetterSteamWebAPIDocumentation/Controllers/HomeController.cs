using SteamWebAPI2;
using SteamWebAPI2.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BetterSteamWebAPIDocumentation.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 86400, Location = System.Web.UI.OutputCacheLocation.Server)]
        public async Task<ActionResult> Index()
        {
            string steamWebApiKey = ConfigurationManager.AppSettings["steamWebApiKey"].ToString();
            SteamWebAPIUtil session = new SteamWebAPIUtil(steamWebApiKey);
            var interfaces = await session.GetSupportedAPIListAsync();

            return View(interfaces);
        }
    }
}