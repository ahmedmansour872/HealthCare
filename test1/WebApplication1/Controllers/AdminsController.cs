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
    public class AdminsController : ControllerBase
    {
        private readonly HealthCareContexttest _context;

        public AdminsController(HealthCareContexttest context)
        {
            _context = context;
        }
        //Add Receptionest
        [HttpPut("PutPharmacist/{id}")]
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
        [HttpPut("PutReceptionest/{id}")]
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
        [HttpPost("AddReceptionest")]
        public async Task<ActionResult> AddReceptionest(Receptionest receptionest)
        {

            if (receptionest != null)
            {
                var Rec = _context.Receptionests.Where(R=>R.MilitaryNumber== receptionest.MilitaryNumber||R.NationalId== receptionest.NationalId||R.Username== receptionest.Username).FirstOrDefault();
                if (Rec!=null)
                    return BadRequest();

                else 
                {
                    Receptionest newReceptionest = new Receptionest()
                    {
                        Fname = receptionest.Fname,
                        Lname = receptionest.Lname,
                        Mname = receptionest.Mname,
                        Mname2 = receptionest.Mname2,
                        MilitaryNumber = receptionest.MilitaryNumber,
                        NationalId = receptionest.NationalId,

                        Username = receptionest.Username,
                        Password = receptionest.Password
                    };
                    _context.Receptionests.Add(newReceptionest);
                    await _context.SaveChangesAsync();

                    return Ok();
                }
            }
            else
                return BadRequest();
        }
        // Show Receptionest 
        [HttpGet("ShowReceptionest")]
        public async Task<ActionResult<IEnumerable<Receptionest>>> ShowReceptionest()
        {
            return await _context.Receptionests.ToListAsync();
        }
        [HttpGet("GetReceptionest/{id}")]
        public ActionResult GetReceptionest(int id)
        {
            var receptionest = _context.Receptionests.Where(res => res.Id == id).FirstOrDefault();
            return Ok(receptionest);
        }

        //Search For Receptionest
        [HttpGet("SearchForReceptionestByName/{f_name}/{m_name1}/{m_name2}/{l_name}")]
        public ActionResult<List<Patient>> SearchForReceptionestByName(string f_name, string m_name1, string m_name2, string l_name)
        {

            if (m_name1 == null && m_name2 == null && l_name == null)
            {
                var ReceptionestsList = _context.Receptionests.Where(Receptionest => Receptionest.Fname == f_name).ToList();

                return Ok(ReceptionestsList);
            }
            if (m_name2 == null && l_name == null)
            {
                var Receptionests = _context.Receptionests.Where(Receptionest => Receptionest.Fname == f_name && Receptionest.Mname == m_name1).ToList();
                return Ok(Receptionests);
            }
            if (l_name == null)
            {
                var Receptionest_list = _context.Receptionests.Where(Receptionest => Receptionest.Fname == f_name && Receptionest.Mname == m_name1 && Receptionest.Mname2 == m_name2).ToList();
                return Ok(Receptionest_list);
            }
            var Receptionest = _context.Receptionests.Where(Receptionest => Receptionest.Fname == f_name && Receptionest.Mname == m_name1 && Receptionest.Mname2 == m_name2 && Receptionest.Lname == l_name).ToList();
            return Ok(Receptionest);
        }
        [HttpGet("SearchForReceptionestByMilitarNumber/{militartyNumber}")]
        public ActionResult SearchForReceptionestByMilitarNumber(long militartyNumber)
        {
            var Receptionest = _context.Receptionests.Where(p => p.MilitaryNumber == militartyNumber).FirstOrDefault();
            //var date = DateTime.Now;
            if (Receptionest == null)
            {
                return NotFound();
            }
            else
                return Ok(Receptionest);

        }
        [HttpGet("SearchForReceptionestByNationalID/{nationalid}")]
        public ActionResult SearchForReceptionestByNationalID(long nationalid)
        {
            var Receptionest = _context.Receptionests.Where(Receptionest => Receptionest.NationalId == nationalid).FirstOrDefault();

            if (Receptionest == null)
            {
                return NotFound();
            }
            else
                return Ok(Receptionest);
        }
        //Delete Receptionest
        //[HttpDelete("DeleteReceptionest/{Military_Number}")]
        //public ActionResult<Pharmacist> DeleteReceptionest(int Military_Number)
        //{
        //    var receptionest = _context.Receptionests.Where(p => p.MilitaryNumber == Military_Number).FirstOrDefault();
        //    if (receptionest == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Receptionests.Remove(receptionest);
        //    _context.SaveChanges();

        //    return Ok();
        //}
        //Add Pharmacist

        [HttpDelete("DeleteReceptionest/{id}")]
        public async Task<ActionResult> DeleteReceptionest(int id)
        { 
            var Receptionest =await _context.Receptionests.Where(receptionest => receptionest.Id == id).FirstOrDefaultAsync();
            if (Receptionest == null)
                return NotFound();
            else
            {
                Receptionest.Username = "##";
                Receptionest.Password = "##";
                _context.Entry(Receptionest).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }
            return Ok();
        }
        [HttpPost("AddPharmacist")]
        public async Task<ActionResult> AddPharmacist(Pharmacist pharmacist)
        {

            if (pharmacist != null)
            {
                var phar = _context.Pharmacists.Where(P => P.MilitaryNumber == pharmacist.MilitaryNumber || P.NationalId == pharmacist.NationalId || P.Username == pharmacist.Username).FirstOrDefault();
                if (phar != null)
                    return BadRequest();
                else 
                {
                    Pharmacist newPharmacist = new Pharmacist()
                    {
                        Fname = pharmacist.Fname,
                        Lname = pharmacist.Lname,
                        Mname = pharmacist.Mname,
                        Mname2 = pharmacist.Mname2,
                        MilitaryNumber = pharmacist.MilitaryNumber,
                        NationalId = pharmacist.NationalId,
                        Rank = pharmacist.Rank,
                        Username = pharmacist.Username,
                        Password = pharmacist.Password
                    };
                    _context.Pharmacists.Add(newPharmacist);
                    await _context.SaveChangesAsync();

                    return Ok();
                }
            }
            else
                return BadRequest();
        }
        //ShowPharmacists
        [HttpGet("ShowPharmacists")]
        public async Task<ActionResult<IEnumerable<Pharmacist>>> ShowPharmacists()
        {
            return await _context.Pharmacists.ToListAsync();
        }
        //SearchForPharmacist
        [HttpGet("SearchForPharmacistByName/{f_name}/{m_name1}/{m_name2}/{l_name}")]
        public ActionResult<List<Patient>> SearchForPharmacistByName(string f_name, string m_name1, string m_name2, string l_name)
        {

            if (m_name1 == null && m_name2 == null && l_name == null)
            {
                var PharmacistsList = _context.Pharmacists.Where(Pharmacist => Pharmacist.Fname == f_name).ToList();

                return Ok(PharmacistsList);
            }
            if (m_name2 == null && l_name == null)
            {
                var Pharmacists = _context.Pharmacists.Where(Pharmacist => Pharmacist.Fname == f_name && Pharmacist.Mname == m_name1).ToList();
                return Ok(Pharmacists);
            }
            if (l_name == null)
            {
                var Pharmacist_list = _context.Pharmacists.Where(Pharmacist => Pharmacist.Fname == f_name && Pharmacist.Mname == m_name1 && Pharmacist.Mname2 == m_name2).ToList();
                return Ok(Pharmacist_list);
            }
            var Pharmacist = _context.Pharmacists.Where(Pharmacist => Pharmacist.Fname == f_name && Pharmacist.Mname == m_name1 && Pharmacist.Mname2 == m_name2 && Pharmacist.Lname == l_name).ToList();
            return Ok(Pharmacist);
        }
        [HttpGet("SearchForPharmacistByMilitarNumber/{militartyNumber}")]
        public ActionResult SearchForPharmacistByMilitarNumber(long militartyNumber)
        {
            var Pharmacist = _context.Pharmacists.Where(p => p.MilitaryNumber == militartyNumber).FirstOrDefault();
            //var date = DateTime.Now;
            if (Pharmacist == null)
            {
                return NotFound();
            }
            else
                return Ok(Pharmacist);

        }
        [HttpGet("SearchForPharmacistByNationalID/{nationalid}")]
        public ActionResult SearchForPharmacistByNationalID(long nationalid)
        {
            var Pharmacist = _context.Pharmacists.Where(Pharmacist => Pharmacist.NationalId == nationalid).FirstOrDefault();

            if (Pharmacist == null)
            {
                return NotFound();
            }
            else
                return Ok(Pharmacist);
        }
        //DeletePharmacist
        //[HttpDelete("DeletePharmacist/{id}")]
        //public async Task<ActionResult> DeletePharmacist(int id)
        //{
        //    //var pharmacist =  _context.Pharmacists.Where(p=>p.MilitaryNumber == Military_Number).FirstOrDefault();
        //    var pharmacist = _context.Pharmacists.Find(id);
        //    if (pharmacist == null)
        //    {
        //        return NotFound();
        //    }

        //     _context.Pharmacists.Remove(pharmacist);
        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}


        //Add Doctor
        [HttpPost("AddDoctor")]
        public async Task<ActionResult> AddDoctor(Doctor doctor)
        {

            if (doctor != null)
            {
                var doc = _context.Doctors.Where(d => d.MilitaryNumber == doctor.MilitaryNumber || d.NationalId == doctor.NationalId || d.Username==doctor.Username).FirstOrDefault();
                if (doc == null)
                {
                    Doctor newDoctor = new Doctor()
                    {
                        Fname = doctor.Fname,
                        Lname = doctor.Lname,
                        Mname = doctor.Mname,
                        Mname2 = doctor.Mname2,
                        MilitaryNumber = doctor.MilitaryNumber,
                        NationalId = doctor.NationalId,
                        Rank = doctor.Rank,
                        Specialization = doctor.Specialization,
                        Username = doctor.Username,
                        Password = doctor.Password
                    };
                    _context.Doctors.Add(newDoctor);
                    await _context.SaveChangesAsync();

                    return Ok(newDoctor);
                }

                else
                {
                    return BadRequest("no");
                }

            }
            else
                return BadRequest("yes");
        }
        //Show All Doctors
        [HttpGet("ShowDoctors")]
        public async Task<ActionResult<IEnumerable<Doctor>>> ShowDoctors()
        {
            return await _context.Doctors.ToListAsync();
        }

        // search for doctor by name
        [HttpGet("SearchForDoctorByName/{f_name}/{m_name1}/{m_name2}/{l_name}")]
        public ActionResult<List<Patient>> SearchForDoctorByName(string f_name, string m_name1, string m_name2, string l_name)
        {

            if (m_name1 == null && m_name2 == null && l_name == null)
            {
                var doctorsList = _context.Doctors.Where(doctor => doctor.Fname == f_name).ToList();

                return Ok(doctorsList);
            }
            if (m_name2 == null && l_name == null)
            {
                var doctors = _context.Doctors.Where(doctor => doctor.Fname == f_name && doctor.Mname == m_name1).ToList();
                return Ok(doctors);
            }
            if (l_name == null)
            {
                var doctor_list = _context.Doctors.Where(doctor => doctor.Fname == f_name && doctor.Mname == m_name1 && doctor.Mname2 == m_name2).ToList();
                return Ok(doctor_list);
            }
            var doctor = _context.Doctors.Where(doctor => doctor.Fname == f_name && doctor.Mname == m_name1 && doctor.Mname2 == m_name2 && doctor.Lname == l_name).ToList();
            return Ok(doctor);
        }
        [HttpGet("SearchForDoctorByMilitarNumber/{militartyNumber}")]
        public ActionResult SearchForDoctorByMilitarNumber(long militartyNumber)
        {
            var doctor = _context.Doctors.Where(p => p.MilitaryNumber == militartyNumber).FirstOrDefault();
            var date = DateTime.Now;
            if (doctor == null)
            {
                return NotFound();
            }
            else
                return Ok(doctor);

        }
        [HttpGet("SearchForDoctorByNationalID/{nationalid}")]
        public ActionResult SearchForDoctorByNationalID(long nationalid)
        {
            var doctor = _context.Doctors.Where(doctor => doctor.NationalId == nationalid).FirstOrDefault();

            if (doctor == null)
            {
                return NotFound();
            }
            else
                return Ok(doctor);
        }
        //Delete Doctor using Military Number
        //[HttpDelete("DeleteDoctor/{Military_Number}")]
        //public ActionResult<Doctor> DeleteDoctor(int Military_Number)
        //{
        //    var doctor = _context.Doctors.Where(d=>d.MilitaryNumber==Military_Number).FirstOrDefault();
        //    if (doctor == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Doctors.Remove(doctor);
        //     _context.SaveChanges();

        //    return Ok();
        //}


        //
        [HttpGet("GetPatientsForadminByDay")]
        public async Task<ActionResult> GetPatientsForadmin_ByDay()
        {
            List<patientsData> patientsDatas = new List<patientsData>();
            var date = DateTime.Now;
            var datalist = _context.DiseasHistories.Where(c => c.Date.Day == date.Day && c.Date.Month == date.Month && c.Date.Year == date.Year&&c.Waiting==true)
                .Select(p => new { p.Clinics.Name,p.Date, patientID = p.Patient.Id, p.Patient.age, p.Patient.Fname, p.Patient.Mname, p.Patient.Mname2, p.Patient.Lname, p.Describe, p.Mrecommend, clinic = p.Clinics.Id }).ToList();
            foreach (var ob in datalist)
            {
                patientsData patientsData = new patientsData()
                {
                    age = ob.age,
                    ClincName = ob.Name,
                    Date = ob.Date.ToString(),
                    Describe = ob.Describe,
                    Mrecommend = ob.Mrecommend,
                    PatientName = ob.Fname + " " + ob.Mname + " " + ob.Mname2 + " " + ob.Lname,
                    patientID = ob.patientID,
                    Doctor_Name = await DoctorName(ob.patientID, ob.clinic, ob.Date)

                };
                patientsDatas.Add(patientsData);
            }

            return Ok(patientsDatas);
        }

        [HttpGet("GetPatientsForadminByCount")]
        public async Task<ActionResult> GetPatientsForadmin_ByDayCount()
        {
            List<patientCount> patientsCount = new List<patientCount>();
           // DateTime date = DateTime.Parse("2022-02-15 09:59:32.640");
           // patientCount patientCount = new patientCount();

            //var patientList = await _context.DiseasHistories.Where(c => c.Date.Day == date.Day && c.Date.Month == date.Month && c.Date.Year == date.Year).ToListAsync();
            for(int i=1;i<=10;i++)
            {
                var patientsCount1 = await ClinCount(i);
                patientsCount.Add(patientsCount1);
            }
            
            return Ok(patientsCount);
        }
        [HttpGet("GetPatientsForadminByDayCounts")]
        public async Task<ActionResult> GetPatientsForadmin_ByDayCounts()
        {
            var date=DateTime.Now;
            var counts = await _context.DiseasHistories.Where(count => count.Date.Day == date.Day && count.Date.Month == date.Month && count.Date.Year == date.Year&&count.Waiting==true)
                .CountAsync();
            return Ok(counts);

        }
            //[HttpGet("ClinCount")]
         private async Task<patientCount> ClinCount(int clinsID) 
        {
            DateTime date = DateTime.Now;
            patientCount patientCount = new patientCount();
            int res =await _context.DiseasHistories.Where(c => c.Date.Day == date.Day && c.Date.Month == date.Month && c.Date.Year == date.Year && c.ClinicsId == clinsID&&c.Waiting==true).CountAsync();
            patientCount.ClinicName =await _context.Clinics.Where(c => c.Id == clinsID).Select(n => n.Name).FirstOrDefaultAsync();
            patientCount.count = res;
            return patientCount;
        }
        //show all patient in clinics
        [HttpGet("GetAllPatientsForAdmin")]
        public ActionResult GetAllPatientsForAdmin()
        {
            List<patientsData> patientsDatas = new List<patientsData>();
            var date = DateTime.Now;
            var datelist = _context.DiseasHistories
                .Select(p => new { p.Clinics.Name,p.Date,patientID= p.Patient.Id,p.Patient.age,p.Patient.Fname,p.Patient.Mname,p.Patient.Mname2,p.Patient.Lname,p.Describe,p.Mrecommend,clinic=p.Clinics.Id });
            foreach (var ob in datelist)
            {
                patientsData patientsData = new patientsData()
                {
                    age = ob.age,
                    ClincName = ob.Name,
                    Date = ob.Date.ToString(),
                    Describe = ob.Describe,
                    Mrecommend=ob.Mrecommend,
                    PatientName=ob.Fname+" "+ob.Mname+" "+ob.Mname2+ " "+ob.Lname ,
                    patientID = ob.patientID,
                    Doctor_Name ="no"//await DoctorName(ob.patientID, ob.clinic,ob.Date)

                };
                patientsDatas.Add(patientsData);
            }

            return Ok(patientsDatas);
        }

        private async Task<string> DoctorName(int patientid, int id, DateTime date)
        {
            var Clinics_Name = await _context.Clinics.Where(c => c.Id == id).Select(c => c.Name).FirstOrDefaultAsync();
            var pat_Doc = await _context.PatientDoctors.Where(pd => pd.Idpatient == patientid && pd.Date.Day == date.Day && pd.Date.Month == date.Month && pd.Date.Year == date.Year)
                .OrderBy(da => da.Date).Select(i => i.Iddoctor).ToListAsync();
            if (pat_Doc != null)
            {
                foreach (var ids in pat_Doc)
                {
                    var Doctor = await _context.Doctors.Where(d => d.Id == ids && d.Specialization == Clinics_Name).FirstOrDefaultAsync();
                    if (Doctor != null)
                        return Doctor.Fname + " " + Doctor.Mname + " " + Doctor.Mname2 + " " + Doctor.Lname;
                }
            }
            return "no";

        }

        //[HttpGet("SearchPatientsByDateForadmin")]
        //public ActionResult SearchPatientsByDateForadmin()
        //{
        //    var date = DateTime.Now;
        //    var datelist = _context.DiseasHistories.Select(p => new { p.Clinics.Name, p.Date, p.Patient.Id, p.Patient.Fname, p.Patient.Mname, p.Patient.Mname2 });
        //    return Ok(datelist);
        //}

        // show all clincis
        [HttpGet("showClincis")]
        public ActionResult showClinics() 
        {
            return Ok(_context.Clinics.Select(c=>c.Name));
        
        }

        [HttpGet("PatientHistories/{MilitaryNumber}")]
        public ActionResult PatientHistories(int MilitaryNumber)
        {
            var patient = _context.Patients.Where(p => p.MilitaryNumber == MilitaryNumber).FirstOrDefault();
            if (patient == null)
                return NotFound();
            else
            {
                int countClinics = _context.Clinics.Count();

                List<List<string>> PatientData1 = new List<List<string>>();
                for (int i = 1; i <= countClinics; i++)
                {

                    // var Doctor_Name = DoctorName(i);

                    var data = _context.DiseasHistories.Where(c => c.ClinicsId == i && c.PatientId == patient.Id&&c.Waiting==true)
                        .Select(d => d.Date.ToString("dd/MM/yyyy HH:mm:ss tt")).ToList();

                    // data.Add(Doctor_Name);
                    PatientData1.Add(data);

                }

                return Ok(PatientData1);
            }
        }
        [HttpGet("ExternalExamination")]
        public async Task<ActionResult> ExternalExamination(DateTime date)
        {
            List<External_Examination> external = new List<External_Examination>();
            if (date != null)
            {
               // var date1 = date;
                var data1 = _context.DiseasHistories.Where(d => d.Date.Day == date.Day && d.Date.Month == date.Month && d.Date.Year == date.Year && d.ExtrenalExamination == true).ToList();
                foreach (var input in data1)
                {
                    External_Examination external1 = new External_Examination()
                    {
                        Clin_name = _context.Clinics.Where(c => c.Id == input.ClinicsId).Select(name => name.Name).FirstOrDefault(),
                        Decribe = input.Describe,
                        Mrecommend = input.Mrecommend,
                        Doctor_name = await DoctorName(input.PatientId, input.ClinicsId, input.Date)
                    };
                    external.Add(external1);
                }
                return Ok(external);
            }
            else 
            {
                var data = _context.DiseasHistories.Where(d => d.ExtrenalExamination == true).ToList();
                foreach (var input in data)
                {
                    External_Examination external1 = new External_Examination()
                    {
                        Clin_name = _context.Clinics.Where(c => c.Id == input.ClinicsId).Select(name => name.Name).FirstOrDefault(),
                        Decribe = input.Describe,
                        Mrecommend = input.Mrecommend,
                        Doctor_name = await DoctorName(input.PatientId, input.ClinicsId, input.Date)
                    };
                    external.Add(external1);
                }
                return Ok(external);
            }
        }
        [HttpGet("GetPatientByDates/{Fdate}/{Sdate}")]
        public async Task<ActionResult> GetPatientByDates(DateTime Fdate, DateTime Sdate)
        {
           // var list_patient = await _context.DiseasHistories.Where(d=>d.Date.Day==F)
            var x = await PatientHistory("17", "7");
            return Ok(x);
        }
        private async Task<ActionResult<List<patientHistory>>> PatientHistory(string patientID, string clinID)
        {
            List<patientHistory> patientHistoies2 = new List<patientHistory>();
            var dates = await _context.DiseasHistories.Where(c => c.ClinicsId == int.Parse(clinID) && c.PatientId == int.Parse(patientID) && c.Waiting == true)
                .Select(d => new { d.Date, d.Describe,clincname = d.Clinics.Name }).ToListAsync();
            if (dates.Count() != 0)
            {
                foreach (var model in dates)
                {
                    var doctorname = await DoctorName1(int.Parse(patientID), int.Parse(clinID), model.Date);
                    var drugnames = await drugname(int.Parse(patientID), int.Parse(clinID), model.Date);
                    if (doctorname != null)
                    {
                        patientHistory patientHistoy = new patientHistory()
                        {
                            clincName = model.clincname,
                            date = model.Date.ToString("dd/MM/yyyy HH:mm:ss tt"),
                            Descripe = model.Describe,
                            Doctor_Name = doctorname,
                            Drugsnames = drugnames
                        };
                        patientHistoies2.Add(patientHistoy);
                    }
                }
                // var Doctor_Name = await DoctorName(int.Parse(clinID));
                if (patientHistoies2 != null)
                    return Ok(patientHistoies2);
                else
                    return BadRequest();
            }
            else
                return NotFound();
            // return Ok(patientHistoies2);
        }
        //[HttpGet("DoctorName")]
        private async Task<string> DoctorName1(int patientid, int id, DateTime date)
        {
            var Clinics_Name = await _context.Clinics.Where(c => c.Id == id).Select(c => c.Name).FirstOrDefaultAsync();
            var pat_Doc = await _context.PatientDoctors.Where(pd => pd.Idpatient == patientid && pd.Date.Day == date.Day && pd.Date.Month == date.Month && pd.Date.Year == date.Year)
                .OrderBy(da => da.Date).Select(i => i.Iddoctor).ToListAsync();
            if (pat_Doc.Count() != 0)
            {
                foreach (var ids in pat_Doc)
                {
                    var Doctor = await _context.Doctors.Where(d => d.Id == ids && d.Specialization == Clinics_Name).FirstOrDefaultAsync();
                    if (Doctor != null)
                        return Doctor.Fname + " " + Doctor.Mname + " " + Doctor.Mname2 + " " + Doctor.Lname;
                }
            }
            return null;

        }

        private async Task<List<drugsnames>> drugname(int patientid, int clinid, DateTime date)
        {

            List<drugsnames> drugname = new List<drugsnames>();

            var drug = await _context.Prescriptions.Where(p => p.PatientID == patientid && p.Clin_ID == clinid && p.Done_Drug == true).ToListAsync();
            foreach (var ob in drug)
            {
                if (ob.Date.Day == date.Day && ob.Date.Month == date.Month && ob.Date.Year == date.Year)
                {
                    var drugsnames1 = new drugsnames()
                    {
                        Amount = ob.DrugAmount,
                        AmountPday = ob.DrugAmountPday,
                        Duration = ob.Duration,
                        name = ob.DrugName,
                        date = ob.Date.ToString("dd/MM/yyyy HH:mm:ss tt")

                    };
                    drugname.Add(drugsnames1);
                }

            }


            return drugname;
        }

        [HttpGet("DoneDrugs")]
        public async Task<ActionResult> DoneDrugs(DateTime? date) 
        {
            List<drugsinfo> druginfo = new List<drugsinfo>();
            if (date != null)
            {
                var drugs = await _context.Prescriptions.Where(p => p.Done_Drug == true && p.Date.Day == date.Value.Day && p.Date.Month == date.Value.Month && p.Date.Year == date.Value.Year)
                .Select(d => new { d.DrugName, d.DrugAmount, date = d.Date.ToString("dd/MM/yyyy HH:mm:ss tt") ,d.phar_id}).ToListAsync();

                if (drugs.Count == 0)
                    return NotFound();
                else
                {
                    foreach(var model in drugs)
                    {
                        var name = _context.Pharmacists.Where(p => p.Id == model.phar_id).Select(p => p.Fname + " " + p.Mname + " " + p.Mname2 + " " + p.Lname).FirstOrDefault();
                        var drugsinof = new drugsinfo() 
                        { 
                            Drug_name=model.DrugName,
                            Amount =model.DrugAmount,
                            date=model.date,
                            pharmacist_name = name
                        };
                        druginfo.Add(drugsinof);
                    }
                    return Ok(druginfo);
                }
                    
            }
            else
            {
                var drugs = await _context.Prescriptions.Where(p => p.Done_Drug == true)
               .Select(d => new { d.DrugName, d.DrugAmount, date = d.Date.ToString("dd/MM/yyyy HH:mm:ss tt"),d.phar_id }).ToListAsync();
                foreach (var model in drugs)
                {
                    var name = _context.Pharmacists.Where(p => p.Id == model.phar_id).Select(p => p.Fname + " " + p.Mname + " " + p.Mname2 + " " + p.Lname).FirstOrDefault();
                    var drugsinof = new drugsinfo()
                    {
                        Drug_name = model.DrugName,
                        Amount = model.DrugAmount,
                        date = model.date,
                        pharmacist_name = name
                    };
                    druginfo.Add(drugsinof);
                }
                return Ok(druginfo);
            }
            
        }
        [HttpGet("TotalDrugs")]
        public ActionResult TotalDrugs(DateTime? date)
        {
            if(date==null)
            {
                var total = _context.Drugs.Select(t => new { DrugName = t.Name, t.Amount, t.Category, PharmacistName = t.Pharmacist.Fname + " " + t.Pharmacist.Mname + " " + t.Pharmacist.Mname2, date = t.AddDate.ToString("dd/MM/yyyy HH:mm:ss tt") });
                return Ok(total);
            }
            else
            {
                var total = _context.Drugs.Where(d=>d.AddDate.Day==date.Value.Day&& d.AddDate.Month == date.Value.Month && d.AddDate.Year == date.Value.Year )
                    .Select(t => new { DrugName = t.Name, t.Amount, t.Category, PharmacistName = t.Pharmacist.Fname + " " + t.Pharmacist.Mname + " " + t.Pharmacist.Mname2, date = t.AddDate.ToString("dd/MM/yyyy HH:mm:ss tt") }).ToList();
                if (total.Count != 0)
                    return Ok(total);
                else
                    return NotFound();
            }
        }
        private bool AdminExists(int id)
        {
            return _context.Admins.Any(e => e.Id == id);
        }
        private bool PharmacistExists(int id)
        {
            return _context.Pharmacists.Any(e => e.Id == id);
        }
        private bool ReceptionestExists(int id)
        {
            return _context.Pharmacists.Any(e => e.Id == id);
        }
    }
    
}

public class patientsData
{
    public string ClincName { get; set; }
    public string Date { get; set; }
    public int patientID { get; set; }
    public int age { get; set; }
    public string PatientName { get; set; }
    public string Describe { get; set; }
    public string Mrecommend { get; set; }
    public string Doctor_Name { get; set; }
}

public class patientCount
{
    public string ClinicName { get; set; }
    public int count { get; set; }
}

public class ErorrInfo
{
    public string Attribute { get; set; }
}

public class External_Examination
{
    public string Clin_name { get; set; }
    public string Doctor_name { get; set; }
    public string Decribe { get; set; }
    public string Mrecommend { get; set; }

}
public class drugsinfo
{
    public string pharmacist_name { get; set; }
    public string Drug_name { get; set; }
    public int Amount { get; set; }
    public string date { get; set; }
}

