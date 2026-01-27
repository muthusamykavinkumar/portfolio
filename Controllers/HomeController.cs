using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kavinkumar.dev.Models;
using kavinkumar.dev.Data;

namespace kavinkumar.dev.Controllers;

public class HomeController : Controller
{
    private readonly PortfolioContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(PortfolioContext context, ILogger<HomeController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var model = new DashboardViewModel
        {
            Educations = await _context.Educations.ToListAsync(),
            Projects = await _context.Projects.ToListAsync(),
            Certificates = await _context.Certificates.ToListAsync(),
            Skills = await _context.Skills.ToListAsync(),
            Testimonials = await _context.Testimonials.Where(t => t.IsApproved).ToListAsync(),
            Messages = new List<ContactMessage>() // Don't load messages on public page
        };

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
