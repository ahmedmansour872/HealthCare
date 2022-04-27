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
    public class DrugsController : ControllerBase
    {
        private readonly HealthCareContexttest _context;

        public DrugsController(HealthCareContexttest context)
        {
            _context = context;
        }

        // GET: api/Drugs
        [HttpGet("showDrugs")]
        public async Task<ActionResult> GetDrugs()
        {
            var drug =await _context.Drugs.Select(d=>new {d.Name,d.Amount }).ToListAsync();
            return  Ok(drug);
        }

        // GET: api/Drugs/5
        [HttpGet("searchDrug/{drugname}")]
        public async Task<ActionResult<Drug>> GetDrug(string drugname)
        {
            var drug = await _context.Drugs.Where(d=>d.Name==drugname).FirstOrDefaultAsync();

            if (drug == null)
            {
                return NotFound();
            }

            return drug;
        }

        // PUT: api/Drugs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrug(int id, Drug drug)
        {
            if (id != drug.Id)
            {
                return BadRequest();
            }

            _context.Entry(drug).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrugExists(id))
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


        [HttpPost("addDrug")]
        public async Task<ActionResult> PostDrug(Drug drug)
        {
            var cate = "";
            var dr = await _context.Drugs.Where(d => d.Name == drug.Name).FirstOrDefaultAsync();
            if (drug != null)
            {
                if (dr != null)
                {
                    dr.Amount = drug.Amount + dr.Amount;
                    _context.Entry(dr).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok(dr);
                }
                else
                {
                    if (drug.Category == "1")
                        cate = "دواء شرب";
                    if (drug.Category == "2")
                        cate = "مرهم";
                    if (drug.Category == "3")
                        cate = "حقن";
                    if (drug.Category == "4")
                        cate = "حبوب";
                    if (drug.Category == "5")
                        cate = "قطرة";
                    drug.AddDate = DateTime.Now;
                    drug.Category = cate;
                    _context.Drugs.Add(drug);
                    await _context.SaveChangesAsync();
                    return Ok(drug);
                }
            }
            else
                return BadRequest();
            
        }


        [HttpGet("GetDrugsBYcategory/{Category}")]
        public async Task<ActionResult> GetDrugsBYcategory(string Category)
        {
            var cate = "";
            if (Category == "1")
                cate = "شرب";
            if (Category == "2")
                cate = "مرهم";
            if (Category == "3")
                cate = "حقن";
            if (Category == "4")
                cate = "حبوب";
            if (Category == "5")
                cate = "قطرة";
            var drugs =await _context.Drugs.Where(d => d.Category == cate).ToListAsync();
            if (drugs != null)
                return Ok(drugs);
            else
                return BadRequest(null);
        }

        // DELETE: api/Drugs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Drug>> DeleteDrug(int id)
        {
            var drug = await _context.Drugs.FindAsync(id);
            if (drug == null)
            {
                return NotFound();
            }

            _context.Drugs.Remove(drug);
            await _context.SaveChangesAsync();

            return drug;
        }

        private bool DrugExists(int id)
        {
            return _context.Drugs.Any(e => e.Id == id);
        }
    }
}
