using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kavinkumar.dev.Data;
using kavinkumar.dev.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kavinkumar.dev.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ExperienceApiController : ControllerBase
    {
        private readonly PortfolioContext _context;

        public ExperienceApiController(PortfolioContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Experience>>> GetExperiences()
        {
            return await _context.Experiences.ToListAsync();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Experience>> GetExperience(int id)
        {
            var experience = await _context.Experiences.FindAsync(id);
            if (experience == null)
                return NotFound(new { message = "Experience not found" });
            return experience;
        }

        [HttpPost]
        public async Task<ActionResult<Experience>> CreateExperience(Experience experience)
        {
            _context.Experiences.Add(experience);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetExperience), new { id = experience.Id }, experience);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExperience(int id, Experience experience)
        {
            if (id != experience.Id)
                return BadRequest();

            _context.Entry(experience).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienceExists(id))
                    return NotFound();
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperience(int id)
        {
            var experience = await _context.Experiences.FindAsync(id);
            if (experience == null)
                return NotFound();

            _context.Experiences.Remove(experience);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ExperienceExists(int id)
        {
            return _context.Experiences.Any(e => e.Id == id);
        }
    }
}
