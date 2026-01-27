# 🚀 Setup Guide - Dynamic Portfolio System

## Step 1: Initial Setup

### 1.1 Verify .NET Installation
```bash
dotnet --version
```

Should be .NET 10.0 or later.

### 1.2 Open Terminal in Project Directory
```bash
cd "d:\html and css\kavinkumar.dev"
```

### 1.3 Restore NuGet Packages
```bash
dotnet restore
```

This downloads all required dependencies.

---

## Step 2: Database Setup

### 2.1 Create SQLite Database
```bash
dotnet build
```

The database is automatically created on first run with the context.

### 2.2 Verify Database File
Check if `portfolio.db` exists in the project root directory.

---

## Step 3: Run the Application

### 3.1 Start the Server
```bash
dotnet run
```

Output should show:
```
Now listening on: https://localhost:5001
Now listening on: http://localhost:5000
```

### 3.2 Open in Browser
Navigate to: `https://localhost:5001`

---

## Step 4: Admin Login

### 4.1 Access Admin Portal
Go to: `https://localhost:5001/Admin/Login`

### 4.2 Default Credentials
- Username: `admin`
- Password: `admin123`

**✅ You should see the Admin Dashboard**

---

## Step 5: Add Your Portfolio Data

### 5.1 Add Education Records
1. Click **🎓 Education** tab
2. Click **+ Add Education**
3. Fill in institution details
4. Save to database

### 5.2 Add Projects
1. Click **💼 Projects** tab
2. Click **+ Add Project**
3. Enter project details
4. Save to database

### 5.3 Add Certificates
1. Click **🏆 Certificates** tab
2. Click **+ Add Certificate**
3. Enter certificate information
4. Save to database

### 5.4 Add Skills
1. Click **⚙️ Skills** tab
2. Click **+ Add Skill**
3. Set skill name and proficiency level
4. Save to database

### 5.5 Add Testimonials
1. Click **⭐ Testimonials** tab
2. Click **+ Add Testimonial**
3. Enter testimonial content
4. Save to database

---

## Step 6: Test Theme Switching

### 6.1 Light Theme
- Click **☀️ Light** button in sidebar
- Portfolio should display with light colors

### 6.2 Dark Theme
- Click **🌙 Dark** button in sidebar
- Portfolio should display with dark colors

### 6.3 Color Theme
- Click **🎨 Color** button in sidebar
- Portfolio should display with vibrant colors

### 6.4 Toggle Theme
- Click **Toggle Theme** button to cycle through themes
- Or use keyboard shortcut: `Ctrl + Shift + T`

---

## Step 7: Test Contact Form

### 7.1 Submit Message
1. Go to **Contact** section
2. Fill in name, email, message
3. Click **Send**
4. Message should appear in Admin Dashboard

### 7.2 View in Dashboard
1. Login to admin panel
2. Click **📧 Messages** tab
3. See all contact submissions

---

## Step 8: API Testing

### 8.1 Test Get All Projects
```bash
curl https://localhost:5001/api/projectapi
```

### 8.2 Test Add Project
```bash
curl -X POST https://localhost:5001/api/projectapi \
  -H "Content-Type: application/json" \
  -d '{
    "title": "Test Project",
    "description": "Testing API",
    "technologies": "C#, React",
    "projectUrl": "https://example.com",
    "githubUrl": "https://github.com/user/test"
  }'
```

---

## Step 9: Customization

### 9.1 Change Theme Colors
Edit `wwwroot/css/themes.css`:

```css
:root {
  --primary: #YOUR_COLOR;
  --secondary: #YOUR_COLOR;
  --accent: #YOUR_COLOR;
}
```

### 9.2 Update Admin Password
1. Login as admin
2. Database will store BCrypt hashed passwords
3. Update via Admin panel (implement in admin UI)

### 9.3 Customize Contact Message
Edit: `Views/Home/Index.cshtml`

Update Google Forms script URL:
```javascript
const scriptURL = 'YOUR_GOOGLE_FORMS_URL'
```

---

## Step 10: Deployment Preparation

### 10.1 Change Admin Credentials
⚠️ **CRITICAL FOR PRODUCTION**

Update in `Program.cs` the initial admin seeding:

```csharp
new Admin
{
    Username = "your_new_username",
    PasswordHash = BCrypt.Net.BCrypt.HashPassword("your_new_password"),
    Email = "your_email@example.com"
}
```

### 10.2 Configure HTTPS
In `Properties/launchSettings.json`:

Update `sslPort` and certificate settings

### 10.3 Update Connection String
In `appsettings.json`:

```json
"Data Source=portfolio.db"
```

For production, consider using full path or SQL Server.

---

## Troubleshooting

### Issue: Port Already in Use
**Solution**: Change port in `launchSettings.json`:
```json
"applicationUrl": "https://localhost:5002;http://localhost:5000"
```

### Issue: Database Lock Error
**Solution**: Close all connections and rebuild:
```bash
dotnet clean
dotnet build
```

### Issue: Theme Not Switching
**Solution**: Check browser console for JavaScript errors:
- Press `F12` to open Developer Tools
- Check Console tab for errors

### Issue: Admin Login Fails
**Solution**: 
1. Reset database: Delete `portfolio.db`
2. Run: `dotnet run`
3. Use default credentials

### Issue: API Returning 404
**Solution**: Verify controller names match API routes:
- Model API files should be named `{Model}ApiController.cs`

---

## File Structure

```
kavinkumar.dev/
├── Controllers/
│   ├── HomeController.cs
│   ├── AdminController.cs
│   ├── EducationApiController.cs
│   ├── ProjectApiController.cs
│   ├── CertificateApiController.cs
│   ├── SkillApiController.cs
│   └── TestimonialApiController.cs
├── Models/
│   ├── Education.cs
│   ├── Project.cs
│   ├── Certificate.cs
│   ├── Skill.cs
│   ├── Testimonial.cs
│   ├── Admin.cs
│   ├── ContactMessage.cs
│   └── DashboardViewModel.cs
├── Data/
│   └── PortfolioContext.cs
├── Views/
│   ├── Home/
│   │   └── Index.cshtml
│   ├── Admin/
│   │   ├── Login.cshtml
│   │   └── Dashboard.cshtml
│   └── Shared/
│       └── _Layout.cshtml
├── wwwroot/
│   ├── css/
│   │   ├── themes.css (NEW - Theme System)
│   │   ├── portfolio.css
│   │   └── site.css
│   ├── js/
│   │   ├── theme-switcher.js (NEW - Theme Controller)
│   │   ├── portfolio.js
│   │   └── site.js
│   ├── images/
│   └── lib/
├── Properties/
│   └── launchSettings.json
├── portfolio.db (Auto-created)
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
├── kavinkumar.dev.csproj
└── PORTFOLIO_README.md (NEW)
```

---

## Quick Reference Commands

```bash
# Build project
dotnet build

# Run project
dotnet run

# Create migration (if schema changes)
dotnet ef migrations add InitialCreate

# Update database
dotnet ef database update

# Publish for production
dotnet publish -c Release -o ./publish

# Clean build
dotnet clean
```

---

## Next Steps

1. ✅ Setup and run application
2. ✅ Test admin login
3. ✅ Add your portfolio data
4. ✅ Test theme switching
5. ✅ Test API endpoints
6. ✅ Update admin credentials for production
7. ✅ Deploy to hosting provider

---

## Support

**Need Help?**
- Email: cecskavinkumarm24@gmail.com
- Phone: 6383728267
- GitHub: github.com/kavinkumarmuthusamy

---

**Last Updated**: January 26, 2026
