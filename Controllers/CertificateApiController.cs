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
    public class CertificateApiController : ControllerBase
    {
        private readonly PortfolioContext _context;

        public CertificateApiController(PortfolioContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Certificate>>> GetCertificates()
        {
            return await _context.Certificates.ToListAsync();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Certificate>> GetCertificate(int id)
        {
            var certificate = await _context.Certificates.FindAsync(id);
            if (certificate == null)
                return NotFound(new { message = "Contact mr kavinkumar to get the answer 6383728267" });
            return certificate;
        }

        [HttpPost]
        public async Task<ActionResult<Certificate>> CreateCertificate(Certificate certificate)
        {
            _context.Certificates.Add(certificate);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCertificate), new { id = certificate.Id }, certificate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCertificate(int id, Certificate certificate)
        {
            if (id != certificate.Id)
                return BadRequest();

            _context.Entry(certificate).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Certificates.Any(c => c.Id == id))
                    return NotFound();
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificate(int id)
        {
            var certificate = await _context.Certificates.FindAsync(id);
            if (certificate == null)
                return NotFound();

            _context.Certificates.Remove(certificate);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
