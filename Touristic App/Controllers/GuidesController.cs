using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Touristic_App.Models;

namespace Touristic_App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GuidesController : ControllerBase
    {
        private readonly UserContext _context;

        public GuidesController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Guides
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetGuides()
        {
          if (_context.Guides == null)
          {
              return NotFound();
          }
            return await _context.Guides.ToListAsync();
        }

        // GET: api/Guides/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetGuide(long id)
        {
          if (_context.Guides == null)
          {
              return NotFound();
          }
            var guide = await _context.Guides.FindAsync(id);

            if (guide == null)
            {
                return NotFound();
            }

            return guide;
        }

        // PUT: api/Guides/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuide(long id, User guide)
        {
            if (id != guide.Id)
            {
                return BadRequest();
            }

            _context.Entry(guide).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuideExists(id))
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

        // POST: api/Guides
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostGuide(User guide)
        {
          if (_context.Guides == null)
          {
              return Problem("Entity set 'GuideContext.Guides'  is null.");
          }
            _context.Guides.Add(guide);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetGuide", new { id = guide.Id }, guide);
            return CreatedAtAction(nameof(GetGuide), new {id =  guide.Id}, guide);
        }

        // DELETE: api/Guides/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuide(long id)
        {
            if (_context.Guides == null)
            {
                return NotFound();
            }
            var guide = await _context.Guides.FindAsync(id);
            if (guide == null)
            {
                return NotFound();
            }

            _context.Guides.Remove(guide);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GuideExists(long id)
        {
            return (_context.Guides?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
