using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DHIS.Data;
using DHIS.Models;
using Microsoft.AspNetCore.Authorization;

namespace DHIS.Controllers
{
    [Authorize]
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Patients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patients.ToListAsync());
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            PatientViewModel patientdetails = new PatientViewModel();
            if (id == null)
            {
                return NotFound();
            }

             patientdetails.GetPatientDetails = await _context.Patients
                .FirstOrDefaultAsync(m => m.PatientID == id);

            patientdetails.GetPrescriptions = _context.Prescriptions.Where(a => a.PrescriptionPatientID == id).ToList();
            if (patientdetails.GetPatientDetails == null)
            {
                return NotFound();
            }

            return View(patientdetails);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientID,FullName,Gender,Nationality,IDNumber,DOB,CellphoneNumber,PostalAddress,ResidentialAddress,NextOfKin,NextOfKinCell,ImagePath,Created_by,Modified_by,Created_on,Modified_on")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        public async Task<IActionResult> Prescribe(int? id)
        {
            ViewData["PrescriptionPatientID"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Prescribe([Bind("PrescriptionID,PrescriptionPatientID,PrescriptionNotes,Diagonosis,DiagonosisBy,PrescriptionCollected,Created_by,Modified_by,Created_on,Modified_on")] Prescription prescription)
        {
            var patient = _context.Patients.Where(a => a.PatientID == prescription.PrescriptionPatientID).FirstOrDefault();
            prescription.PrescriptionNotes = prescription.PrescriptionNotes.Replace(Environment.NewLine, "<br />");
            prescription.Diagonosis = prescription.Diagonosis.Replace(Environment.NewLine, "<br />");
            prescription.Idnumber = patient.IDNumber;

            if (ModelState.IsValid)
            {
                _context.Add(prescription);
                await _context.SaveChangesAsync();
                this.TempData["Successfull"] = "Prescriptions captured Successfully";
                return RedirectToAction(nameof(PatientsController.Index));
            }
            ViewData["PrescriptionPatientID"] = prescription.PrescriptionPatientID;
            return View(prescription);
        }


        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientID,FullName,Gender,Nationality,IDNumber,DOB,CellphoneNumber,PostalAddress,ResidentialAddress,NextOfKin,NextOfKinCell,ImagePath,Created_by,Modified_by,Created_on,Modified_on")] Patient patient)
        {
            if (id != patient.PatientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.PatientID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.PatientID == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.PatientID == id);
        }
    }
}
