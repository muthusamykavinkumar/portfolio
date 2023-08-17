const menuIcon = document.getElementById('menu-icon');
const navLinks = document.getElementById('nav-links');

menuIcon.addEventListener('click', () => {
    navLinks.classList.toggle('active');
});

/* Previous JavaScript code */

const modeToggle = document.getElementById("mode-toggle");
const body = document.body;

modeToggle.addEventListener("click", () => {
    body.classList.toggle("dark-mode");
    body.classList.toggle("light-mode");
    
    const isDarkMode = body.classList.contains("dark-mode");
    modeToggle.innerHTML = isDarkMode ? '<i class="fas fa-sun"></i>' : '<i class="fas fa-moon"></i>';
    
    const currentMode = isDarkMode ? "dark" : "light";
    localStorage.setItem("mode", currentMode);
});

// Check for saved mode preference
const savedMode = localStorage.getItem("mode");
if (savedMode === "dark") {
    body.classList.add("dark-mode");
    modeToggle.innerHTML = '<i class="fas fa-sun"></i>';
} else if (savedMode === "light") {
    body.classList.add("light-mode");
    modeToggle.innerHTML = '<i class="fas fa-moon"></i>';
}




