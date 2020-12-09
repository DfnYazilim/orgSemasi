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
    public class KullaniciController : ControllerBase
    {
        private readonly MainDbContext _context;

        public KullaniciController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/Kullanici
        [HttpGet]
        public IEnumerable<Kullanici> GetKullanici()
        {
            return _context.Kullanici;
        }

        // GET: api/Kullanici/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKullanici([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kullanici = await _context.Kullanici.FindAsync(id);

            if (kullanici == null)
            {
                return NotFound();
            }

            return Ok(kullanici);
        }

        // PUT: api/Kullanici/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKullanici([FromRoute] int id, [FromBody] Kullanici kullanici)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kullanici.Id)
            {
                return BadRequest();
            }

            _context.Entry(kullanici).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KullaniciExists(id))
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

        // POST: api/Kullanici
        [HttpPost]
        public async Task<IActionResult> PostKullanici([FromBody] Kullanici kullanici)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Kullanici.Add(kullanici);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKullanici", new { id = kullanici.Id }, kullanici);
        }

        // DELETE: api/Kullanici/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKullanici([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kullanici = await _context.Kullanici.FindAsync(id);
            if (kullanici == null)
            {
                return NotFound();
            }

            _context.Kullanici.Remove(kullanici);
            await _context.SaveChangesAsync();

            return Ok(kullanici);
        }

        private bool KullaniciExists(int id)
        {
            return _context.Kullanici.Any(e => e.Id == id);
        }
    }
}