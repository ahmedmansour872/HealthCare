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
    public class ReservedPatientsController : ControllerBase
    {
        private readonly HealthCareContexttest _context;

        public ReservedPatientsController(HealthCareContexttest context)
        {
            _context = context;
        }

        // GET: api/ReservedPatients
        [HttpGet]
        public async Task<ActionResult> GetReservedPatients()
        {
            var x= await _context.ReservedPatients.Select(r => r.BedNumberNavigation.Busy).ToListAsync();
            return Ok(x);
        }

        // GET: api/ReservedPatients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservedPatient>> GetReservedPatient(int id)
        {
            var reservedPatient = await _context.ReservedPatients.FindAsync(id);

            if (reservedPatient == null)
            {
                return NotFound();
            }

            return reservedPatient;
        }

        // PUT: api/ReservedPatients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservedPatient(int id, ReservedPatient reservedPatient)
        {
            if (id != reservedPatient.ReservedId)
            {
                return BadRequest();
            }

            _context.Entry(reservedPatient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservedPatientExists(id))
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

        // POST: api/ReservedPatients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ReservedPatient>> PostReservedPatient(ReservedPatient reservedPatient)
        {
            var reservedPatient1 = new ReservedPatient() 
            {
                BedNumber = reservedPatient.BedNumber,
                Date=DateTime.Now,
                DoctorId=reservedPatient.DoctorId,
                PatientId = reservedPatient.PatientId
            };
            _context.ReservedPatients.Add(reservedPatient1);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReservedPatientExists(reservedPatient.ReservedId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReservedPatient", new { id = reservedPatient.ReservedId }, reservedPatient);
        }

        // DELETE: api/ReservedPatients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReservedPatient>> DeleteReservedPatient(int id)
        {
            var reservedPatient = await _context.ReservedPatients.FindAsync(id);
            if (reservedPatient == null)
            {
                return NotFound();
            }

            _context.ReservedPatients.Remove(reservedPatient);
            await _context.SaveChangesAsync();

            return reservedPatient;
        }

        private bool ReservedPatientExists(int id)
        {
            return _context.ReservedPatients.Any(e => e.ReservedId == id);
        }
    }
}
