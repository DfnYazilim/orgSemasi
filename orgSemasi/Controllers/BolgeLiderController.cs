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
    public class BolgeLiderController : ControllerBase
    {
        private readonly MainDbContext _context;

        public BolgeLiderController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/BolgeLider
        [HttpGet]
        public IEnumerable<BolgeLider> GetBolgeLider()
        {
            return _context.BolgeLider.Include(p=>p.Bolge.Organizasyon.Sirket).Include(p=>p.Kullanici);
        }

        // GET: api/BolgeLider/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBolgeLider([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bolgeLider = await _context.BolgeLider.FindAsync(id);

            if (bolgeLider == null)
            {
                return NotFound();
            }

            return Ok(bolgeLider);
        }

        // PUT: api/BolgeLider/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBolgeLider([FromRoute] int id, [FromBody] BolgeLider bolgeLider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bolgeLider.Id)
            {
                return BadRequest();
            }

            _context.Entry(bolgeLider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BolgeLiderExists(id))
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

        // POST: api/BolgeLider
        [HttpPost]
        public async Task<IActionResult> PostBolgeLider([FromBody] BolgeLider bolgeLider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BolgeLider.Add(bolgeLider);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBolgeLider", new { id = bolgeLider.Id }, bolgeLider);
        }

        // DELETE: api/BolgeLider/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBolgeLider([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bolgeLider = await _context.BolgeLider.FindAsync(id);
            if (bolgeLider == null)
            {
                return NotFound();
            }

            _context.BolgeLider.Remove(bolgeLider);
            await _context.SaveChangesAsync();

            return Ok(bolgeLider);
        }

        private bool BolgeLiderExists(int id)
        {
            return _context.BolgeLider.Any(e => e.Id == id);
        }
    }
}