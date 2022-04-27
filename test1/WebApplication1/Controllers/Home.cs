using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Home : ControllerBase
    {
        private readonly HealthCareContexttest _context;

        public Home(HealthCareContexttest context)
        {
            _context = context;
        }
        [HttpGet("login/{email}/{password}/{roleID}")]
        public ActionResult login(string email , string password, int roleID)
        {
            if (roleID == 2)
            {
                var Doctor = _context.Doctors.Where(x => x.Username == email && x.Password == password).FirstOrDefault();
                if (Doctor != null&&Doctor.Username!="##"&&Doctor.Password!="##") 
                    return Ok(Doctor);        
                else
                    return BadRequest("الدكتور غير مسجل في النظام");
            }
            else if (roleID == 3)
            {
                var Pharmacist = _context.Pharmacists.Where(x => x.Username == email && x.Password == password).FirstOrDefault();
                if (Pharmacist != null && Pharmacist.Username != "##" && Pharmacist.Password != "##")
                    return Ok(Pharmacist);
                else
                    return BadRequest("الصيدلي غير مسجل في النظام");

            }
            else if (roleID == 1)
            {
                var Receptionest = _context.Receptionests.Where(x => x.Username == email && x.Password == password).FirstOrDefault();
                if (Receptionest != null && Receptionest.Username != "##" && Receptionest.Password != "##")
                    return Ok(Receptionest);
                else
                    return BadRequest("المستقبل غير مسجل في النظام");

            }
            else
                return BadRequest();
        }
    }
}
