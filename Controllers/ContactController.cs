using Microsoft.AspNetCore.Mvc;
using kavinkumar.dev.Data;
using kavinkumar.dev.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace kavinkumar.dev.Controllers
{
    public class ContactController : Controller
    {
        private readonly PortfolioContext _context;

        public ContactController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpPost("Contact/Send")]
        public async Task<IActionResult> Send([FromBody] ContactMessage message)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Log ModelState errors for debugging
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    var errorMessage = string.Join("; ", errors.Select(e => e.ErrorMessage));
                    System.Diagnostics.Debug.WriteLine($"ModelState Errors: {errorMessage}");
                    System.Diagnostics.Debug.WriteLine($"Name: {message.Name}, Email: {message.Email}, Message: {message.Message}");
                    
                    return BadRequest(new { error = "Please fill in all required fields correctly." });
                }

                message.CreatedAt = DateTime.Now;
                _context.ContactMessages.Add(message);
                await _context.SaveChangesAsync();

                return Ok(new { success = true, message = "Your message has been sent successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while sending your message. Please try again later." });
            }
        }

        [HttpPost("api/Contact")]
        public async Task<IActionResult> Submit([FromForm] ContactMessage message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            message.CreatedAt = DateTime.Now;
            _context.ContactMessages.Add(message);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Message saved successfully!" });
        }

        [HttpGet("api/Contact/ask-ai")]
        public IActionResult AskAI([FromQuery] string query)
        {
            var q = query?.ToLower() ?? "";
            string response = "I'm trained on Kavin's professional portfolio. Ask me about his Experience, Skills, Education, or Projects!";

            // 1. Experience & Role
            if (q.Contains("experience") || q.Contains("work") || q.Contains("job") || q.Contains("company") || q.Contains("role"))
            {
                response = "Kavin has **2 years of full-stack experience**.\n\n" +
                           "**Current Role:** Software Developer at **Sakthi Infra Tex Pvt Ltd** (June 2024 - Present).\n" +
                           "**Key Responsibilities:**\n" +
                           "- Architecting full-stack web apps using **ASP.NET Core MVC** and **Clean Architecture**.\n" +
                           "- Managing complex **Oracle** and **PostgreSQL** database schemas.\n" +
                           "- Automating job tracking systems to improve operational efficiency.";
            }
            // 2. Skills & Tech Stack
            else if (q.Contains("skill") || q.Contains("tech") || q.Contains("stack") || q.Contains("language"))
            {
                response = "**Technical Expertise:**\n" +
                           "- **Frameworks:** ASP.NET Core MVC, Clean Architecture.\n" +
                           "- **Languages:** C#, Java, JavaScript, HTML5, CSS3.\n" +
                           "- **Databases:** Oracle, PostgreSQL, SQL Server.\n" +
                           "- **Tools:** GitHub, VS Code, Salesforce Trailblazer.";
            }
            // 3. Education
            else if (q.Contains("education") || q.Contains("college") || q.Contains("degree") || q.Contains("study"))
            {
                response = "**Education History:**\n" +
                           "- **B.E. Computer Science:** K.S.R College of Engineering (2020-2024) - **CGPA: 7.09**.\n" +
                           "- **HSC (12th):** Mangalam Higher Secondary School (2020) - **60.6%**.\n" +
                           "- **SSLC (10th):** Mangalam Matric Higher Secondary School (2018) - **72%**.";
            }
            // 4. Certifications
            else if (q.Contains("certificate") || q.Contains("certif"))
            {
                response = "**Certifications:**\n" +
                           "- **Java Full Stack:** Wipro TalentNext.\n" +
                           "- **Data Science (Gold):** NASSCOM.\n" +
                           "- **JavaScript for Beginners:** Udemy.\n" +
                           "- **Salesforce Trailblazer:** Salesforce.";
            }
            // 5. Contact
            else if (q.Contains("contact") || q.Contains("email") || q.Contains("phone") || q.Contains("reach"))
            {
                response = "You can contact Kavin via:\n" +
                           "- **Email:** cecskavinkumarm24@gmail.com\n" +
                           "- **Phone:** +91 63837 28267\n" +
                           "- **LinkedIn:** linkedin.com/in/kavinkumarm-dev";
            }
            // 6. Projects
            else if (q.Contains("project"))
            {
                response = "Kavin has built several web applications:\n" +
                           "- **Chess Game:** Web-based logic engine.\n" +
                           "- **Feedback System:** Interview data collection tool.\n" +
                           "- **Relationship Calculator:** Interactive logic app.";
            }
            // Greeting / Default
            else if (q.Contains("hello") || q.Contains("hi") || q.Contains("hey"))
            {
                response = "Hello! I am Kavin's AI Assistant. I know everything about his professional background. Try asking 'What is his experience?' or 'List his skills'.";
            }
            else 
            {
                response = "I don't have that specific information right now. Please contact Mr. Kavin Kumar to get the answer: +91 63837 28267";
            }

            return Ok(new { answer = response });
        }
    }
}
