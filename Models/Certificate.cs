using System;
using System.ComponentModel.DataAnnotations;

namespace kavinkumar.dev.Models
{
    public class Certificate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string IssuedBy { get; set; } = string.Empty;

        public DateTime IssueDate { get; set; }

        public string CertificateUrl { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
