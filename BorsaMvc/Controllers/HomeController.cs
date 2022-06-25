using BorsaMvc.Models;
using CommonLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BorsaMvc.Controllers
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
            return View();
        }

        public IActionResult ChartTest()
        {
            return View();
        }

        public async Task<IActionResult> MyLineChartAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55749");
            var res = await client.GetAsync("http://localhost:55749/api/ChartSample");
            // res.Wait();

            var resp = await res.Content.ReadAsStringAsync();
            var liste = JsonConvert.DeserializeObject<List<ChartTestLineModel>>(resp);
            client.Dispose();

            var labels = liste.Select(c => "'"+c.Name+"'");
            var values = liste.Select(c => c.Value);

            ViewBag.labels = string.Join(',',labels);
            ViewBag.values = string.Join(',', values); 
            return View();
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
