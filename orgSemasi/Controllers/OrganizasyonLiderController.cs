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
    public class OrganizasyonLiderController : ControllerBase
    {
        private readonly MainDbContext _context;

        public OrganizasyonLiderController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/OrganizasyonLider
        [HttpGet]
        public IEnumerable<OrganizasyonLider> GetOrganizasyonLider()
        {
            return _context.OrganizasyonLider.Include(p=>p.Organizasyon.Sirket).Include(p=>p.Kullanici);
        }

        // GET: api/OrganizasyonLider/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganizasyonLider([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organizasyonLider = await _context.OrganizasyonLider.FindAsync(id);

            if (organizasyonLider == null)
            {
                return NotFound();
            }

            return Ok(organizasyonLider);
        }

        // PUT: api/OrganizasyonLider/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizasyonLider([FromRoute] int id, [FromBody] OrganizasyonLider organizasyonLider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != organizasyonLider.Id)
            {
                return BadRequest();
            }

            _context.Entry(organizasyonLider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizasyonLiderExists(id))
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

        // POST: api/OrganizasyonLider
        [HttpPost]
        public async Task<IActionResult> PostOrganizasyonLider([FromBody] OrganizasyonLider organizasyonLider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OrganizasyonLider.Add(organizasyonLider);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganizasyonLider", new { id = organizasyonLider.Id }, organizasyonLider);
        }

        // DELETE: api/OrganizasyonLider/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizasyonLider([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organizasyonLider = await _context.OrganizasyonLider.FindAsync(id);
            if (organizasyonLider == null)
            {
                return NotFound();
            }

            _context.OrganizasyonLider.Remove(organizasyonLider);
            await _context.SaveChangesAsync();

            return Ok(organizasyonLider);
        }

        private bool OrganizasyonLiderExists(int id)
        {
            return _context.OrganizasyonLider.Any(e => e.Id == id);
        }
    }
}