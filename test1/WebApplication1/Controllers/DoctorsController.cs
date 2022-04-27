using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly HealthCareContexttest _context;
        public DoctorsController(HealthCareContexttest context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
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

        // POST: api/Doctors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctor", new { id = doctor.Id }, doctor);
        }

        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Doctor>> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return doctor;
        }
        // Doctor Controller
        [HttpGet("GetPatientsForDoctor/{ClinicID}")]
        public ActionResult<List<Patient>> GetPatientsForDoctor(int ClinicID)
        {
            List<string> PatientsName = new List<string>();
            //var datelist = _context.DiseasHistories.Where( c=>c.ClinicsId==ClinicID).ToList();
            List<Patient> listname = new List<Patient>();
            var datelist = _context.DiseasHistories.Where(c => c.ClinicsId == ClinicID && c.Waiting == false)
                .Select(d => new { d.Patient, d.Date }).ToList();

            foreach (var data in datelist)
            {
                if (data.Date.ToString("dd/MM/yyyy HH:mm:ss").Contains(DateTime.Now.ToString("dd/MM/yyyy ")))
                    listname.Add(data.Patient);
            }
            return listname;
        }

        [HttpPost("AddDescribe_Recommend/{Patient_ID}/{ClinID}/{Doc_ID}/{Decribe}/{Recommend}/{reserved}")]
        public async Task<ActionResult> AddDescribe_Recommend(int Patient_ID,int ClinID,int Doc_ID, string Decribe , string Recommend,bool reserved, bool ExtrenalExamination, Prescription[] prescription)
        {
            DateTime date = DateTime.Now;
            var patient_data = _context.DiseasHistories
            .Where(c => c.PatientId == Patient_ID &&c.ClinicsId==ClinID&& c.Date.Day == date.Day && c.Date.Month == date.Month && c.Date.Year == date.Year)
            .FirstOrDefault();
	    
	  
            patient_data.Describe = Decribe;
            patient_data.Waiting = true;
            patient_data.Mrecommend = Recommend;
            patient_data.ExtrenalExamination = ExtrenalExamination;
            _context.Entry(patient_data).State = EntityState.Modified;
            var x=  updatepatient(Patient_ID, reserved);
            var c= addPrescription(prescription, ClinID);
            var a= AddPatientDoctor(Patient_ID, Doc_ID);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("NO...");
            }
            return Ok("done...");
         }
        private int AddPatientDoctor(int patID,int DocID)
        {
            DateTime date = DateTime.Now;
            PatientDoctor patient_doctor = new PatientDoctor()
            {
                Idpatient = patID,
                Iddoctor = DocID,
                Date = date
            };
            _context.PatientDoctors.Add(patient_doctor);
            _context.SaveChanges();
            return 1;
        }
        private int updatepatient(int id , bool reserved )
        {
            var patient = _context.Patients.Where(p => p.Id == id).FirstOrDefault();
            patient.Reserved = reserved;
            _context.Entry(patient).State = EntityState.Modified;
             _context.SaveChanges();
            return 1;
        }
        //[HttpGet("AddBeds/{Reserver}/{PatientID}")]
        //public async Task<string> AddBeds(bool Reserver,int PatientID)
        //{
        //    var bed = await _context.Inbeds.Where(b => b.Basy == false).Select(number=>number.BedNumber).ToListAsync();
        //    return "done";
        //}
        //[HttpPost("addPrescription")]
        private ActionResult addPrescription(Prescription[] prescription,int ClinID)
        {

            var date = DateTime.Now;
            foreach (var pre in prescription)
            {
                if (pre != null) 
                {
                    Prescription new_prescription = new Prescription()
                    {
                        Date = date,
                        DoctorId = pre.DoctorId,
                        DrugAmount = pre.DrugAmount,
                        DrugAmountPday = pre.DrugAmountPday,
                        DrugName = pre.DrugName,
                        Duration = pre.Duration,
                        PatientID = pre.PatientID,
                        Done_Drug = false,
                        Clin_ID= ClinID
                    };

                    _context.Prescriptions.Add(new_prescription);
                     _context.SaveChanges();
                }
            }

            return Ok("done");
        }

        [HttpPost("ReservedPatient")]
        public async Task<ActionResult> ReservedPatient(int patient_id, bool reserved,int DoctoID)
        {
            if (reserved == true)
            {
                var number_Bed=await _context.BedsNumbers.Where(b => b.Busy == false).FirstOrDefaultAsync();
                if (number_Bed != null)
                {
                    number_Bed.Busy = true;
                    ReservedPatient reserved1 = new ReservedPatient()
                    {
                        PatientId = patient_id,
                        Date = DateTime.Now,
                        DoctorId = DoctoID,
                        BedNumber = number_Bed.BedId,
                        Reserved = true
                    };

                    _context.ReservedPatients.Add(reserved1);
                    _context.Entry(number_Bed).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok("Done");
                }
                else
                    return BadRequest();
            }
            return BadRequest("nononono");
        }
        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }
    }
}
    