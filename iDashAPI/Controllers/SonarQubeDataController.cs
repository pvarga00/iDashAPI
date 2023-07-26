using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iDashAPI.Models;

namespace iDashAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/SonarQubeData")]
    public class SonarQubeDataController : Controller
    {
        private readonly iDashDataContext _context;

        public SonarQubeDataController(iDashDataContext context)
        {
            _context = context;
        }

        // GET: api/SonarQubeData
        [HttpGet]
        public IEnumerable<SonarQubeData> GetSonarQubeData()
        {
            return _context.SonarQubeData;
        }

        // GET: api/SonarQubeData/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSonarQubeData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sonarQubeData = await _context.SonarQubeData.SingleOrDefaultAsync(m => m.Id == id);

            if (sonarQubeData == null)
            {
                return NotFound();
            }

            return Ok(sonarQubeData);
        }

        // PUT: api/SonarQubeData/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSonarQubeData([FromRoute] int id, [FromBody] SonarQubeData sonarQubeData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sonarQubeData.Id)
            {
                return BadRequest();
            }

            _context.Entry(sonarQubeData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SonarQubeDataExists(id))
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

        // POST: api/SonarQubeData
        [HttpPost]
        public async Task<IActionResult> PostSonarQubeData([FromBody] SonarQubeData sonarQubeData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SonarQubeData.Add(sonarQubeData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSonarQubeData", new { id = sonarQubeData.Id }, sonarQubeData);
        }

        // DELETE: api/SonarQubeData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSonarQubeData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sonarQubeData = await _context.SonarQubeData.SingleOrDefaultAsync(m => m.Id == id);
            if (sonarQubeData == null)
            {
                return NotFound();
            }

            _context.SonarQubeData.Remove(sonarQubeData);
            await _context.SaveChangesAsync();

            return Ok(sonarQubeData);
        }

        private bool SonarQubeDataExists(int id)
        {
            return _context.SonarQubeData.Any(e => e.Id == id);
        }
    }
}