# ⚡ Quick Start Guide (2 Minutes)

## For the Impatient Developer 😄

### Step 1: Navigate to Project
```bash
cd "d:\html and css\kavinkumar.dev"
```

### Step 2: Run It!
```bash
dotnet run
```

### Step 3: Open Browser
```
https://localhost:5001
```

### Step 4: Login to Admin
```
URL: https://localhost:5001/Admin/Login
Username: admin
Password: admin123
```

---

## That's It! 🎉

You now have a fully functional portfolio CMS with:
- ✅ 3 themes (Light, Dark, Color)
- ✅ Admin dashboard
- ✅ SQLite database
- ✅ REST APIs
- ✅ Responsive design

---

## Quick Commands

```bash
# Start dev server
dotnet run

# Build only
dotnet build

# Clean and rebuild
dotnet clean && dotnet build

# Publish for production
dotnet publish -c Release -o ./publish
```

---

## Common Tasks

### Add a Project
1. Go to Admin > 💼 Projects
2. Click "+ Add Project"
3. Fill in details
4. Save

### Switch Theme
1. Click ☀️ or 🌙 or 🎨 in sidebar
2. Or press `Ctrl + Shift + T`

### View Messages
1. Go to Admin > 📧 Messages
2. See all contact submissions

### Test API
```bash
curl https://localhost:5001/api/projectapi
```

---

## Important Files

- **Login**: `Views/Admin/Login.cshtml`
- **Dashboard**: `Views/Admin/Dashboard.cshtml`
- **Theme System**: `wwwroot/js/theme-switcher.js`
- **Database**: `portfolio.db` (auto-created)
- **Docs**: `SETUP_GUIDE.md` (detailed setup)
- **API**: All `*ApiController.cs` files

---

## Troubleshooting

**Port in use?**
```bash
# Use different port
dotnet run --urls "https://localhost:5002"
```

**Database error?**
```bash
# Delete and recreate
rm portfolio.db
dotnet run
```

**Theme not working?**
- Check browser console (F12)
- Clear browser cache (Ctrl+Shift+Delete)
- Reload page (F5)

---

## Next Steps

1. 📖 Read `SETUP_GUIDE.md` for detailed instructions
2. 📋 Read `PORTFOLIO_README.md` for features
3. 🚀 Deploy when ready
4. 📞 Contact if needed: 6383728267

---

**You're all set! Happy coding!** 🚀
