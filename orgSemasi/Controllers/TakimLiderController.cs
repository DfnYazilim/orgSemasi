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
    public class TakimLiderController : ControllerBase
    {
        private readonly MainDbContext _context;

        public TakimLiderController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/TakimLider
        [HttpGet]
        public IEnumerable<TakimLider> GetTakimLider()
        {
            return _context.TakimLider.Include(p=>p.Takim.Ofis.Bolge.Organizasyon.Sirket).Include(p=>p.Kullanici);
        }

        // GET: api/TakimLider/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTakimLider([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var takimLider = await _context.TakimLider.FindAsync(id);

            if (takimLider == null)
            {
                return NotFound();
            }

            return Ok(takimLider);
        }

        // PUT: api/TakimLider/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTakimLider([FromRoute] int id, [FromBody] TakimLider takimLider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != takimLider.Id)
            {
                return BadRequest();
            }

            _context.Entry(takimLider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TakimLiderExists(id))
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

        // POST: api/TakimLider
        [HttpPost]
        public async Task<IActionResult> PostTakimLider([FromBody] TakimLider takimLider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TakimLider.Add(takimLider);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTakimLider", new { id = takimLider.Id }, takimLider);
        }

        // DELETE: api/TakimLider/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTakimLider([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var takimLider = await _context.TakimLider.FindAsync(id);
            if (takimLider == null)
            {
                return NotFound();
            }

            _context.TakimLider.Remove(takimLider);
            await _context.SaveChangesAsync();

            return Ok(takimLider);
        }

        private bool TakimLiderExists(int id)
        {
            return _context.TakimLider.Any(e => e.Id == id);
        }
    }
}