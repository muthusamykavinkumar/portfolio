# ⚡ Developer Cheat Sheet

## 🚀 Quick Commands

```bash
# Start application
dotnet run

# Build only
dotnet build

# Clean and rebuild
dotnet clean && dotnet build

# Publish for production
dotnet publish -c Release -o ./publish

# Restore dependencies
dotnet restore

# Check version
dotnet --version
```

---

## 🔗 Quick URLs

```
https://localhost:5001              → Public portfolio
https://localhost:5001/Admin/Login  → Admin login
https://localhost:5001/Admin        → Admin dashboard (after login)
```

---

## 🔐 Default Credentials

```
Username: admin
Password: admin123

⚠️ CHANGE IN PRODUCTION!
```

---

## 🎨 Theme System

```javascript
// Switch theme programmatically
ThemeSwitcher.setTheme('light')    // Light theme
ThemeSwitcher.setTheme('dark')     // Dark theme
ThemeSwitcher.setTheme('color')    // Color theme

// Get current theme
ThemeSwitcher.getCurrentTheme()

// Toggle to next theme
ThemeSwitcher.toggleTheme()

// Listen for theme changes
document.addEventListener('themechanged', (e) => {
  console.log('Theme changed to:', e.detail.theme);
});
```

---

## 🔌 API Quick Reference

### Projects
```bash
# Get all
GET /api/projectapi

# Get one
GET /api/projectapi/1

# Create
POST /api/projectapi
{
  "title": "My Project",
  "description": "...",
  "technologies": "..."
}

# Update
PUT /api/projectapi/1
{
  "id": 1,
  "title": "Updated Title",
  ...
}

# Delete
DELETE /api/projectapi/1
```

### Education
```bash
# Get all
GET /api/educationapi

# Create
POST /api/educationapi
{
  "institutionName": "University",
  "degree": "B.Tech",
  "fieldOfStudy": "CSE",
  "graduationYear": 2024,
  "cgpa": 8.5,
  "location": "City"
}
```

### Certificates
```bash
# Get all
GET /api/certificateapi

# Create
POST /api/certificateapi
{
  "title": "Certificate Name",
  "issuedBy": "Organization",
  "issueDate": "2024-01-26"
}
```

### Skills
```bash
# Get all
GET /api/skillapi

# Create
POST /api/skillapi
{
  "name": "C#",
  "proficiencyLevel": 85
}
```

### Testimonials
```bash
# Get all (approved only)
GET /api/testimonialapi

# Create
POST /api/testimonialapi
{
  "content": "Great work!",
  "authorName": "John Doe",
  "authorTitle": "CEO",
  "isApproved": false
}
```

---

## 📂 Project Structure Quick View

```
Controllers/
  ├─ HomeController.cs
  ├─ AdminController.cs
  └─ *ApiController.cs (6 files)

Models/
  ├─ Education.cs
  ├─ Project.cs
  ├─ Certificate.cs
  ├─ Skill.cs
  ├─ Testimonial.cs
  ├─ Admin.cs
  └─ ContactMessage.cs

Data/
  └─ PortfolioContext.cs

Views/
  ├─ Admin/
  │  ├─ Login.cshtml
  │  └─ Dashboard.cshtml
  ├─ Home/
  │  └─ Index.cshtml
  └─ Shared/
     └─ _Layout.cshtml

wwwroot/
  ├─ css/
  │  ├─ themes.css
  │  └─ portfolio.css
  └─ js/
     ├─ theme-switcher.js
     └─ portfolio.js
```

---

## 🔑 Important Files

| File | Purpose | Edit? |
|------|---------|-------|
| Program.cs | App configuration | Yes (for production) |
| PortfolioContext.cs | Database context | Only for schema changes |
| themes.css | Theme colors | Yes (customize colors) |
| theme-switcher.js | Theme logic | Usually no |
| appsettings.json | App settings | Yes (connection string) |
| portfolio.db | Database | Backup regularly |

---

## 🎯 Authentication Flow

```
Login Request
    ↓
AdminController.Login()
    ↓
Verify BCrypt Hash
    ↓
Create Auth Cookie
    ↓
Redirect to Dashboard
```

---

## 💾 Database Query Examples

```csharp
// Get all educations
var educations = _context.Educations.ToList();

// Get specific education
var education = _context.Educations.Find(id);

// Add new
var edu = new Education { ... };
_context.Educations.Add(edu);
_context.SaveChanges();

// Update
education.Degree = "B.E";
_context.SaveChanges();

// Delete
_context.Educations.Remove(education);
_context.SaveChanges();
```

---

## 🌐 CSS Variables Available

```css
--primary           /* Main color */
--secondary         /* Accent color */
--bg-primary        /* Main background */
--bg-secondary      /* Secondary background */
--bg-tertiary       /* Tertiary background */
--text-primary      /* Main text */
--text-secondary    /* Secondary text */
--text-tertiary     /* Tertiary text */
--border-color      /* Border color */
--border-light      /* Light border */
--input-bg          /* Input background */
--input-border      /* Input border */
--input-focus       /* Input focus color */
--shadow-sm         /* Small shadow */
--shadow-md         /* Medium shadow */
--shadow-lg         /* Large shadow */
```

---

## 🔐 Keyboard Shortcuts

```
Ctrl + Shift + T    → Toggle theme
Ctrl + Shift + Del  → Clear browser cache
F12                 → Open DevTools
F5                  → Reload page
Ctrl + /            → Toggle sidebar
```

---

## ⚠️ Common Mistakes

```
❌ Forget to dotnet restore
✅ Run: dotnet restore

❌ Change password without hashing
✅ Use: BCrypt.Net.BCrypt.HashPassword()

❌ Delete portfolio.db without backup
✅ Copy to .backup first

❌ Commit portfolio.db to Git
✅ Add to .gitignore

❌ Use localhost:5000 for HTTPS
✅ Use localhost:5001
```

---

## 🛠️ Development Workflow

```
1. Code change
2. Save file (auto-reload in dev)
3. Test in browser
4. Check console for errors (F12)
5. Commit to git
6. Push to repository
```

---

## 🚀 Deployment Checklist

```
□ Change admin password
□ Update database connection
□ Test all features
□ Check mobile responsiveness
□ Enable HTTPS
□ Backup database
□ Set production environment
□ Test APIs with Postman
□ Monitor error logs
□ Setup automated backups
```

---

## 📊 HTTP Status Codes Used

```
200 OK              → Successful request
201 Created         → Resource created
204 No Content      → Successful delete
400 Bad Request     → Invalid input
404 Not Found       → Resource doesn't exist
500 Server Error    → Server error
```

---

## 🔍 Debugging Tips

```javascript
// Log current theme
console.log(ThemeSwitcher.getCurrentTheme());

// Log theme colors
console.log(ThemeSwitcher.getThemeColors());

// Force database recreation
// Delete portfolio.db then: dotnet run
```

---

## 📱 Responsive Breakpoints

```css
/* Mobile */
@media (max-width: 576px) { }

/* Tablet */
@media (min-width: 768px) { }

/* Desktop */
@media (min-width: 1024px) { }

/* Large Desktop */
@media (min-width: 1200px) { }
```

---

## 🧪 Testing with curl

```bash
# GET
curl https://localhost:5001/api/projectapi

# POST
curl -X POST https://localhost:5001/api/projectapi \
  -H "Content-Type: application/json" \
  -d '{"title":"Test"}'

# PUT
curl -X PUT https://localhost:5001/api/projectapi/1 \
  -H "Content-Type: application/json" \
  -d '{"id":1,"title":"Updated"}'

# DELETE
curl -X DELETE https://localhost:5001/api/projectapi/1
```

---

## 📋 Entity Relationships

```
Admin (1) ─────────────────────── (Many) ContactMessage

All other entities are independent:
- Education
- Project
- Certificate
- Skill
- Testimonial
```

---

## 🔧 Configuration Files

### appsettings.json
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=portfolio.db"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  }
}
```

### appsettings.Development.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug"
    }
  }
}
```

---

## 🎓 ASP.NET Core Concepts Used

```
Dependency Injection    → Constructor parameters
Entity Framework Core   → Database ORM
Razor Views            → HTML templating
Controllers            → Request handlers
Attributes             → [Authorize], [Route]
Models                 → Data classes
DbContext              → Database access
Middleware             → Request pipeline
```

---

## 📞 Quick Support

**Issue**: App won't start
```bash
dotnet clean && dotnet restore && dotnet run
```

**Issue**: Port in use
```bash
netstat -ano | findstr :5001
taskkill /PID <PID> /F
```

**Issue**: Database error
```bash
rm portfolio.db
dotnet run
```

---

## 🎯 Performance Tips

```
✅ Use async/await for DB calls
✅ Cache frequently accessed data
✅ Minimize CSS/JS in production
✅ Compress images
✅ Use CDN for static files
✅ Index database columns
```

---

## 📞 Contact & Support

📧 cecskavinkumarm24@gmail.com  
📱 +91 6383728267  
🐙 github.com/kavinkumarmuthusamy  
💼 linkedin.com/in/kavin-kumar-268620255

---

**Pro Tip**: Bookmark this page for quick reference! 📌

**Last Updated**: January 26, 2026
