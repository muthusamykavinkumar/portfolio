/* ============================================
   Theme Switcher - Dark, Light, Color Themes
   ============================================ */

const ThemeSwitcher = {
    LIGHT: 'light',
    DARK: 'dark',
    COLOR: 'color',
    STORAGE_KEY: 'portfolio-theme',

    // Initialize theme on page load
    init() {
        const savedTheme = this.getSavedTheme();
        this.setTheme(savedTheme || this.LIGHT);
        this.attachEventListeners();
        this.updateThemeButtons();
    },

    // Get saved theme from localStorage
    getSavedTheme() {
        return localStorage.getItem(this.STORAGE_KEY);
    },

    // Set theme and update DOM
    setTheme(theme) {
        if (![this.LIGHT, this.DARK, this.COLOR].includes(theme)) {
            theme = this.LIGHT;
        }

        document.documentElement.setAttribute('data-theme', theme);
        localStorage.setItem(this.STORAGE_KEY, theme);
        this.updateThemeButtons();
        this.dispatchThemeChangeEvent(theme);
    },

    // Get current theme
    getCurrentTheme() {
        return document.documentElement.getAttribute('data-theme') || this.LIGHT;
    },

    // Toggle to next theme
    toggleTheme() {
        const currentTheme = this.getCurrentTheme();
        let nextTheme;

        switch (currentTheme) {
            case this.LIGHT:
                nextTheme = this.DARK;
                break;
            case this.DARK:
                nextTheme = this.COLOR;
                break;
            case this.COLOR:
                nextTheme = this.LIGHT;
                break;
            default:
                nextTheme = this.LIGHT;
        }

        this.setTheme(nextTheme);
    },

    // Update theme button states
    updateThemeButtons() {
        const currentTheme = this.getCurrentTheme();

        // Update theme toggle button
        const themeBtn = document.getElementById('mode-toggle');
        if (themeBtn) {
            themeBtn.classList.remove('light-mode', 'dark-mode', 'color-mode');
            themeBtn.classList.add(`${currentTheme}-mode`);
            themeBtn.title = `Switch to ${this.getNextThemeName()} theme`;
        }

        // Update theme selector
        const themeSelects = document.querySelectorAll('[data-theme-selector]');
        themeSelects.forEach(select => {
            select.value = currentTheme;
        });
    },

    // Get next theme name for display
    getNextThemeName() {
        const currentTheme = this.getCurrentTheme();
        switch (currentTheme) {
            case this.LIGHT:
                return 'Dark';
            case this.DARK:
                return 'Color';
            case this.COLOR:
                return 'Light';
            default:
                return 'Light';
        }
    },

    // Attach event listeners
    attachEventListeners() {
        // Theme toggle button
        const themeBtn = document.getElementById('mode-toggle');
        if (themeBtn) {
            themeBtn.addEventListener('click', (e) => {
                e.preventDefault();
                this.toggleTheme();
            });
        }

        // Theme selector dropdown
        const themeSelectors = document.querySelectorAll('[data-theme-selector]');
        themeSelectors.forEach(selector => {
            selector.addEventListener('change', (e) => {
                this.setTheme(e.target.value);
            });
        });

        // Keyboard shortcut: Ctrl+Shift+T to toggle theme
        document.addEventListener('keydown', (e) => {
            if (e.ctrlKey && e.shiftKey && e.key === 'T') {
                e.preventDefault();
                this.toggleTheme();
            }
        });
    },

    // Dispatch custom event when theme changes
    dispatchThemeChangeEvent(theme) {
        const event = new CustomEvent('themechanged', {
            detail: { theme }
        });
        document.dispatchEvent(event);
    },

    // Get theme colors
    getThemeColors() {
        const theme = this.getCurrentTheme();
        const styles = getComputedStyle(document.documentElement);

        return {
            primary: styles.getPropertyValue('--primary').trim(),
            secondary: styles.getPropertyValue('--secondary').trim(),
            accent: styles.getPropertyValue('--accent').trim(),
            bgPrimary: styles.getPropertyValue('--bg-primary').trim(),
            bgSecondary: styles.getPropertyValue('--bg-secondary').trim(),
            textPrimary: styles.getPropertyValue('--text-primary').trim(),
            textSecondary: styles.getPropertyValue('--text-secondary').trim(),
        };
    },

    // Create theme selector HTML
    createThemeSelector() {
        const container = document.createElement('div');
        container.className = 'theme-selector-container';
        container.innerHTML = `
            <div class="theme-selector">
                <label for="theme-select">Theme:</label>
                <select id="theme-select" data-theme-selector>
                    <option value="light">☀️ Light</option>
                    <option value="dark">🌙 Dark</option>
                    <option value="color">🎨 Color</option>
                </select>
            </div>
        `;
        return container;
    }
};

// Initialize on DOM ready
if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', () => {
        ThemeSwitcher.init();
    });
} else {
    ThemeSwitcher.init();
}

// Export for use in other scripts
if (typeof module !== 'undefined' && module.exports) {
    module.exports = ThemeSwitcher;
}
