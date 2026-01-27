# ❓ Frequently Asked Questions (FAQ)

## 🎨 Theme System Questions

### Q: How do I add a custom theme?
**A**: Edit `wwwroot/css/themes.css`. Add a new theme block with CSS variables:

```css
html[data-theme="mytheme"] {
    --primary: #your-color;
    --secondary: #your-color;
    /* ... other variables */
}
```

Then update `wwwroot/js/theme-switcher.js` to include the new theme.

---

### Q: Where is the theme preference stored?
**A**: In browser's `localStorage` under key `portfolio-theme`. This persists across sessions.

---

### Q: Can I change theme colors permanently?
**A**: Yes! Edit the CSS variables in `wwwroot/css/themes.css` for the desired theme.

---

### Q: Does theme switching work offline?
**A**: Yes! Theme switching is 100% client-side JavaScript. Works without server.

---

## 🔐 Authentication & Security

### Q: How do I change the admin password?
**A**: 
1. Edit `Data/PortfolioContext.cs`
2. Update the seeded admin password:
```csharp
PasswordHash = BCrypt.Net.BCrypt.HashPassword("new_password")
```
3. Delete `portfolio.db`
4. Run `dotnet run` to recreate with new password

---

### Q: Is the password hashing secure?
**A**: Yes! Using BCrypt.Net-Core which is industry-standard for password hashing with salt.

---

### Q: Can multiple admins log in?
**A**: Yes! You can add more admins to the `Admin` table via the API:

```bash
POST /api/admin
{
  "username": "kavin",
  "password": "password123",
  "email": "kavin@example.com"
}
```

Currently no API for this, but you can add via database directly.

---

### Q: What happens after login?
**A**: Browser receives a secure cookie. Cookie is sent with every request to authenticate.

---

### Q: How do I logout?
**A**: Click the "Logout" button in admin dashboard. This clears the authentication cookie.

---

## 💾 Database Questions

### Q: Where is the database stored?
**A**: As `portfolio.db` in the project root directory. 

**Path**: `d:\html and css\kavinkumar.dev\portfolio.db`

---

### Q: Can I backup the database?
**A**: Yes! Just copy `portfolio.db` to a safe location.

```bash
copy portfolio.db portfolio.backup.db
```

---

### Q: Can I use SQL Server instead of SQLite?
**A**: Yes! Update connection string in `appsettings.json`:

```json
"DefaultConnection": "Server=your-server;Database=portfolio;..."
```

And change `UseSqlite()` to `UseSqlServer()` in `Program.cs`.

---

### Q: How do I reset the database?
**A**: 
1. Delete `portfolio.db`
2. Run `dotnet run`
3. Database recreates with default data

---

### Q: Can I view database contents directly?
**A**: Yes! Use SQLite viewer tools like:
- SQLite Browser (https://sqlitebrowser.org/)
- DBeaver (Free edition)
- VS Code SQLite extension

---

## 📊 Admin Dashboard Questions

### Q: Where's the edit form for items?
**A**: Currently, edit forms are modal/in-progress. The foundation is there, ready to implement.

---

### Q: How do I delete all messages at once?
**A**: Currently one-by-one deletion only. Bulk delete feature can be added.

---

### Q: Can I export data to CSV?
**A**: Not currently, but APIs make it easy to implement.

---

### Q: How do I see who submitted a message?
**A**: Name and email are saved with each message in the dashboard.

---

### Q: Can I reply to messages?
**A**: Currently no email feature, but you can record contact info and reply manually.

---

## 🔌 API Questions

### Q: How do I get all projects?
**A**: 
```bash
curl https://localhost:5001/api/projectapi
```

---

### Q: How do I create an item via API?
**A**: 
```bash
curl -X POST https://localhost:5001/api/projectapi \
  -H "Content-Type: application/json" \
  -d '{"title":"My Project","description":"...","technologies":"..."}'
```

---

### Q: What's the JSON format for each entity?
**A**: Check `Models/` folder for properties. Return 200 OK on success.

---

### Q: Can I authenticate via API?
**A**: Currently login only via web form. API can be extended for token-based auth.

---

### Q: Are the APIs RESTful?
**A**: Yes! Standard REST conventions:
- GET = Retrieve
- POST = Create
- PUT = Update
- DELETE = Remove

---

## 📱 Responsive Design Questions

### Q: Does it work on mobile?
**A**: Yes! Fully responsive with breakpoints at 320px, 768px, 1024px, 1200px.

---

### Q: How do I test on mobile?
**A**: 
1. Use browser DevTools (F12)
2. Press Ctrl+Shift+M for device simulation
3. Or test on actual device using `https://your-ip:5001`

---

### Q: Are theme buttons visible on mobile?
**A**: Yes! Theme selector is in sidebar which is responsive.

---

## 🚀 Deployment Questions

### Q: How do I deploy to production?
**A**: 
```bash
dotnet publish -c Release -o ./publish
```

Then upload `publish` folder to hosting.

---

### Q: Do I need to change anything for production?
**A**: Yes! Critical changes:
1. **Change admin password** (very important!)
2. Update connection string (if using cloud database)
3. Enable HTTPS certificate
4. Set `ASPNETCORE_ENVIRONMENT=Production`
5. Backup database regularly

---

### Q: How do I host on Azure?
**A**: 
1. Create Azure App Service
2. Configure for .NET 10
3. Upload published files
4. Set connection string in Azure

---

### Q: How do I host on IIS?
**A**: 
1. Install .NET Hosting Bundle
2. Create IIS website
3. Point to published folder
4. Set app pool settings
5. Configure HTTPS

---

### Q: What's the minimum hosting requirement?
**A**: 
- Windows/Linux server
- .NET 10 Runtime
- ~100MB disk space
- 256MB RAM minimum

---

## 🐛 Troubleshooting Questions

### Q: The database won't create?
**A**: 
1. Check `Program.cs` for `EnsureCreated()`
2. Verify write permissions in project folder
3. Check if `portfolio.db` is locked

---

### Q: Admin login shows "Invalid credentials"?
**A**: 
1. Check spelling: `admin` / `admin123`
2. Delete `portfolio.db` and start fresh
3. Verify PortfolioContext seeding code

---

### Q: Theme switching not working?
**A**: 
1. Open Browser DevTools (F12)
2. Check Console for JavaScript errors
3. Clear cache: Ctrl+Shift+Delete
4. Reload: F5 or Ctrl+R

---

### Q: "Port 5001 already in use"?
**A**: Either:
1. Close other instance: `taskkill /IM dotnet.exe`
2. Use different port: `dotnet run --urls "https://localhost:5002"`

---

### Q: HTTPS certificate warning?
**A**: 
1. Self-signed certificate is normal for development
2. Click "Advanced" → "Proceed anyway"
3. For production, get real SSL certificate

---

### Q: API returning 404?
**A**: 
1. Check URL spelling (case-sensitive)
2. Verify controller names: `EducationApiController` → `/api/educationapi`
3. Check `program.cs` for route registration

---

## 📚 Learning & Customization

### Q: How do I add a new portfolio section?
**A**: 
1. Create Model in `Models/` (e.g., `Experience.cs`)
2. Add DbSet in `PortfolioContext.cs`
3. Create `ExperienceApiController.cs`
4. Add tab in `Dashboard.cshtml`
5. Add section to `Home/Index.cshtml`

---

### Q: How do I add image upload?
**A**: 
1. Add `IFormFile ImageFile` to controller action
2. Save to `wwwroot/images/`
3. Store filename in database
4. Display in views

---

### Q: Can I add comments to projects?
**A**: 
1. Create `Comment` model with ProjectId FK
2. Add API controller
3. Add comment form in project display
4. Add dashboard to manage comments

---

### Q: How do I add user authentication?
**A**: 
1. Create `User` model
2. Implement registration page
3. Update authentication logic
4. Add authorization checks

---

### Q: Can I add multiple projects per skill?
**A**: Yes! Create a `SkillProject` junction table with FK to both.

---

## 💡 Best Practices

### Q: Should I commit `portfolio.db` to Git?
**A**: **No!** Add to `.gitignore`:
```
portfolio.db
*.db
```

Keep only source code in Git.

---

### Q: Should I version my CSS?
**A**: For production, add hash: `themes.css?v=1.0.0`

---

### Q: How often should I backup?
**A**: At least daily in production. Automate with scheduled tasks.

---

### Q: Should I minify CSS/JS?
**A**: Yes, for production! Use build tools like:
- WebPack
- gulp
- Parcel

---

## 📞 Still Have Questions?

**Contact Kavin Kumar:**
- 📧 Email: cecskavinkumarm24@gmail.com
- 📱 Phone: +91 6383728267
- 💼 LinkedIn: linkedin.com/in/kavin-kumar-268620255
- 🐙 GitHub: github.com/kavinkumarmuthusamy

---

**Last Updated**: January 26, 2026
**Status**: FAQ Complete ✅
