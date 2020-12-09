using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using orgSemasi.Helpers;
using orgSemasi.Models;

namespace orgSemasi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfisController : ControllerBase
    {
        private readonly MainDbContext _context;

        public OfisController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/Ofis
        [HttpGet]
        public IEnumerable<Ofis> GetOfis()
        {
            return _context.Ofis.Include(p=>p.Bolge.Organizasyon.Sirket);
        }

        // GET: api/Ofis/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOfis([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ofis = await _context.Ofis.FindAsync(id);

            if (ofis == null)
            {
                return NotFound();
            }

            return Ok(ofis);
        }

        // PUT: api/Ofis/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfis([FromRoute] int id, [FromBody] Ofis ofis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ofis.Id)
            {
                return BadRequest();
            }

            _context.Entry(ofis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfisExists(id))
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

        // POST: api/Ofis
        [HttpPost]
        public async Task<IActionResult> PostOfis([FromBody] Ofis ofis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Ofis.Add(ofis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfis", new { id = ofis.Id }, ofis);
        }

        // DELETE: api/Ofis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfis([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ofis = await _context.Ofis.FindAsync(id);
            if (ofis == null)
            {
                return NotFound();
            }

            _context.Ofis.Remove(ofis);
            await _context.SaveChangesAsync();

            return Ok(ofis);
        }

        private bool OfisExists(int id)
        {
            return _context.Ofis.Any(e => e.Id == id);
        }
    }
}