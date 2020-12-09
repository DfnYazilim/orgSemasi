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
    public class OfisLiderController : ControllerBase
    {
        private readonly MainDbContext _context;

        public OfisLiderController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/OfisLider
        [HttpGet]
        public IEnumerable<OfisLider> GetOfisLider()
        {
            return _context.OfisLider.Include(p=>p.Ofis.Bolge.Organizasyon.Sirket).Include(p=>p.Kullanici);
        }

        // GET: api/OfisLider/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOfisLider([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ofisLider = await _context.OfisLider.FindAsync(id);

            if (ofisLider == null)
            {
                return NotFound();
            }

            return Ok(ofisLider);
        }

        // PUT: api/OfisLider/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfisLider([FromRoute] int id, [FromBody] OfisLider ofisLider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ofisLider.Id)
            {
                return BadRequest();
            }

            _context.Entry(ofisLider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfisLiderExists(id))
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

        // POST: api/OfisLider
        [HttpPost]
        public async Task<IActionResult> PostOfisLider([FromBody] OfisLider ofisLider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OfisLider.Add(ofisLider);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfisLider", new { id = ofisLider.Id }, ofisLider);
        }

        // DELETE: api/OfisLider/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfisLider([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ofisLider = await _context.OfisLider.FindAsync(id);
            if (ofisLider == null)
            {
                return NotFound();
            }

            _context.OfisLider.Remove(ofisLider);
            await _context.SaveChangesAsync();

            return Ok(ofisLider);
        }

        private bool OfisLiderExists(int id)
        {
            return _context.OfisLider.Any(e => e.Id == id);
        }
    }
}