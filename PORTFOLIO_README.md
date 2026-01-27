# Kavin Kumar's Dynamic Portfolio

## 📋 Overview

This is a modern, dynamic portfolio application built with **ASP.NET Core** and **SQLite**. It features:

- ✨ **Three Theme Options**: Light, Dark, and Color themes
- 📊 **Dynamic Admin Dashboard**: Manage education, projects, certificates, skills, and testimonials
- 🔐 **Secure Login**: Admin authentication with BCrypt password hashing
- 💾 **SQLite Database**: Store all portfolio data persistently
- 📱 **Responsive Design**: Works on desktop, tablet, and mobile devices
- 🎨 **Beautiful UI**: Modern glassmorphism design with smooth animations

---

## 🚀 Quick Start

### Prerequisites

- .NET 10.0 SDK or later
- Visual Studio Code or Visual Studio 2022
- SQLite (comes with .NET)

### Installation Steps

1. **Navigate to project directory**
   ```bash
   cd "d:\html and css\kavinkumar.dev"
   ```

2. **Install dependencies**
   ```bash
   dotnet restore
   ```

3. **Create the SQLite database**
   ```bash
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Open in browser**
   ```
   https://localhost:5001
   ```

---

## 🔐 Admin Login

- **URL**: `https://localhost:5001/Admin/Login`
- **Default Username**: `admin`
- **Default Password**: `admin123`

⚠️ **IMPORTANT**: Change the default password immediately in production!

### Updating Admin Credentials

Navigate to the admin dashboard and update:
- Username
- Password (will be hashed with BCrypt)
- Email

---

## 🎨 Theme System

### Available Themes

1. **Light Theme** (☀️)
   - Clean, professional appearance
   - Best for daytime viewing
   - White backgrounds with dark text

2. **Dark Theme** (🌙)
   - Easy on the eyes
   - Perfect for low-light environments
   - Dark backgrounds with light text

3. **Color Theme** (🎨)
   - Vibrant and energetic
   - Colorful accent colors
   - Unique brand identity

### How to Use

- Click **theme buttons** in the sidebar to select a theme
- Use **Toggle Theme button** to cycle through themes
- Keyboard shortcut: `Ctrl + Shift + T`
- Theme preference is saved in browser localStorage

---

## 📊 Admin Dashboard Features

### Message Management
- View all contact form submissions
- Delete messages
- Filter and search capabilities

### Education Management
- Add/Edit/Delete education records
- Track degree, institution, CGPA, and graduation year
- Chronological organization

### Projects Management
- Add/Edit/Delete project entries
- Include project URLs, GitHub links, and technologies used
- Add project descriptions and images

### Certificates Management
- Add/Edit/Delete certificates
- Link to certificate documents
- Track issuing organizations and dates

### Skills Management
- Add/Edit/Delete skills
- Set proficiency levels (0-100%)
- Visual proficiency bars

### Testimonials Management
- Add/Edit/Delete testimonials
- Approve/reject before displaying
- Track author information

---

## 📂 Database Schema

### Tables

#### Admin
```sql
Id (int, PK)
Username (string, unique)
PasswordHash (string)
Email (string)
IsActive (bool)
CreatedAt (datetime)
LastLogin (datetime)
```

#### Education
```sql
Id (int, PK)
InstitutionName (string)
Degree (string)
FieldOfStudy (string)
GraduationYear (int)
CGPA (decimal)
Location (string)
CreatedAt (datetime)
UpdatedAt (datetime)
```

#### Project
```sql
Id (int, PK)
Title (string)
Description (text)
ImageUrl (string)
ProjectUrl (string)
GithubUrl (string)
Technologies (string)
CreatedAt (datetime)
UpdatedAt (datetime)
```

#### Certificate
```sql
Id (int, PK)
Title (string)
IssuedBy (string)
IssueDate (datetime)
CertificateUrl (string)
Description (text)
CreatedAt (datetime)
UpdatedAt (datetime)
```

#### Skill
```sql
Id (int, PK)
Name (string)
Icon (string)
ProficiencyLevel (int)
CreatedAt (datetime)
UpdatedAt (datetime)
```

#### Testimonial
```sql
Id (int, PK)
Content (text)
AuthorName (string)
AuthorTitle (string)
IsApproved (bool)
CreatedAt (datetime)
```

#### ContactMessage
```sql
Id (int, PK)
Name (string)
Email (string)
Message (text)
CreatedAt (datetime)
```

---

## 🔌 API Endpoints

### Education API
- `GET /api/educationapi` - Get all educations
- `GET /api/educationapi/{id}` - Get specific education
- `POST /api/educationapi` - Create education
- `PUT /api/educationapi/{id}` - Update education
- `DELETE /api/educationapi/{id}` - Delete education

### Project API
- `GET /api/projectapi` - Get all projects
- `GET /api/projectapi/{id}` - Get specific project
- `POST /api/projectapi` - Create project
- `PUT /api/projectapi/{id}` - Update project
- `DELETE /api/projectapi/{id}` - Delete project

### Certificate API
- `GET /api/certificateapi` - Get all certificates
- `POST /api/certificateapi` - Create certificate
- `PUT /api/certificateapi/{id}` - Update certificate
- `DELETE /api/certificateapi/{id}` - Delete certificate

### Skill API
- `GET /api/skillapi` - Get all skills
- `POST /api/skillapi` - Create skill
- `PUT /api/skillapi/{id}` - Update skill
- `DELETE /api/skillapi/{id}` - Delete skill

### Testimonial API
- `GET /api/testimonialapi` - Get approved testimonials
- `POST /api/testimonialapi` - Create testimonial
- `PUT /api/testimonialapi/{id}` - Update testimonial
- `DELETE /api/testimonialapi/{id}` - Delete testimonial

---

## 🛡️ Security Features

- **Password Hashing**: BCrypt.Net-Core for secure password storage
- **Cookie Authentication**: ASP.NET Core cookie-based authentication
- **Authorization**: Admin pages require authentication
- **HTTPS**: Enforced in production
- **CSRF Protection**: Built into Razor forms

---

## 📦 Dependencies

```xml
<PackageReference Include="Microsoft.AspNetCore.Authentication.Cookies" Version="2.3.9" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="8.0.0" />
<PackageReference Include="BCrypt.Net-Core" Version="1.6.0" />
```

---

## 🎯 Usage Examples

### Adding a New Project via API

```bash
curl -X POST https://localhost:5001/api/projectapi \
  -H "Content-Type: application/json" \
  -d '{
    "title": "My New Project",
    "description": "An awesome web application",
    "technologies": "C#, React, SQL",
    "projectUrl": "https://myproject.com",
    "githubUrl": "https://github.com/user/project"
  }'
```

### Adding Education

```bash
curl -X POST https://localhost:5001/api/educationapi \
  -H "Content-Type: application/json" \
  -d '{
    "institutionName": "University Name",
    "degree": "B.Tech",
    "fieldOfStudy": "Computer Science",
    "graduationYear": 2024,
    "cgpa": 8.5,
    "location": "City, Country"
  }'
```

---

## 🚀 Deployment

### Publish for Production

```bash
dotnet publish -c Release -o ./publish
```

### Deploy to IIS

1. Install .NET Hosting Bundle
2. Create IIS site pointing to published folder
3. Configure app pool settings
4. Update connection string in appsettings.json

### Deploy to Azure

```bash
dotnet publish -c Release
az webapp deployment source config-zip -r "path/to/publish.zip" -n yourappname -g yourresourcegroup
```

---

## 📝 Error Messages

When information is not available, the system displays:

**"Contact mr kavinkumar to get the answer 6383728267"**

This message appears for:
- Missing data in database
- Unanswered questions
- Incomplete information

---

## 🎨 CSS Theme Variables

Each theme uses CSS custom properties (variables):

```css
:root {
  --primary: #667eea;
  --secondary: #764ba2;
  --bg-primary: #ffffff;
  --text-primary: #1a1a1a;
  --border-color: #e0e0e0;
  /* ... more variables */
}
```

Themes automatically switch all variables when changed.

---

## 📱 Responsive Breakpoints

- **Desktop**: 1200px and above
- **Tablet**: 768px to 1199px
- **Mobile**: Below 768px

---

## 🤝 Contributing

To add new features:

1. Create a new branch
2. Add database models if needed
3. Create corresponding API endpoints
4. Update admin dashboard
5. Add views for public portfolio
6. Test all theme changes

---

## 📞 Support

For issues or questions, contact:

**Email**: cecskavinkumarm24@gmail.com  
**Phone**: +91 6383728267  
**GitHub**: github.com/kavinkumarmuthusamy

---

## 📄 License

This project is personal and not publicly licensed.

---

## 🔄 Version History

### v1.0.0 (Current)
- Initial release
- Theme system implementation
- Admin dashboard with CRUD operations
- SQLite integration
- API endpoints for all entities
- Responsive design

---

## 🚨 Important Notes

1. **Database File**: `portfolio.db` will be created automatically in the project root
2. **Static Files**: Serve from `wwwroot` directory
3. **Images**: Place portfolio images in `wwwroot/images`
4. **Email Configuration**: Update Google Forms script URL in contact form if needed
5. **SSL Certificate**: Configure for HTTPS in production

---

**Last Updated**: January 2026  
**Maintained By**: Kavin Kumar M  
**Contact**: 6383728267
