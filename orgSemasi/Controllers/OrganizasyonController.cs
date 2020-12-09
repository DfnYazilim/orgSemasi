using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using orgSemasi.Helpers;
using orgSemasi.Models;
using qAskBackEnd.Helper;

namespace orgSemasi.Controllers
{
    [Route("api/[controller]")]
    public class OrganizasyonController : ControllerBase
    {
        private readonly MainDbContext _context;

        public OrganizasyonController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/Organizasyon
        [HttpGet]
        public async Task<IActionResult> GetOrganizasyon(DataSourceLoadOptions arama)
        {
            var veri =  _context.Organizasyon.Include(p=>p.Sirket);
            arama.PrimaryKey = new[] {"id"};
            arama.PaginateViaPrimaryKey = true;
            return Ok(await DataSourceLoader.LoadAsync(veri,arama));
        }

        // GET: api/Organizasyon/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganizasyon([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organizasyon = await _context.Organizasyon.FindAsync(id);

            if (organizasyon == null)
            {
                return NotFound();
            }

            return Ok(organizasyon);
        }

        // PUT: api/Organizasyon/5
        [HttpPut]
        public async Task<IActionResult> Guncelle(int key, string values)
        {
            var obje = await _context.Organizasyon.Where(p => p.Id == key).FirstOrDefaultAsync();
            if (obje == null)
            {
                return StatusCode(409, "Organizasyon bulunamadı");
            }
            JsonConvert.PopulateObject(values,obje);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(obje).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // POST: api/Organizasyon
        [HttpPost]
        public async Task<IActionResult> PostOrganizasyon(string values)
        {
            var obje = new Organizasyon();
            JsonConvert.PopulateObject(values,obje);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Organizasyon.AddAsync(obje);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/Organizasyon/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizasyon([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organizasyon = await _context.Organizasyon.FindAsync(id);
            if (organizasyon == null)
            {
                return NotFound();
            }

            _context.Organizasyon.Remove(organizasyon);
            await _context.SaveChangesAsync();

            return Ok(organizasyon);
        }

        private bool OrganizasyonExists(int id)
        {
            return _context.Organizasyon.Any(e => e.Id == id);
        }
    }
}