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
    public class SirketLiderController : ControllerBase
    {
        private readonly MainDbContext _context;

        public SirketLiderController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/SirketLider
        [HttpGet]
        public IEnumerable<SirketLider> GetSirketLider()
        {
            return _context.SirketLider.Include(p=>p.Sirket).Include(p=>p.Kullanici);
        }

        // GET: api/SirketLider/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSirketLider([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sirketLider = await _context.SirketLider.FindAsync(id);

            if (sirketLider == null)
            {
                return NotFound();
            }

            return Ok(sirketLider);
        }

        // PUT: api/SirketLider/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSirketLider([FromRoute] int id, [FromBody] SirketLider sirketLider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sirketLider.Id)
            {
                return BadRequest();
            }

            _context.Entry(sirketLider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SirketLiderExists(id))
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

        // POST: api/SirketLider
        [HttpPost]
        public async Task<IActionResult> PostSirketLider([FromBody] SirketLider sirketLider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SirketLider.Add(sirketLider);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSirketLider", new { id = sirketLider.Id }, sirketLider);
        }

        // DELETE: api/SirketLider/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSirketLider([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sirketLider = await _context.SirketLider.FindAsync(id);
            if (sirketLider == null)
            {
                return NotFound();
            }

            _context.SirketLider.Remove(sirketLider);
            await _context.SaveChangesAsync();

            return Ok(sirketLider);
        }

        private bool SirketLiderExists(int id)
        {
            return _context.SirketLider.Any(e => e.Id == id);
        }
    }
}