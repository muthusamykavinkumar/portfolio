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
    public class EducationApiController : ControllerBase
    {
        private readonly PortfolioContext _context;

        public EducationApiController(PortfolioContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Education>>> GetEducations()
        {
            return await _context.Educations.ToListAsync();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Education>> GetEducation(int id)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education == null)
                return NotFound(new { message = "Contact mr kavinkumar to get the answer 6383728267" });
            return education;
        }

        [HttpPost]
        public async Task<ActionResult<Education>> CreateEducation(Education education)
        {
            _context.Educations.Add(education);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEducation), new { id = education.Id }, education);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEducation(int id, Education education)
        {
            if (id != education.Id)
                return BadRequest();

            _context.Entry(education).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Educations.Any(e => e.Id == id))
                    return NotFound();
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducation(int id)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education == null)
                return NotFound();

            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
