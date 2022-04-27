using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly HealthCareContexttest _context;
        public PatientsController(HealthCareContexttest context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return await _context.Patients.ToListAsync();
        }
        [HttpGet("GetPatientById/{id}")]
        public ActionResult GetPatientById(int id)
        {
            var patient = _context.Patients.Where(p => p.Id == id).FirstOrDefault();
            if (patient == null) return NotFound();
            else return Ok(patient);
        }


        [HttpGet("{f_name}/{m_name1}/{m_name2}/{l_name}")]
        public ActionResult<List<Patient>> SearchForPatientByName(string f_name, string m_name1, string m_name2, string l_name)
        {

            if (m_name1 == null && m_name2 == null && l_name == null)
            {
                var patientsList = _context.Patients.Where(patient => patient.Fname == f_name).ToList();

                return Ok(patientsList);
            }
            if (m_name2 == null && l_name == null)
            {
                var patients = _context.Patients.Where(patient => patient.Fname == f_name && patient.Mname == m_name1).ToList();
                return Ok(patients);
            }
            if (l_name == null)
            {
                var patient_list = _context.Patients.Where(patient => patient.Fname == f_name && patient.Mname == m_name1 && patient.Mname2 == m_name2).ToList();
                return Ok(patient_list);
            }
            var patient = _context.Patients.Where(patient => patient.Fname == f_name && patient.Mname == m_name1 && patient.Mname2 == m_name2 && patient.Lname == l_name).ToList();
            return Ok(patient);
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
                // var DoctorID = _context.PatientDoctors.Where(p=>p.Idpatient==patient.Id&&p.Date.Day==date.Day&&p.Date.Month==date.Month&&p.Date.Year==date.Year).FirstOrDefault();
                //var DoctorName = _context.Doctors.Where(d => d.Id == DoctorID.Id).FirstOrDefault();

                return Ok(patient);
            }

        }
        [HttpGet("SearchPatientByNationalID/{nationalid}")]
        public ActionResult SearchForPatientByNationalID(long nationalid)
        {
            var patient = _context.Patients.Where(patient => patient.NationalId == nationalid).FirstOrDefault();

            if (patient == null)
            {
                return BadRequest("المريض غير مسجل بالنظام");
            }
            else
                return Ok(patient);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }
            _context.Entry(patient).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
                {
                    return BadRequest("Not Found");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost("PostPatient")]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {

            if (patient != null)
            {
                var pat = _context.Patients.Where(p => p.MilitaryNumber == patient.MilitaryNumber || p.NationalId == patient.NationalId).FirstOrDefault();
                if (pat != null)
                    return BadRequest();
                else
                {
                    Patient newPatient = new Patient()
                    {
                        age = patient.age,
                        Fname = patient.Fname,
                        Gender = patient.Gender,
                        Lname = patient.Lname,
                        MilitaryNumber = patient.MilitaryNumber,
                        Mname = patient.Mname,
                        Mname2 = patient.Mname2,
                        NationalId = patient.NationalId,
                        Nationality = patient.Nationality,
                        Rank = patient.Rank,
                        ReceptionestId = patient.ReceptionestId,
                        Religion = patient.Religion,
                        Reserved = patient.Reserved
                    };
                    _context.Patients.Add(newPatient);
                    await _context.SaveChangesAsync();

                    return Ok(newPatient);

                }
            }
            else
                return BadRequest("Bad request");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Patient>> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return BadRequest("Not Found");
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

        [HttpPost("BookingClinics/{ClinicId}/{PatientId}")]
        public ActionResult BookingClinics(int ClinicId, int PatientId)
        {
            var date = DateTime.Now;
            if (ClinicId.Equals(null))
                return BadRequest("لم يتم تحديد العيادة");
            else
            {
                var checkPatient = _context.DiseasHistories
                    .Where(d => d.PatientId == PatientId && d.ClinicsId == ClinicId && d.Date.Day == date.Day && d.Date.Month == date.Month && d.Date.Year == date.Year)
                    .FirstOrDefault();
                if (checkPatient != null)
                {
                    return BadRequest("تم حجز كشف في العيادة للمريض اليوم....");

                }
                var clinic = _context.Clinics.Where(c => c.Id == ClinicId).FirstOrDefault();
                if (clinic != null)
                {
                    var BookClinics = new DiseasHistory()
                    {
                        Date = date,
                        PatientId = PatientId,
                        ClinicsId = clinic.Id
                    };
                    _context.DiseasHistories.Add(BookClinics);
                    _context.SaveChanges();
                    return Ok("تم حجز العيادة بنجاح");
                }
                else
                    return BadRequest("العيادة غير متاحة");
            }
        }
        // get patient next in Prescription
        //[HttpGet("getNext/{ClinicID}")]
        private int getNext(int ClinicID)
        {
            var numbers = 0;
            var datelist = _context.DiseasHistories.Where(c => c.ClinicsId == ClinicID)
                .Select(d => d.Date.ToString("dd/MM/yyyy HH:mm:ss tt")).ToList();

            foreach (var date in datelist)
            {
                if (date.Contains(DateTime.Now.ToString("dd/MM/yyyy")))
                {
                    numbers++;
                }
            }
            return numbers;
            //بيرجع التاريخ مفصل باللغة الجهاز
            //DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")
        }
        [HttpGet("ticket/{ClinicID}/{patientID}")]
        public List<string> ticket(int ClinicID, int patientID)
        {
            var datenow = DateTime.Now;
            if (ClinicID.ToString() == null || patientID.ToString() == null)
            {
                return null;
            }
            else
            {
                var patient = _context.Patients.Where(p => p.Id == patientID).FirstOrDefault();
                var patient_name = patient.Fname + " " + patient.Mname + " " + patient.Mname2 + " " + patient.Lname;
                var clinic_name = _context.Clinics.Where(c => c.Id == ClinicID).Select(clinic => clinic.Name).FirstOrDefault().ToString();
                var date = _context.DiseasHistories
                    .Where(c => c.ClinicsId == ClinicID && c.PatientId == patientID && c.Date.Day == datenow.Day && c.Date.Month == datenow.Month && c.Date.Year == datenow.Year)
                    .Select(d => d.Date.ToString("dddd, dd MMMM yyyy HH:mm:ss tt")).ToList();
                List<string> patientClinic = new List<string>();
                var next = getNext(ClinicID).ToString();
                patientClinic.Add(next);
                patientClinic.Add(patient_name);
                patientClinic.Add(clinic_name);
                patientClinic.Add(patient.age.ToString());
                patientClinic.Add(date.Last());

                return patientClinic;
            }
        }


        // [HttpGet("PatientHistory/{patientID}/{clinID}")]
        //public async Task<ActionResult> PatientHistory(string patientID, string clinID)
        //{
        //    // int countClinics = _context.Clinics.Count();
        //    patientHistory patientHistory = new patientHistory();
        //    //List<List<string>> PatientData = new List<List<string>>();
        //    var Doctor_Name = await DoctorName(int.Parse(clinID));
        //    var date = await _context.DiseasHistories.Where(c => c.ClinicsId == int.Parse(clinID) && c.PatientId == int.Parse(patientID))
        //        .Select(d => d.Date).ToListAsync();
        //    List<string> des = await _context.DiseasHistories.Where(c => c.ClinicsId == int.Parse(clinID) && c.PatientId == int.Parse(patientID)).Select(d => d.Describe).ToListAsync();
        //    // data.Add(Doctor_Name);
        //    // var date = await _context.DiseasHistories.Where(c => c.ClinicsId == int.Parse(clinID) && c.PatientId == int.Parse(patientID)).tolist();
        //    patientHistory.Date = date;
        //    patientHistory.Doctor_Name = Doctor_Name;
        //    patientHistory.Descripe = des;
        //    foreach (var model in date)
        //    {
        //        var res = await drugname(int.Parse(patientID), int.Parse(clinID), model);
        //        patientHistory.Drugsnames = res;
        //    }

        //    //patientHistory.Drugsnames =await drugname(int.Parse(patientID), int.Parse(clinID),date);
        //    if (patientHistory.Date.Count != 0 && patientHistory.Descripe.Count != 0 && patientHistory.Doctor_Name.Count != 0)
        //        return Ok(patientHistory);
        //    else
        //        return NotFound();

        //}

        [HttpGet("PatientHistories/{patientID}")]
        public async Task<List<List<string>>> PatientHistories(int patientID)
        {
            int countClinics = _context.Clinics.Count();
            List<List<string>> PatientData = new List<List<string>>();
            for (var i = 1; i <= countClinics; i++)
            {
                int flag = 0;
                List<string> doc_name =new List<string>();
                var patients = _context.DiseasHistories.Where(c => c.ClinicsId == i && c.PatientId == patientID && c.Waiting == true).Select(d => d.Date.ToString()).ToList();
                foreach (var model in patients)
                {
                    var Doctor_Name = await DoctorName(patientID, i, DateTime.Parse(model));
                    if (Doctor_Name != null)
                    {
                        flag = 1;
                        //doc_name = Doctor_Name;
                    }
                }
                if (flag != 0)
                {
                    doc_name = patients;
                }
                    
                else
                    flag = 0;

                PatientData.Add(doc_name);
            }
            return PatientData;
        }

        [HttpGet("PatientHistory/{patientID}/{clinID}")]
        public async Task<ActionResult> PatientHistory(string patientID, string clinID)
        {
            List<patientHistory> patientHistoies2 = new List<patientHistory>();
            var dates = await _context.DiseasHistories.Where(c => c.ClinicsId == int.Parse(clinID) && c.PatientId == int.Parse(patientID) &&c.Waiting==true )
                .Select(d => new { d.Date, d.Describe }).ToListAsync();
            if(dates.Count()!=0)
            {
                foreach (var model in dates)
                {
                    var doctorname = await DoctorName(int.Parse(patientID), int.Parse(clinID), model.Date);
                    var drugnames = await drugname(int.Parse(patientID), int.Parse(clinID), model.Date);
                    if (doctorname != null )
                    {
                        patientHistory patientHistoy = new patientHistory()
                        {
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
        private async Task<string> DoctorName(int patientid, int id, DateTime date)
        {
            var Clinics_Name = await _context.Clinics.Where(c => c.Id == id).Select(c => c.Name).FirstOrDefaultAsync();
            var pat_Doc = await _context.PatientDoctors.Where(pd => pd.Idpatient == patientid && pd.Date.Day == date.Day && pd.Date.Month == date.Month && pd.Date.Year == date.Year)
                .OrderBy(da => da.Date).Select(i => i.Iddoctor).ToListAsync();
            if (pat_Doc.Count()!=0)
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
        //[HttpGet("doctor")]
        //public async Task<string> DoctorName1(int patientid, int id, DateTime date)
        //{
        //    var Clinics_Name = await _context.Clinics.Where(c => c.Id == id).Select(c => c.Name).FirstOrDefaultAsync();
        //    var pat_Doc = await _context.PatientDoctors.Where(pd => pd.Idpatient == patientid && pd.Date.Day == date.Day && pd.Date.Month == date.Month && pd.Date.Year == date.Year)
        //        .OrderBy(da=>da.Date).Select(d => d.Iddoctor).LastAsync();
        //    var Doctor = await _context.Doctors.Where(d => d.Id == pat_Doc && d.Specialization == Clinics_Name).FirstOrDefaultAsync();
        //    if (Doctor != null)
        //        return Doctor.Fname + " " + Doctor.Mname + " " + Doctor.Mname2 + " " + Doctor.Lname;

        //    else
        //        return pat_Doc.ToString();

        //}
        ////[HttpGet("drugname/{patientid}/{clinid}")]


        [HttpGet("showdate")]
        public async Task< ActionResult> showdate(string patientID, string clinID)
        {
            var dates = await _context.DiseasHistories.Where(c => c.ClinicsId == int.Parse(clinID) && c.PatientId == int.Parse(patientID))
                .Select(d => new { d.Date, d.Describe }).ToListAsync();
            
            return Ok(dates.Count());
        }

        //private async Task<string> DoctorName2(int patientid, int id, DateTime date)
        //{
        //    var Clinics_Name = await _context.Clinics.Where(c => c.Id == id).Select(c => c.Name).FirstOrDefaultAsync();
        //    var pat_Doc = await _context.PatientDoctors.Where(pd => pd.Idpatient == patientid && pd.Date.Day == date.Day && pd.Date.Month == date.Month && pd.Date.Year == date.Year)
        //        .Select(d =>d.Iddoctor).FirstOrDefaultAsync();
        //    var Doctor = await _context.Doctors.Where(d => d.Id == pat_Doc && d.Specialization == Clinics_Name).FirstOrDefaultAsync();
        //    if (Doctor == null)
        //        return "no";
        //    else
        //        return Doctor.Fname+" "+Doctor.Mname+" "+Doctor.Mname2+" "+Doctor.Lname;

        //}


        //[HttpGet("showdata")]
        //public ActionResult showdata()
        //{
        //    var db = _context.DiseasHistories.Select(p => new { p.Clinics.Name, p.Date, p.Id }).ToList();
        //    return Ok(db);
        //}

        //[HttpGet("patientHistory")]
        //public async Task<ActionResult> patientHistory(int patientID,int clinID)
        //{
        //   // var date = DateTime.Now;
        //    var history =await  _context.DiseasHistories.Where(h=>h.PatientId==patientID&&h.ClinicsId==clinID&&h.Waiting==true)
        //        .Select(b=>new { b.Describe,b.Mrecommend,b.Date }).ToListAsync();
        //    if (history == null)
        //        return NotFound("لا يوجد تاريخ مرضي لهذا المريض");
        //    else
        //    {
        //        patientHistory patient = new patientHistory();
        //        for (int i=0;i<=history.Count(); i++)
        //        {
        //            var doctorname = _context.PatientDoctors.Where(d => d.Idpatient == patientID).Select(c => c.IddoctorNavigation.Fname);
        //            patient.Date.Add(history[i].Date);
        //        }

        //    }


        //   //List<patientHistory> patienthistory = new List<patientHistory>();


        //    return Ok("asd");
        //}
        private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }
    }

}

public class patientHistory
{
    public string date { get; set; }
    public string clincName { get; set; }
    public string Descripe { get; set; }
    public string Doctor_Name { get; set; }
    public List<drugsnames> Drugsnames { get; set; }
}

public class drugsnames
{
    public string name { get; set; }
    public int Amount { get; set; }
    public int AmountPday { get; set; }
    public int Duration { get; set; }
    public string date { get; set; }
}
