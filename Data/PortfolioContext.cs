using Microsoft.EntityFrameworkCore;
using kavinkumar.dev.Models;

namespace kavinkumar.dev.Data
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
        {
        }

        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    Username = "Kavin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Kavin@2003"),
                    Email = "cecskavinkumarm24@gmail.com",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    LastLogin = DateTime.Now
                }
            );

            // Seed Education Data
            modelBuilder.Entity<Education>().HasData(
                new Education
                {
                    Id = 1,
                    InstitutionName = "K.S.R Of Engineering(Autonomous)",
                    Degree = "B.E",
                    FieldOfStudy = "Computer Science and Engineering",
                    GraduationYear = 2024,
                    CGPA = 7.2m,
                    Location = "Tiruchengode",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Education
                {
                    Id = 2,
                    InstitutionName = "Mangalam Higher Secondary School",
                    Degree = "HSLC",
                    FieldOfStudy = "Computer Science and Maths",
                    GraduationYear = 2020,
                    CGPA = 60.6m,
                    Location = "Anthiyur",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Education
                {
                    Id = 3,
                    InstitutionName = "Mangalam Higher Secondary School",
                    Degree = "SSLC",
                    FieldOfStudy = "General",
                    GraduationYear = 2018,
                    CGPA = 72m,
                    Location = "Anthiyur",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            // Seed Project Data
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Title = "Chess Game",
                    Description = "Designed and developed a feature-rich web-based chess game demonstrating my skills in web development, user interface design, and strategic implementation.",
                    ImageUrl = "chess.jpg",
                    ProjectUrl = "https://kavinkumarmuthusamy.github.io/chess/",
                    GithubUrl = "https://kavinkumarmuthusamy.github.io/chess/",
                    Technologies = "HTML,CSS,JavaScript",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Project
                {
                    Id = 2,
                    Title = "Flames",
                    Description = "Implemented the FLAMES relationship calculator as a web application, showcasing my web development capabilities and creative approach in creating interactive tools.",
                    ImageUrl = "flames.jpg",
                    ProjectUrl = "https://kavinkumarmuthusamy.github.io/flames/",
                    GithubUrl = "https://kavinkumarmuthusamy.github.io/flames/",
                    Technologies = "HTML,CSS,JavaScript",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Project
                {
                    Id = 3,
                    Title = "Interview Feedback Form",
                    Description = "Designed an intuitive and comprehensive interview feedback form web application, demonstrating my web development proficiency in creating user-friendly interfaces for data collection and analysis.",
                    ImageUrl = "feedback.png",
                    ProjectUrl = "https://kavinkumarmuthusamy.github.io/feedback/",
                    GithubUrl = "https://kavinkumarmuthusamy.github.io/feedback/",
                    Technologies = "HTML,CSS,JavaScript",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Project
                {
                    Id = 4,
                    Title = "Stone Paper Scissor",
                    Description = "Implemented the classic 'Stone Paper Scissors' game as a web application, highlighting my web development skills and providing a nostalgic and interactive gaming experience.",
                    ImageUrl = "sps.jpg",
                    ProjectUrl = "https://kavinkumarmuthusamy.github.io/stonpapersiscergame/",
                    GithubUrl = "https://kavinkumarmuthusamy.github.io/stonpapersiscergame/",
                    Technologies = "HTML,CSS,JavaScript",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Project
                {
                    Id = 5,
                    Title = "Tic Tac Toe",
                    Description = "Engineered a novel twist on the classic Tic Tac Toe game, introducing strategic layers and captivating visuals in a dynamic web application that highlights my innovation and web development prowess.",
                    ImageUrl = "xox.jpg",
                    ProjectUrl = "https://kavinkumarmuthusamy.github.io/xox/",
                    GithubUrl = "https://kavinkumarmuthusamy.github.io/xox/",
                    Technologies = "HTML,CSS,JavaScript",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Project
                {
                    Id = 6,
                    Title = "Java",
                    Description = "Developed a diverse collection of over 50 Java programs, each showcasing various programming concepts and problem-solving skills, contributing to a comprehensive portfolio of Java proficiency.",
                    ImageUrl = "java.jpg",
                    ProjectUrl = "https://github.com/kavinkumarmuthusamy/javaprograms",
                    GithubUrl = "https://github.com/kavinkumarmuthusamy/javaprograms",
                    Technologies = "Java",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Project
                {
                    Id = 7,
                    Title = "Brain",
                    Description = "Devised a 17-click brain puzzle game where strategically selecting central values triggers cascading number reductions, testing players' wit to achieve a target matrix configuration.",
                    ImageUrl = "brain.jpg",
                    ProjectUrl = "https://kavinkumarmuthusamy.github.io/brain/",
                    GithubUrl = "https://kavinkumarmuthusamy.github.io/brain/",
                    Technologies = "HTML,CSS,JavaScript",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Project
                {
                    Id = 8,
                    Title = "Login with sign in and static webpage",
                    Description = "Securely access your account with our user-friendly login page, prioritizing your privacy and offering a seamless experience.",
                    ImageUrl = "login.jpg",
                    ProjectUrl = "https://kavinkumarmuthusamy.github.io/login/",
                    GithubUrl = "https://kavinkumarmuthusamy.github.io/login/",
                    Technologies = "HTML,CSS,JavaScript",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            // Seed Certificate Data
            modelBuilder.Entity<Certificate>().HasData(
                new Certificate
                {
                    Id = 1,
                    Title = "Wipro TalentNext Java Full Stack",
                    IssuedBy = "WIPRO",
                    IssueDate = new DateTime(2023, 10, 6),
                    CertificateUrl = "https://drive.google.com/file/d/1Iso68eIRfs-p9MLUxLaWx-UoUgsuVPm1/view?usp=sharing",
                    Description = "Java Full Stack Development Certification",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Certificate
                {
                    Id = 2,
                    Title = "Ethical Hacking Master Class",
                    IssuedBy = "Udemy",
                    IssueDate = new DateTime(2023, 9, 4),
                    CertificateUrl = "https://drive.google.com/file/d/1NNEEituZlbqC2aj2SGDX_l3p3sDDMkhI/view?usp=sharing",
                    Description = "Ethical Hacking and Cybersecurity",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Certificate
                {
                    Id = 3,
                    Title = "Project Development Using JAVASCRIPT for Beginners - 2023",
                    IssuedBy = "Udemy",
                    IssueDate = new DateTime(2023, 6, 15),
                    CertificateUrl = "https://drive.google.com/file/d/1yQD5WE0N4_FvJQ2ZJjJ19b6X1gGzj38i/view?usp=sharing",
                    Description = "JavaScript Project Development",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Certificate
                {
                    Id = 4,
                    Title = "CSS, JavaScript And PHP Complete Course For Beginners",
                    IssuedBy = "Udemy",
                    IssueDate = new DateTime(2023, 6, 15),
                    CertificateUrl = "https://drive.google.com/file/d/1nPz-9Xgy4eOg4zz6cIxwe0PZJ_h1jUgm/view?usp=sharing",
                    Description = "CSS, JavaScript and PHP Web Development",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Certificate
                {
                    Id = 5,
                    Title = "Introduction to Cybersecurity",
                    IssuedBy = "Cisco",
                    IssueDate = new DateTime(2022, 9, 23),
                    CertificateUrl = "https://drive.google.com/file/d/1SmVsrwCqC6Y6NzX2ivhYySEmJcGvXK2p/view",
                    Description = "Introduction to Cybersecurity",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Certificate
                {
                    Id = 6,
                    Title = "Code Debugging and Code Hunter",
                    IssuedBy = "UDHAYAM'23",
                    IssueDate = new DateTime(2023, 3, 24),
                    CertificateUrl = "https://drive.google.com/file/d/1pRaptyQ_AKMYqAmt092ESGZxEDMBIaZg/view?usp=sharing",
                    Description = "Code Debugging Competition",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Certificate
                {
                    Id = 7,
                    Title = "Paper Presentation",
                    IssuedBy = "UDHAYAM'23 and ASTHRA 2022",
                    IssueDate = new DateTime(2023, 3, 24),
                    CertificateUrl = "https://drive.google.com/file/d/1YEz8I4r8ZWERFkWTWEoy2thAPubMQ7tC/view?usp=sharing",
                    Description = "Paper Presentation Award",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Certificate
                {
                    Id = 8,
                    Title = "Web Designing and Just A Minute and Quiz",
                    IssuedBy = "ASTHRA 2022",
                    IssueDate = new DateTime(2022, 5, 20),
                    CertificateUrl = "https://drive.google.com/file/d/1WkIKoLhCBUNJjlYtn5UJAOG8le7IJWUp/view?usp=sharing",
                    Description = "Web Designing and Competition",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Certificate
                {
                    Id = 9,
                    Title = "Mitsuya-Kai Hayashi-Ha shito-Ryu Karate -Do India",
                    IssuedBy = "Mitsuya-Kai Hayashi-Ha shito-Ryu Karate -Do India",
                    IssueDate = new DateTime(2014, 11, 9),
                    CertificateUrl = "https://drive.google.com/file/d/1QC7Y04F1zOKfPUjQx_58mZlXc0WPLtof/view?usp=sharing",
                    Description = "Karate Training Certificate",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Certificate
                {
                    Id = 10,
                    Title = "State Level HandWriting Competition",
                    IssuedBy = "Brainobrain & Chutti TV",
                    IssueDate = new DateTime(2014, 9, 5),
                    CertificateUrl = "https://drive.google.com/file/d/1w9kRanuYA4D1V5GzBjTI4yV7JjKcvZbg/view?usp=sharing",
                    Description = "State Level Competition",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Certificate
                {
                    Id = 11,
                    Title = "Karate",
                    IssuedBy = "Karate Federation",
                    IssueDate = new DateTime(2020, 1, 1),
                    CertificateUrl = "https://drive.google.com/file/d/1AHvDflP-KnBz6nXPaEWRLIXTpFRCfUNZ/view?usp=sharing",
                    Description = "Green Belt Achievement",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Certificate
                {
                    Id = 12,
                    Title = "Hindi- Prathamic",
                    IssuedBy = "Hindi Board",
                    IssueDate = new DateTime(2016, 5, 25),
                    CertificateUrl = "https://drive.google.com/file/d/181wqeZKy2ownZaPD6pa_xu9uwIoXWWP3/view?usp=sharing",
                    Description = "Hindi Language Certificate",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Certificate
                {
                    Id = 13,
                    Title = "Schooling Certificate",
                    IssuedBy = "School",
                    IssueDate = new DateTime(2018, 1, 1),
                    CertificateUrl = "https://drive.google.com/file/d/1M8ieePIcTfVIaYu0CEml_0sIHZeEEB48/view?usp=sharing",
                    Description = "Various Competitions during Schooling",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            // Seed Skills Data
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "JAVA", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Skill { Id = 2, Name = "C#", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Skill { Id = 3, Name = "JAVASCRIPT", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Skill { Id = 4, Name = "HTML", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Skill { Id = 5, Name = "CSS", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Skill { Id = 6, Name = "BOOTSTRAP", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            );

            // Seed Experience Data
            modelBuilder.Entity<Experience>().HasData(
                new Experience
                {
                    Id = 1,
                    CompanyName = "Sakthi Infra Tex",
                    Position = "Software Developer",
                    Duration = "1.5 years",
                    CompanyUrl = "https://sakthiinfra.com/",
                    CompanyType = "Product Based Company",
                    Description = "Worked as a Software Developer at Sakthi Infra Tex, a product-based company.",
                    StartDate = new DateTime(2022, 8, 1),
                    EndDate = new DateTime(2024, 1, 31),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );
        }
    }
}
