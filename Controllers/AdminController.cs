using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;
using kavinkumar.dev.Models;
using kavinkumar.dev.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace kavinkumar.dev.Controllers
{
    public class AdminController : Controller
    {
        private readonly PortfolioContext _context;

        public AdminController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Username == model.Username && a.IsActive);
                
                if (admin != null && BCrypt.Net.BCrypt.Verify(model.Password, admin.PasswordHash))
                {
                    admin.LastLogin = DateTime.Now;
                    await _context.SaveChangesAsync();

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, admin.Username),
                        new Claim(ClaimTypes.Email, admin.Email),
                        new Claim(ClaimTypes.Role, "Admin")
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties();

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme, 
                        new ClaimsPrincipal(claimsIdentity), 
                        authProperties);

                    return RedirectToAction("Dashboard");
                }
                ModelState.AddModelError("", "Invalid credentials");
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            var model = new DashboardViewModel
            {
                Messages = await _context.ContactMessages.OrderByDescending(m => m.CreatedAt).ToListAsync(),
                Educations = await _context.Educations.ToListAsync(),
                Certificates = await _context.Certificates.ToListAsync(),
                Projects = await _context.Projects.ToListAsync(),
                Skills = await _context.Skills.ToListAsync(),
                Experiences = await _context.Experiences.ToListAsync(),
                Testimonials = await _context.Testimonials.ToListAsync()
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteMessage(int id)
        {
             var msg = await _context.ContactMessages.FindAsync(id);
             if (msg != null)
             {
                 _context.ContactMessages.Remove(msg);
                 await _context.SaveChangesAsync();
             }
             return RedirectToAction("Dashboard");
        }
    }
}
