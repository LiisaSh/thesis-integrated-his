using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhamarcySystem.Models;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace PhamarcySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ehealthContext _context;
        public HomeController(Func<ehealthContext> context)
        {
            _context = new ehealthContext();
        }
        public IActionResult Index()
        {

            var prescription = _context.Prescription.Count();
            var collected = _context.Prescription.Where(a=>a.PrescriptionCollected).Count();
            var notcollected = _context.Prescription.Where(a => a.PrescriptionCollected==false).Count();

            ViewData["prescription"] = prescription;
            ViewData["collected"] = collected;
            ViewData["notcollected"] = notcollected;


            return View();
        }


        [HttpGet]
        public IActionResult GePrescription()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GePrescription(string id)
        {
            PreScribeClass prescribe = new PreScribeClass();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44324/api/Prescriptions/" + id))
                {

                    var apiResponse = response.Content.ReadAsStringAsync().Result;
                    //string coverted = (PreScribeClass)Convert.ChangeType(apiResponse.ToString(),typeof(string));
                    var dar = JsonConvert.DeserializeObject(apiResponse);
                    //JObject object123 = JObject.Parse(apiResponse);
                    //JArray object123 = JArray.Parse(apiResponse);
                    JArray jsonArray = JArray.Parse(apiResponse);
                    dynamic object123 = JObject.Parse(jsonArray[0].ToString());

                    prescribe.PrescriptionCollected = Convert.ToBoolean(object123["prescriptionCollected"]);
                    prescribe.PrescriptionId = Convert.ToInt32(object123["prescriptionId"]);
                    prescribe.PrescriptionPatientId = Convert.ToInt32(object123["rescriptionPatientId"]);
                    prescribe.PrescriptionNotes = object123["prescriptionNotes"].ToString();
                    prescribe.Diagonosis = object123["diagonosis"].ToString();
                    prescribe.DiagonosisBy = object123["diagonosis"].ToString();
                    prescribe.CreatedBy = object123["createdBy"].ToString();
                    prescribe.ModifiedBy = object123["modifiedBy"].ToString();
                    prescribe.Idnumber = object123["idnumber"].ToString();
                }
            }
            return View(prescribe);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, string Diagonosis)
        {
            var testimony = new Prescription() { PrescriptionId = id, PrescriptionCollected = true, Diagonosis= Diagonosis };

            _context.Prescription.Attach(testimony);
            _context.Entry(testimony).Property(x => x.PrescriptionCollected).IsModified = true;
            _context.Entry(testimony).Property(x => x.Diagonosis).IsModified = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
