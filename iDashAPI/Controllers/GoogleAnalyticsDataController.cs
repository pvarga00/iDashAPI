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
    [Route("api/GoogleAnalyticsData")]
    public class GoogleAnalyticsDataController : Controller
    {
        private readonly iDashDataContext _context;

        public GoogleAnalyticsDataController(iDashDataContext context)
        {
            _context = context;
        }

        // GET: api/GoogleAnalyticsData
        [HttpGet]
        public IEnumerable<GoogleAnalyticsData> GetGoogleAnalyticsData()
        {
            return _context.GoogleAnalyticsData;
        }

        // GET: api/GoogleAnalyticsData/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGoogleAnalyticsData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var googleAnalyticsData = await _context.GoogleAnalyticsData.SingleOrDefaultAsync(m => m.Id == id);

            if (googleAnalyticsData == null)
            {
                return NotFound();
            }

            return Ok(googleAnalyticsData);
        }

        // PUT: api/GoogleAnalyticsData/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoogleAnalyticsData([FromRoute] int id, [FromBody] GoogleAnalyticsData googleAnalyticsData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != googleAnalyticsData.Id)
            {
                return BadRequest();
            }

            _context.Entry(googleAnalyticsData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoogleAnalyticsDataExists(id))
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

        // POST: api/GoogleAnalyticsData
        [HttpPost]
        public async Task<IActionResult> PostGoogleAnalyticsData([FromBody] GoogleAnalyticsData googleAnalyticsData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GoogleAnalyticsData.Add(googleAnalyticsData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGoogleAnalyticsData", new { id = googleAnalyticsData.Id }, googleAnalyticsData);
        }

        // DELETE: api/GoogleAnalyticsData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoogleAnalyticsData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var googleAnalyticsData = await _context.GoogleAnalyticsData.SingleOrDefaultAsync(m => m.Id == id);
            if (googleAnalyticsData == null)
            {
                return NotFound();
            }

            _context.GoogleAnalyticsData.Remove(googleAnalyticsData);
            await _context.SaveChangesAsync();

            return Ok(googleAnalyticsData);
        }

        private bool GoogleAnalyticsDataExists(int id)
        {
            return _context.GoogleAnalyticsData.Any(e => e.Id == id);
        }
    }
}