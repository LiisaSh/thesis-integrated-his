using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DHIS.Models;
using DHIS.Data;
using Microsoft.AspNetCore.Authorization;

namespace DHIS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var prescription = _context.Prescriptions.Count();
            var Patients = _context.Patients.Count();
            var Doctors = _context.Doctors.Count();
            var collected = _context.Prescriptions.Where(a => a.PrescriptionCollected).Count();
            var notcollected = _context.Prescriptions.Where(a => a.PrescriptionCollected == false).Count();

            ViewData["Patients"] = Patients;
            ViewData["prescription"] = prescription;
            ViewData["collected"] = collected;
            ViewData["notcollected"] = notcollected;
            ViewData["Doctors"] = Doctors;
            return View();
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
