using Exercise2WebApp.Helper;
using Exercise2WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Exercise2WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //contact API
        RandomAPI _api = new RandomAPI();

        public async Task<IActionResult> Index()
        {
            List<clsRandom> random = new List<clsRandom>();
            HttpClient client = _api.Initial();
            HttpResponseMessage rs = await client.GetAsync("api/RandomNumber");

            if (rs.IsSuccessStatusCode)
            {
                var results = rs.Content.ReadAsStringAsync().Result;
                random = JsonConvert.DeserializeObject<List<clsRandom>>(results);
            }

            ViewData["randomNumber"] = random;

            return View();
        }

    }
}
