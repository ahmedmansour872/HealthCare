using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacistsController : ControllerBase
    {
        private readonly HealthCareContexttest _context;

        public PharmacistsController(HealthCareContexttest context)
        {
            _context = context;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPharmacist(int id, Pharmacist Pharmacist)
        {
            if (id != Pharmacist.Id)
            {
                return BadRequest();
            }

            _context.Entry(Pharmacist).State = EntityState.Modified;

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

        //// GET: api/Pharmacists


        //// GET: api/Pharmacists/5

        ////[HttpPut("{id}")]
        ////public async Task<IActionResult> PutPharmacist(int id, Pharmacist pharmacist)
        ////{
        ////    if (id != pharmacist.Id)
        ////    {
        ////        return BadRequest();
        ////    }

        ////    _context.Entry(pharmacist).State = EntityState.Modified;

        ////    try
        ////    {
        ////        await _context.SaveChangesAsync();
        ////    }
        ////    catch (DbUpdateConcurrencyException)
        ////    {
        ////        if (!PharmacistExists(id))
        ////        {
        ////            return NotFound();
        ////        }
        ////        else
        ////        {
        ////            throw;
        ////        }
        ////    }

        ////    return NoContent();
        ////}
        //// post pharmacist
        //[HttpPost]
        //public async Task<ActionResult<Pharmacist>> PostPharmacist(Pharmacist pharmacist)
        //{
        //    _context.Pharmacists.Add(pharmacist);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPharmacist", new { id = pharmacist.Id }, pharmacist);
        //}

        //// DELETE
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Pharmacist>> DeletePharmacist(int id)
        //{
        //    var pharmacist = await _context.Pharmacists.FindAsync(id);
        //    if (pharmacist == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Pharmacists.Remove(pharmacist);
        //    await _context.SaveChangesAsync();

        //    return pharmacist;
        //}

        [HttpGet("GetPatientsForPharmacist")]
        public ActionResult<List<Patient>> GetPatientsForPharmacist()
        {
            //string today = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            List<string> PatientsName = new List<string>();
            //var datelist = _context.DiseasHistories.Where( c=>c.ClinicsId==ClinicID).ToList();
            List<Patient> listname = new List<Patient>();
            var datelist = _context.DiseasHistories.Select(d => new { d.Patient, d.Date }).ToList();

            foreach (var data in datelist)
            {
                if (data.Date.ToString("dd/MM/yyyy HH:mm:ss").Contains(DateTime.Now.ToString("dd/MM/yyyy ")))
                    listname.Add(data.Patient);
            }
            return listname;
        }
        [HttpPost("AddDurg")]
        public async Task<ActionResult<Drug>> AddDurg(Drug drug)
        {
            if (drug == null)
                return BadRequest();
            else
            {
                Drug newDrug = new Drug()
                {
                    AddDate = DateTime.Now,
                    Amount = drug.Amount,
                    Name = drug.Name,
                    PharmacistId = drug.PharmacistId
                };
                _context.Drugs.Add(newDrug);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
        [HttpGet("ShowAllDurgs")]
        public async Task<ActionResult<IEnumerable<Drug>>> GetDrugs()
        {
            return await _context.Drugs.ToListAsync();
        }
        [HttpGet("SearchForDrugName/{drugname}")]
        public  ActionResult<Drug> SearchForDrugName(string drugname)
        {
            var drug =  _context.Drugs.Where(d=>d.Name ==drugname);

            if (drug == null)
            {
                return NotFound();
            }

            return Ok(drug.Select(d => new { d.Name, d.Amount, Date = d.AddDate.ToString("dd/MM/yyyy HH:mm:ss tt") }));
        }

        [HttpPost("DonePatientPrescription/{patient_id}")]
        public async Task<ActionResult> DonePatientPrescription(int patient_id,int pharmacistID)
        {
            DateTime date = DateTime.Now;

            var clinc =await _context.DiseasHistories
                .Where(p => p.Date.Day == date.Day && p.Date.Month == date.Month && p.Date.Year == date.Year && p.PatientId == patient_id&&p.Waiting==true)
                .OrderBy(d=>d.Date).Select(c=>c.ClinicsId).LastAsync();
            var drug_patient = await _context.Prescriptions
                .Where(p => p.Clin_ID==clinc&&p.Date.Day == date.Day && p.Date.Month == date.Month && p.Date.Year == date.Year && p.PatientID == patient_id&&p.Done_Drug==false)
                .Select(p => new {p.Id, p.DrugName, p.DrugAmount }).ToListAsync();

            foreach (var ob in drug_patient)
            {
                var pree =await _context.Prescriptions.Where(i => i.Id == ob.Id).FirstOrDefaultAsync();
                pree.Done_Drug = true;
                pree.phar_id = pharmacistID;
                var drug =await _context.Drugs.Where(d => d.Name == ob.DrugName).FirstOrDefaultAsync();
                drug.Amount = drug.Amount - ob.DrugAmount;
		        if (drug.Amount > 0)
                {
                   // drug.Amount = drug.Amount - ob.DrugAmount;
                    //_context.Entry(pree).State = EntityState.Modified;
                    _context.Entry(drug).State = EntityState.Modified;
                }
                
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrugExists(drug.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Ok();
        }
        [HttpGet("GetPatientTOPharmacist/{PatientID}")]
        public ActionResult GetPatientTOPharmacist(int PatientID)
        {
            var date = DateTime.Now;
            var Doc = _context.Prescriptions.Where(d => d.PatientID == PatientID && d.Date.Day == date.Day && d.Date.Month == date.Month && d.Date.Year == date.Year & d.Done_Drug == false)
                .Select(d=>new { d.Doctor, d.Clin_ID}).ToList();
            List<PatientData> Doc_Cli = new List<PatientData>();
            foreach(var doc_ob in Doc)
            {
                var name = _context.Clinics.Where(d => d.Id == doc_ob.Clin_ID).FirstOrDefault();
                PatientData patient = new PatientData()
                {
                    Clinc_Name = name.Name,
                    Doctor_Name = doc_ob.Doctor.Fname+" "+ doc_ob.Doctor.Mname + " " + doc_ob.Doctor.Mname2
                };
                Doc_Cli.Add(patient);
            }



            return Ok(Doc_Cli);
        }

        [HttpGet("{f_name}/{m_name1}/{m_name2}/{l_name}")]
        public ActionResult<List<Patient>> SearchForPatientByName(string f_name, string m_name1, string m_name2, string l_name)
        {
            var date = DateTime.Now;
            
            if(f_name!=null&&m_name1!=null&m_name2!=null&&l_name!=null)
            {
                var patient = _context.Patients.Where(patient => patient.Fname == f_name && patient.Mname == m_name1 && patient.Mname2 == m_name2 && patient.Lname == l_name).FirstOrDefault();
                if (patient == null)
                {
                    return BadRequest("المريض غير مسجل بالنظام");
                }
                else
                {
                    var clin = _context.DiseasHistories.Where(p => p.PatientId == patient.Id && p.Date.Day == date.Day && p.Date.Month == date.Month && p.Date.Year == date.Year && p.Waiting == true).ToList();

                    if (clin.Count != 0)
                    {
                        var c = clin.OrderBy(data => data.Date).Select(c => c.ClinicsId).Last();
                        var d = _context.Prescriptions.Where(p => p.PatientID == patient.Id && p.Clin_ID == c && p.Date.Day == date.Day && p.Date.Month == date.Month && p.Date.Year == date.Year && p.Done_Drug != false).ToList();
                        if (d.Count != 0)
                        {
                            return BadRequest("تم صرف الدواء لذلك المريض");
                        }
                        else
                        {
                            var DoctorName = Doctor_Name(patient.Id);
                            var precription = pre(int.Parse(DoctorName[1]), patient.Id);
                            if (precription.Count == 0)
                                return NotFound();
                            else
                            {
                                PatientData patientData = new PatientData()
                                {
                                    Clinc_Name = ClincName(patient.Id),
                                    Doctor_Name = DoctorName[0],
                                    age = patient.age,
                                    PatientFull_Name = patient.Fname + " " + patient.Mname + " " + patient.Mname2 + " " + patient.Lname,
                                    Rank = patient.Rank,
                                    Religion = patient.Religion,
                                    Prescriptions = precription,
                                    patientID = patient.Id
                                };


                                return Ok(patientData);
                            }

                        }
                    }
                    return BadRequest();

                }
            }
            return NotFound();
            
        }
        [HttpGet("{militartyNumber}")]
        public ActionResult SearchForPatientByMilitarNumber(long militartyNumber)
        {
            var patient = _context.Patients.Where(p => p.MilitaryNumber == militartyNumber).FirstOrDefault();
            var date = DateTime.Now;
            if (patient == null)
            {
                return BadRequest("المريض غير مسجل بالنظام");
            }
            else
            {
                var clin = _context.DiseasHistories.Where(p => p.PatientId == patient.Id && p.Date.Day == date.Day && p.Date.Month == date.Month && p.Date.Year == date.Year && p.Waiting == true).ToList();

                if (clin.Count != 0)
                {
                    var c = clin.OrderBy(data => data.Date).Select(c => c.ClinicsId).Last();
                    var d = _context.Prescriptions.Where(p => p.PatientID == patient.Id && p.Clin_ID == c && p.Date.Day == date.Day && p.Date.Month == date.Month && p.Date.Year == date.Year && p.Done_Drug != false).ToList();
                    if (d.Count != 0)
                    {
                        return BadRequest("تم صرف الدواء لذلك المريض");
                    }
                    else
                    {
                        var DoctorName = Doctor_Name(patient.Id);
                        var precription = pre(int.Parse(DoctorName[1]), patient.Id);
                        if (precription.Count == 0)
                            return NotFound();
                        else
                        {
                            PatientData patientData = new PatientData()
                            {
                                Clinc_Name = ClincName(patient.Id),
                                Doctor_Name = DoctorName[0],
                                age = patient.age,
                                PatientFull_Name = patient.Fname + " " + patient.Mname + " " + patient.Mname2 + " " + patient.Lname,
                                Rank = patient.Rank,
                                Religion = patient.Religion,
                                Prescriptions = precription,
                                patientID = patient.Id
                            };


                            return Ok(patientData);
                        }

                    }
                }
                return NotFound();

            }
        }
        [HttpGet("SearchPatientByNationalID/{nationalid}")]
        public ActionResult SearchForPatientByNationalID(long nationalid)
        {
            var patient = _context.Patients.Where(patient => patient.NationalId == nationalid).FirstOrDefault();
            var date = DateTime.Now;
            if (patient == null)
            {
                return BadRequest("المريض غير مسجل بالنظام");
            }
            else
            {
                var clin = _context.DiseasHistories.Where(p => p.PatientId == patient.Id && p.Date.Day == date.Day && p.Date.Month == date.Month && p.Date.Year == date.Year && p.Waiting == true).ToList();

                if (clin.Count != 0)
                {
                    var c = clin.OrderBy(data => data.Date).Select(c => c.ClinicsId).Last();
                    var d = _context.Prescriptions.Where(p => p.PatientID == patient.Id && p.Clin_ID == c && p.Date.Day == date.Day && p.Date.Month == date.Month && p.Date.Year == date.Year && p.Done_Drug != false).ToList();
                    if (d.Count != 0)
                    {
                        return BadRequest("تم صرف الدواء لذلك المريض");
                    }
                    else
                    {
                        var DoctorName = Doctor_Name(patient.Id);
                        var precription = pre(int.Parse(DoctorName[1]), patient.Id);
                        if (precription.Count == 0)
                            return NotFound();
                        else
                        {
                            PatientData patientData = new PatientData()
                            {
                                Clinc_Name = ClincName(patient.Id),
                                Doctor_Name = DoctorName[0],
                                age = patient.age,
                                PatientFull_Name = patient.Fname + " " + patient.Mname + " " + patient.Mname2 + " " + patient.Lname,
                                Rank = patient.Rank,
                                Religion = patient.Religion,
                                Prescriptions = precription,
                                patientID = patient.Id
                            };


                            return Ok(patientData);
                        }

                    }
                }
                return NotFound();

            }
        }
        //[HttpGet("DoctorName")]
        private List<string> Doctor_Name(int patient)
        {
            List<string> data = new List<string>() {};
      
            DateTime date = DateTime.Now; 
            var DoctorName = _context.PatientDoctors.Where(d => d.Idpatient == patient&& d.Date.Day == date.Day && d.Date.Month == date.Month && d.Date.Year == date.Year).OrderByDescending(x=>x.Date).Select(d=>d.IddoctorNavigation).FirstOrDefault();
            if (DoctorName == null)
            {
                data.Add("hassan");
                data.Add("1");
                return data;
            }

            else
            {
                data.Add(DoctorName.Fname + " " + DoctorName.Mname + " " + DoctorName.Mname2 + " " + DoctorName.Lname);
                data.Add(DoctorName.Id.ToString());

                return data;

            }
            //  return DoctorName.Fname + " " + DoctorName.Mname + " " + DoctorName.Mname2 + " " + DoctorName.Lname;
        }
        //[HttpGet("ClincName")]
        private string ClincName(int patient)
        {
            DateTime date = DateTime.Now;
            var Clin_name = _context.DiseasHistories.Where(p => p.PatientId == patient && p.Date.Day == date.Day && p.Date.Month == date.Month && p.Date.Year == date.Year && p.Waiting != false).OrderByDescending(x => x.Date).Select(c => c.Clinics).LastOrDefault();
            
            if (Clin_name == null)
                return "no";
            return Clin_name.Name;
        }
       // [HttpGet("pre/{doc}/{patient}")]
        private List<Prescription> pre(int doc,int patient)
        {
            DateTime date = DateTime.Now;
           
            var precription = _context.Prescriptions.Where(d => d.DoctorId == doc && d.PatientID == patient && d.Date.Day == date.Day && d.Date.Month == date.Month && d.Date.Year == date.Year && d.Done_Drug == false)
                .ToList();
            if (precription == null) 
                return null;
            else
                return precription;
        }

        [HttpGet("show/{id}")]
        public ActionResult show(int id)
        {
            DateTime date = DateTime.Now;
            var DoctorName = _context.PatientDoctors.Where(d => d.Idpatient == id && d.Date.Day == date.Day && d.Date.Month == date.Month && d.Date.Year == date.Year).OrderByDescending(x => x.Date).Select(d => d.IddoctorNavigation).FirstOrDefault();
            return Ok(DoctorName);
        }
        private bool DrugExists(int id)
        {
            return _context.Drugs.Any(e => e.Id == id);
        }
        private bool PharmacistExists(int id)
        {
            return _context.Pharmacists.Any(e => e.Id == id);
        }
    }
}

public class PatientData
{
    public string Doctor_Name { get; set; }
    public string Clinc_Name { get; set; }
    public string PatientFull_Name {get;set;}
    public int age { get; set; }
    public string Rank { get; set; }
    public  string Religion { get; set; }
    public int patientID { get; set; }
    public List<Prescription> Prescriptions { get; set; }
}

