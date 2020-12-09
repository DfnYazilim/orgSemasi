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
    public class UyeController : ControllerBase
    {
        private readonly MainDbContext _context;

        public UyeController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/Uye
        [HttpGet]
        public IEnumerable<Uye> GetUye()
        {
            return _context.Uye.Include(p=>p.Kullanici).Include(p=>p.Takim.Ofis.Bolge.Organizasyon.Sirket);
        }

        // GET: api/Uye/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUye([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var uye = await _context.Uye.FindAsync(id);

            if (uye == null)
            {
                return NotFound();
            }

            return Ok(uye);
        }

        // PUT: api/Uye/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUye([FromRoute] int id, [FromBody] Uye uye)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uye.Id)
            {
                return BadRequest();
            }

            _context.Entry(uye).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UyeExists(id))
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

        // POST: api/Uye
        [HttpPost]
        public async Task<IActionResult> PostUye([FromBody] Uye uye)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Uye.Add(uye);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUye", new { id = uye.Id }, uye);
        }

        // DELETE: api/Uye/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUye([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var uye = await _context.Uye.FindAsync(id);
            if (uye == null)
            {
                return NotFound();
            }

            _context.Uye.Remove(uye);
            await _context.SaveChangesAsync();

            return Ok(uye);
        }

        private bool UyeExists(int id)
        {
            return _context.Uye.Any(e => e.Id == id);
        }
    }
}