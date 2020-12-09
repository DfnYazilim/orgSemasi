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
    public class BolgeController : ControllerBase
    {
        private readonly MainDbContext _context;

        public BolgeController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/Bolge
        [HttpGet]
        public IEnumerable<Bolge> GetBolge()
        {
            return _context.Bolge.Include(p=>p.Organizasyon.Sirket);
        }

        // GET: api/Bolge/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBolge([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bolge = await _context.Bolge.FindAsync(id);

            if (bolge == null)
            {
                return NotFound();
            }

            return Ok(bolge);
        }

        // PUT: api/Bolge/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBolge([FromRoute] int id, [FromBody] Bolge bolge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bolge.Id)
            {
                return BadRequest();
            }

            _context.Entry(bolge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BolgeExists(id))
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

        // POST: api/Bolge
        [HttpPost]
        public async Task<IActionResult> PostBolge([FromBody] Bolge bolge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bolge.Add(bolge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBolge", new { id = bolge.Id }, bolge);
        }

        // DELETE: api/Bolge/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBolge([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bolge = await _context.Bolge.FindAsync(id);
            if (bolge == null)
            {
                return NotFound();
            }

            _context.Bolge.Remove(bolge);
            await _context.SaveChangesAsync();

            return Ok(bolge);
        }

        private bool BolgeExists(int id)
        {
            return _context.Bolge.Any(e => e.Id == id);
        }
    }
}