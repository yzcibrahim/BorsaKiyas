using BorsaMvc.Models;
using CommonLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BorsaMvc.Controllers
{
    public class BankaController : Controller
    {
        // GET: BankaController
        public async Task<ActionResult> Index()
        {
            List<BankaViewModel> model = new List<BankaViewModel>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55749");
            var res = await client.GetAsync("http://localhost:55749/api/Banka");
            // res.Wait();

            var resp = await res.Content.ReadAsStringAsync();
            var liste = JsonConvert.DeserializeObject<List<BankaViewModel>>(resp);

            //model.Add(new BankaViewModel() { Id = 1, Ad = "asd", Url = "www.wwdad" });
            //model.Add(new BankaViewModel() { Id = 2, Ad = "AAasd", Url = "www.wwdad" });

            return View(liste);
        }

        // GET: BankaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BankaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BankaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BankaViewModel model)
        {

            if(model.Ad.StartsWith("test"))
            {
                ModelState.AddModelError("", "enough test");
            }

            if (!ModelState.IsValid)
                return View(model);

            HttpClient client = new HttpClient();
            //  client.BaseAddress = new Uri("http://localhost:55749");

            var response =await client.PostAsJsonAsync("http://localhost:55749/api/Banka", model);

            string respStr = await response.Content.ReadAsStringAsync();
            var myResp = JsonConvert.DeserializeObject<BorsaResponse>(respStr);

            if (myResp.Res.StatusCode == (int)HttpStatusCode.OK)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var item in myResp.ErrorMessages)
                {
                    ModelState.AddModelError("", item);
                }
                return View(model);
            }
        }

        // GET: BankaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BankaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BankaController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {

            HttpClient client = new HttpClient();
            //  client.BaseAddress = new Uri("http://localhost:55749");

            string url = $"http://localhost:55749/api/Banka/{id}";

            var response = await client.DeleteAsync(url);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
