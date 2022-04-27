using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTO;

namespace WebApplication1.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly HealthCareContexttest _context;
        public AdministrationController(HealthCareContexttest context)
        {
            _context = context;
        }
        /*pharmacist*/
        //list all doctors
        [HttpGet("GetAllDoctors")]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            return await _context.Doctors.ToListAsync();
        }
        //get doctor
        [HttpGet("GetDoctor/{id}")]
        public ActionResult GetDoctor(int id)
        {
            var doctor = _context.Doctors.Where(p => p.Id == id).FirstOrDefault();
            if (doctor == null) 
            {
                return NotFound();
            }
            else return Ok(doctor);
        }
        //add
        [HttpPost("AddDoctor")]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctor", new { id = doctor.Id }, doctor);
        }
        //edit
        [HttpPut("EditDoctor/{id}")]
        public async Task<IActionResult> PutDoctor(int id, Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest();
            }

            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }
        /*pharmacist*/
        //list all pharmacists
        [HttpGet("GetAllPharmacists")]
        public async Task<ActionResult<IEnumerable<Pharmacist>>> GetPharmacists()
        {
            return await _context.Pharmacists.ToListAsync();
        }
        //get pharmacist
        [HttpGet("GetPharmacist/{id}")]
        public ActionResult GetPharmacist(int id)
        {
            var pharmacist = _context.Pharmacists.Where(p => p.Id == id).FirstOrDefault();
            if (pharmacist == null)
            {
                return NotFound();
            }
            else return Ok(pharmacist);
        }

        //add
        [HttpPost("AddPharmacist")]
        public async Task<ActionResult<Pharmacist>> PostPharmacist(Pharmacist pharmacist)
        {
            _context.Pharmacists.Add(pharmacist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPharmacist", new { id = pharmacist.Id }, pharmacist);
        }
        //edit
        [HttpPut("EditPharmacist/{id}")]
        public async Task<IActionResult> PutPharmacist(int id, Pharmacist pharmacist)
        {
            if (id != pharmacist.Id)
            {
                return BadRequest();
            }

            _context.Entry(pharmacist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PharmacistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        //delete
        [HttpDelete("DeletePharmacist/{id}")]
        public async Task<ActionResult<Pharmacist>> DeletePharmacist(int id)
        {
            var pharmacist = await _context.Pharmacists.FindAsync(id);
            if (pharmacist == null)
            {
                return NotFound();
            }

            _context.Pharmacists.Remove(pharmacist);
            await _context.SaveChangesAsync();

            return pharmacist;
        }
        private bool PharmacistExists(int id)
        {
            return _context.Pharmacists.Any(e => e.Id == id);
        }
        /*Receptionest*/
        //list all pharmacists
        [HttpGet("GetAllReceptionests")]
        public async Task<ActionResult<IEnumerable<Receptionest>>> GetReceptionest()
        {
            return await _context.Receptionests.ToListAsync();
        }
        //get pharmacist
        [HttpGet("GetReceptionest/{id}")]
        public ActionResult GetReceptionest(int id)
        {
            var receptionest = _context.Receptionests.Where(p => p.Id == id).FirstOrDefault();
            if (receptionest == null)
            {
                return NotFound();
            }
            else return Ok(receptionest);
        }

        //add
        [HttpPost("AddReceptionest")]
        public async Task<ActionResult<Receptionest>> PostReceptionest(Receptionest receptionest)
        {
            _context.Receptionests.Add(receptionest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReceptionest", new { id = receptionest.Id }, receptionest);
        }
        //edit
        [HttpPut("EditReceptionest/{id}")]
        public async Task<IActionResult> PutReceptionest(int id, Receptionest receptionest)
        {
            if (id != receptionest.Id)
            {
                return BadRequest();
            }

            _context.Entry(receptionest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceptionestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        //delete
        [HttpDelete("DeleteReceptionest/{id}")]
        public async Task<ActionResult<Receptionest>> DeleteReceptionest(int id)
        {
            var receptionest = await _context.Receptionests.FindAsync(id);
            if (receptionest == null)
            {
                return NotFound();
            }

            _context.Receptionests.Remove(receptionest);
            await _context.SaveChangesAsync();
            return receptionest;
        }
        private bool ReceptionestExists(int id)
        {
            return _context.Receptionests.Any(e => e.Id == id);
        }

        [HttpGet("GetPatientsByDate/{date}")]
        public ActionResult<List<string>> GetPatientsByDate(DateTime date)
        {
            var clinCount = _context.Clinics.Count();
            List<List<string>> list = new List<List<string>>();

          //  var patientHistory = _context.DiseasHistories.ToList();
            for (int i = 1; i <= clinCount; i++)
            {
                List<string> data =_context.DiseasHistories.Where(d => d.ClinicsId == i&&d.Date.Day==date.Day&&d.Date.Month==date.Month &&d.Date.Year==date.Year)
                    .Select(p => p.Patient.Fname).ToList();

                list.Add(data);
            }
            
            return Ok(list);
        }


    }
}
