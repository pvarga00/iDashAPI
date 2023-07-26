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
    [Route("api/AppDynamicsData")]
    public class AppDynamicsDataController : Controller
    {
        private readonly iDashDataContext _context;

        public AppDynamicsDataController(iDashDataContext context)
        {
            _context = context;
        }

        // GET: api/AppDynamicsData
        [HttpGet]
        public IEnumerable<AppDynamicsData> GetAppDynamicsData()
        {
            return _context.AppDynamicsData;
        }

        // GET: api/AppDynamicsData/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppDynamicsData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appDynamicsData = await _context.AppDynamicsData.SingleOrDefaultAsync(m => m.Id == id);

            if (appDynamicsData == null)
            {
                return NotFound();
            }

            return Ok(appDynamicsData);
        }

        // PUT: api/AppDynamicsData/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppDynamicsData([FromRoute] int id, [FromBody] AppDynamicsData appDynamicsData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appDynamicsData.Id)
            {
                return BadRequest();
            }

            _context.Entry(appDynamicsData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppDynamicsDataExists(id))
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

        // POST: api/AppDynamicsData
        [HttpPost]
        public async Task<IActionResult> PostAppDynamicsData([FromBody] AppDynamicsData appDynamicsData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AppDynamicsData.Add(appDynamicsData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppDynamicsData", new { id = appDynamicsData.Id }, appDynamicsData);
        }

        // DELETE: api/AppDynamicsData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppDynamicsData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appDynamicsData = await _context.AppDynamicsData.SingleOrDefaultAsync(m => m.Id == id);
            if (appDynamicsData == null)
            {
                return NotFound();
            }

            _context.AppDynamicsData.Remove(appDynamicsData);
            await _context.SaveChangesAsync();

            return Ok(appDynamicsData);
        }

        private bool AppDynamicsDataExists(int id)
        {
            return _context.AppDynamicsData.Any(e => e.Id == id);
        }
    }
}