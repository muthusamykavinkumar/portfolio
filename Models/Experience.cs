using System;
using System.ComponentModel.DataAnnotations;

namespace kavinkumar.dev.Models
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        public string Position { get; set; } = string.Empty;

        [Required]
        public string Duration { get; set; } = string.Empty;

        public string CompanyUrl { get; set; } = string.Empty;

        public string CompanyType { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
