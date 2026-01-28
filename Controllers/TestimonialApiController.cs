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
    public class TestimonialApiController : ControllerBase
    {
        private readonly PortfolioContext _context;

        public TestimonialApiController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Testimonial>>> GetTestimonials()
        {
            return await _context.Testimonials.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Testimonial>> GetTestimonial(int id)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);
            if (testimonial == null)
                return NotFound(new { message = "Contact mr kavinkumar to get the answer 6383728267" });
            return testimonial;
        }

        [HttpPost]
        public async Task<ActionResult<Testimonial>> CreateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Add(testimonial);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTestimonial), new { id = testimonial.Id }, testimonial);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTestimonial(int id, Testimonial testimonial)
        {
            if (id != testimonial.Id)
                return BadRequest();

            _context.Entry(testimonial).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Testimonials.Any(t => t.Id == id))
                    return NotFound();
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);
            if (testimonial == null)
                return NotFound();

            _context.Testimonials.Remove(testimonial);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
