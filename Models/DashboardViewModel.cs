using kavinkumar.dev.Models;
using System.Collections.Generic;

namespace kavinkumar.dev.Models
{
    public class DashboardViewModel
    {
        public List<ContactMessage> Messages { get; set; } = new();
        public List<Education> Educations { get; set; } = new();
        public List<Certificate> Certificates { get; set; } = new();
        public List<Project> Projects { get; set; } = new();
        public List<Skill> Skills { get; set; } = new();
        public List<Experience> Experiences { get; set; } = new();
        public List<Testimonial> Testimonials { get; set; } = new();
    }
}
