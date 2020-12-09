using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using orgSemasi.Helpers;
using orgSemasi.Models;
using qAskBackEnd.Helper;

namespace orgSemasi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SirketController : ControllerBase
    {
        private readonly MainDbContext _context;

        public SirketController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/Sirket
        [HttpGet]
        public async Task<IActionResult> GetSirket(DataSourceLoadOptions arama)
        {
            var veri =  _context.Sirket;
            arama.PrimaryKey = new[] {"id"};
            arama.PaginateViaPrimaryKey = true;
            return Ok(await DataSourceLoader.LoadAsync(veri,arama));
        }

        // GET: api/Sirket/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSirket([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sirket = await _context.Sirket.FindAsync(id);

            if (sirket == null)
            {
                return NotFound();
            }

            return Ok(sirket);
        }

        // PUT: api/Sirket/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSirket([FromRoute] int id, [FromBody] Sirket sirket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sirket.Id)
            {
                return BadRequest();
            }

            _context.Entry(sirket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SirketExists(id))
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

        // POST: api/Sirket
        [HttpPost]
        public async Task<IActionResult> PostSirket([FromBody] Sirket sirket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sirket.Add(sirket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSirket", new { id = sirket.Id }, sirket);
        }

        // DELETE: api/Sirket/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSirket([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sirket = await _context.Sirket.FindAsync(id);
            if (sirket == null)
            {
                return NotFound();
            }

            _context.Sirket.Remove(sirket);
            await _context.SaveChangesAsync();

            return Ok(sirket);
        }

        private bool SirketExists(int id)
        {
            return _context.Sirket.Any(e => e.Id == id);
        }
    }
}