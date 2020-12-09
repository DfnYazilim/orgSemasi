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
    public class TakimController : ControllerBase
    {
        private readonly MainDbContext _context;

        public TakimController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/Takim
        [HttpGet]
        public IEnumerable<Takim> GetTakim()
        {
            return _context.Takim.Include(p=>p.Ofis.Bolge.Organizasyon.Sirket);
        }

        // GET: api/Takim/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTakim([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var takim = await _context.Takim.FindAsync(id);

            if (takim == null)
            {
                return NotFound();
            }

            return Ok(takim);
        }

        // PUT: api/Takim/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTakim([FromRoute] int id, [FromBody] Takim takim)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != takim.Id)
            {
                return BadRequest();
            }

            _context.Entry(takim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TakimExists(id))
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

        // POST: api/Takim
        [HttpPost]
        public async Task<IActionResult> PostTakim([FromBody] Takim takim)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Takim.Add(takim);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTakim", new { id = takim.Id }, takim);
        }

        // DELETE: api/Takim/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTakim([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var takim = await _context.Takim.FindAsync(id);
            if (takim == null)
            {
                return NotFound();
            }

            _context.Takim.Remove(takim);
            await _context.SaveChangesAsync();

            return Ok(takim);
        }

        private bool TakimExists(int id)
        {
            return _context.Takim.Any(e => e.Id == id);
        }
    }
}