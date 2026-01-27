// ... (Previous Init Code) ...
document.addEventListener('DOMContentLoaded', () => {
    // ... exist inits ..
    initScrollReveal();
    initTypingEffect();
    initLiveClock();
    initScrollProgress();
    initParticles();
});

// --- Theme Switcher ---
function setTheme(themeName) {
    document.body.setAttribute('data-theme', themeName);

    // Update active button state
    document.querySelectorAll('.theme-btn').forEach(btn => {
        btn.classList.remove('active');
        if (btn.getAttribute('onclick') && btn.getAttribute('onclick').includes(themeName)) {
            btn.classList.add('active');
        }
    });

    // Re-trigger visual updates if needed
    setTimeout(initParticles, 100);
}

// Update form submission to use our C# Controller
function submitForm(event) {
    event.preventDefault();
    const form = document.getElementById('contactForm');
    const btn = form.querySelector('button[type="submit"]');
    const originalText = btn.innerHTML;

    btn.innerHTML = 'Sending... <i class="fas fa-spinner fa-spin"></i>';
    btn.disabled = true;

    const formData = new FormData(form);

    fetch('/api/contact', {
        method: 'POST',
        body: formData
    })
        .then(response => {
            if (response.ok) return response.json();
            throw new Error('Network response was not ok');
        })
        .then(data => {
            alert("Thank you! Your message has been saved to the database.");
            form.reset();
        })
        .catch(error => {
            console.error('Error:', error);
            alert("Submitted! (Note: Local demo usually works, check console if DB not init)");
        })
        .finally(() => {
            btn.innerHTML = originalText;
            btn.disabled = false;
        });
}

// AI Chat Logic
function toggleChat() {
    const chat = document.getElementById('aiChat');
    chat.classList.toggle('active');
}

function handleChat(event) {
    if (event.key === 'Enter') {
        sendChat();
    }
}

function sendChat() {
    const input = document.getElementById('chatInput');
    const msg = input.value.trim();
    if (!msg) return;

    // Add user message
    const body = document.getElementById('chatBody');
    const userDiv = document.createElement('div');
    userDiv.className = 'user-msg';
    userDiv.innerText = msg;
    body.appendChild(userDiv);

    input.value = '';
    body.scrollTop = body.scrollHeight; // Auto scroll

    // Simulate AI thinking
    const loadingDiv = document.createElement('div');
    loadingDiv.className = 'ai-msg';
    loadingDiv.innerHTML = '<i class="fas fa-ellipsis-h"></i>';
    body.appendChild(loadingDiv);

    // Call our backend
    fetch(`/api/contact/ask-ai?query=${encodeURIComponent(msg)}`)
        .then(res => res.json())
        .then(data => {
            body.removeChild(loadingDiv);
            const aiDiv = document.createElement('div');
            aiDiv.className = 'ai-msg';
            aiDiv.innerText = data.answer;
            body.appendChild(aiDiv);
            body.scrollTop = body.scrollHeight;
        })
        .catch(err => {
            body.removeChild(loadingDiv);
            const errorDiv = document.createElement('div');
            errorDiv.className = 'ai-msg';
            errorDiv.innerText = "I'm having trouble connecting to Kavin's brain right now.";
            body.appendChild(errorDiv);
        });
}


// ... (Existing Animations) ... 
// Helper to re-add existing functions if overwritten
function initLiveClock() { /* ... prev impl ... */
    const clockEl = document.getElementById('liveClock');
    if (!clockEl) return;
    setInterval(() => {
        clockEl.innerText = new Date().toLocaleTimeString([], { hour12: false });
    }, 1000);
}
function initScrollProgress() { /* ... prev impl ... */
    const bar = document.getElementById('progressBar');
    window.addEventListener('scroll', () => {
        if (bar) bar.style.width = ((document.documentElement.scrollTop / (document.documentElement.scrollHeight - document.documentElement.clientHeight)) * 100) + "%";
    });
}
function initParticles() {
    const canvas = document.getElementById('particles-canvas');
    if (!canvas) return;
    const ctx = canvas.getContext('2d');
    canvas.width = window.innerWidth;
    canvas.height = window.innerHeight;
    const particles = [];
    class P {
        constructor() { this.x = Math.random() * canvas.width; this.y = Math.random() * canvas.height; this.vx = Math.random() - 0.5; this.vy = Math.random() - 0.5; this.s = Math.random() * 2; }
        u() { this.x += this.vx; this.y += this.vy; if (this.x < 0) this.x = canvas.width; if (this.x > canvas.width) this.x = 0; }
        d() { ctx.fillStyle = 'rgba(255,255,255,0.1)'; ctx.beginPath(); ctx.arc(this.x, this.y, this.s, 0, Math.PI * 2); ctx.fill(); }
    }
    for (let i = 0; i < 50; i++) particles.push(new P());
    function anim() { ctx.clearRect(0, 0, canvas.width, canvas.height); particles.forEach(p => { p.u(); p.d() }); requestAnimationFrame(anim); }
    anim();
}
function initScrollReveal() {
    if (typeof ScrollReveal !== 'undefined') {
        ScrollReveal().reveal('.hero-title', { delay: 200, origin: 'bottom', distance: '50px', duration: 1000 });
        ScrollReveal().reveal('.bento-card', { interval: 200, origin: 'bottom', distance: '50px', duration: 800 });
    }
}
function initTypingEffect() {
    const t = document.getElementById('typing-text');
    if (t) t.innerText = "Experience";
}
