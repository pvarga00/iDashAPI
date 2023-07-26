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
    [Route("api/TestCoverageData")]
    public class TestCoverageDataController : Controller
    {
        private readonly iDashDataContext _context;

        public TestCoverageDataController(iDashDataContext context)
        {
            _context = context;
        }

        // GET: api/TestCoverageData
        [HttpGet]
        public IEnumerable<TestCoverageData> GetTestCoverageData()
        {
            return _context.TestCoverageData;
        }

        // GET: api/TestCoverageData/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestCoverageData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var testCoverageData = await _context.TestCoverageData.SingleOrDefaultAsync(m => m.Id == id);

            if (testCoverageData == null)
            {
                return NotFound();
            }

            return Ok(testCoverageData);
        }

        // PUT: api/TestCoverageData/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestCoverageData([FromRoute] int id, [FromBody] TestCoverageData testCoverageData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testCoverageData.Id)
            {
                return BadRequest();
            }

            _context.Entry(testCoverageData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestCoverageDataExists(id))
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

        // POST: api/TestCoverageData
        [HttpPost]
        public async Task<IActionResult> PostTestCoverageData([FromBody] TestCoverageData testCoverageData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TestCoverageData.Add(testCoverageData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestCoverageData", new { id = testCoverageData.Id }, testCoverageData);
        }

        // DELETE: api/TestCoverageData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestCoverageData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var testCoverageData = await _context.TestCoverageData.SingleOrDefaultAsync(m => m.Id == id);
            if (testCoverageData == null)
            {
                return NotFound();
            }

            _context.TestCoverageData.Remove(testCoverageData);
            await _context.SaveChangesAsync();

            return Ok(testCoverageData);
        }

        private bool TestCoverageDataExists(int id)
        {
            return _context.TestCoverageData.Any(e => e.Id == id);
        }
    }
}