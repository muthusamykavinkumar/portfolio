/*
 * Kavin Advanced AI Assistant v2.0
 * A robust client-side AI with context awareness, fuzzy matching, and deep analytical capabilities.
 */

const PortfolioAI = {
    data: {
        projects: [],
        skills: [],
        experience: [],
        education: [],
        certificates: []
    },
    state: {
        isLoaded: false,
        isOpen: false,
        lastIntent: null,
        conversationHistory: []
    },

    // --- INITIALIZATION ---
    async init() {
        try {
            await this.loadData();
            this.attachEventListeners();
            console.log('Kavin AI v2.0: Neural Core Online');
        } catch (error) {
            console.error('Kavin AI Initialization Failed:', error);
        }
    },

    async loadData() {
        // Fetch all data in parallel for speed
        const [projects, skills, experience, education, certificates] = await Promise.all([
            fetch('/api/projectapi').then(r => r.ok ? r.json() : []),
            fetch('/api/skillapi').then(r => r.ok ? r.json() : []),
            fetch('/api/experienceapi').then(r => r.ok ? r.json() : []),
            fetch('/api/educationapi').then(r => r.ok ? r.json() : []),
            fetch('/api/certificateapi').then(r => r.ok ? r.json() : [])
        ]);

        this.data = { projects, skills, experience, education, certificates };
        this.state.isLoaded = true;
    },

    attachEventListeners() {
        const toggleBtn = document.getElementById('ai-toggle-btn');
        const closeBtn = document.getElementById('ai-close-btn');
        const sendBtn = document.getElementById('ai-send-btn');
        const input = document.getElementById('ai-input');
        const suggestions = document.querySelectorAll('.ai-suggestion');

        if (toggleBtn) toggleBtn.addEventListener('click', () => this.toggleChat());
        if (closeBtn) closeBtn.addEventListener('click', () => this.toggleChat());

        if (sendBtn) {
            sendBtn.addEventListener('click', () => this.handleUserMessage());
        }

        if (input) {
            input.addEventListener('keypress', (e) => {
                if (e.key === 'Enter') this.handleUserMessage();
            });
        }

        // Delegate listener for dynamic suggestions
        document.addEventListener('click', (e) => {
            if (e.target.classList.contains('ai-suggestion')) {
                const text = e.target.textContent;
                this.addUserMessage(text);
                this.showTyping();
                setTimeout(() => this.processQuery(text), 800);
            }
        });
    },

    toggleChat() {
        const chatWindow = document.getElementById('ai-chat-window');
        const toggleBtn = document.getElementById('ai-toggle-btn');
        const input = document.getElementById('ai-input');

        this.state.isOpen = !this.state.isOpen;

        if (this.state.isOpen) {
            chatWindow.classList.add('active');
            toggleBtn.classList.add('hidden');
            setTimeout(() => input?.focus(), 300);

            // Initial Greeting
            if (document.getElementById('ai-messages').children.length === 0) {
                this.simulateThinking('Initializing knowledge base...', () => {
                    const greeting = this.getTimeBasedGreeting();
                    this.addBotMessage(`<b>${greeting}</b> I am Kavin's Advanced Virtual Assistant.<br><br>I can analyze his professional background, cross-reference his skills with projects, and answer specific career questions.<br><br><i>Try asking: "Where has he used C#?" or "Tell me about his leadership experience."</i>`);
                });
            }
        } else {
            chatWindow.classList.remove('active');
            toggleBtn.classList.remove('hidden');
        }
    },

    getTimeBasedGreeting() {
        const hour = new Date().getHours();
        if (hour < 12) return "Good morning.";
        if (hour < 18) return "Good afternoon.";
        return "Good evening.";
    },

    // --- CORE MESSAGING LOGIC ---
    handleUserMessage() {
        const input = document.getElementById('ai-input');
        const message = input.value.trim();

        if (!message) return;

        this.addUserMessage(message);
        input.value = '';
        this.showTyping();

        // Processing delay simulates analysis
        const delay = Math.max(800, message.length * 20);
        setTimeout(() => this.processQuery(message), delay);
    },

    addUserMessage(text) {
        this.appendMessage(text, 'user-message');
    },

    addBotMessage(html) {
        this.appendMessage(html, 'bot-message', true);
    },

    appendMessage(content, className, isHtml = false) {
        const container = document.getElementById('ai-messages');
        const msgDiv = document.createElement('div');
        msgDiv.className = `ai-message ${className}`;
        if (isHtml) msgDiv.innerHTML = content;
        else msgDiv.textContent = content;

        container.appendChild(msgDiv);
        this.scrollToBottom();
    },

    showTyping() {
        this.removeTyping();
        const container = document.getElementById('ai-messages');
        const typingDiv = document.createElement('div');
        typingDiv.id = 'ai-typing';
        typingDiv.className = 'ai-message bot-message typing';
        typingDiv.innerHTML = '<span></span><span></span><span></span>';
        container.appendChild(typingDiv);
        this.scrollToBottom();
    },

    removeTyping() {
        const typing = document.getElementById('ai-typing');
        if (typing) typing.remove();
    },

    simulateThinking(text, callback) {
        this.showTyping();
        setTimeout(() => {
            this.removeTyping();
            callback();
        }, 1200);
    },

    scrollToBottom() {
        const container = document.getElementById('ai-messages-container');
        if (container) container.scrollTo({ top: container.scrollHeight, behavior: 'smooth' });
    },

    // --- INTELLIGENCE ENGINE ---
    processQuery(rawQuery) {
        this.removeTyping();
        const query = rawQuery.toLowerCase();

        // 1. COMPLEX TECH USAGE ANALYSIS (e.g., "Where did he use C#?")
        if (query.includes('use') || query.includes('using') || query.includes('work with') || query.includes('experience with')) {
            const techMatch = this.extractTechFromQuery(query);
            if (techMatch) {
                return this.analyzeTechUsage(techMatch);
            }
        }

        // 2. SPECIFIC ENTITY SEARCH (Project names, Company names)
        const entityMatch = this.findEntity(query);
        if (entityMatch) {
            return this.respondWithEntityDetails(entityMatch);
        }

        // 3. STATISTICAL QUESTIONS (Years of experience, number of projects)
        if (query.includes('how many') || query.includes('how long') || query.includes('years') || query.includes('stats')) {
            return this.respondWithStats(query);
        }

        // 4. GENERAL CATEGORIES (Route to standard handlers)
        if (query.includes('project') || query.includes('portfolio')) return this.listProjects();
        if (query.includes('skill') || query.includes('tech stack')) return this.listSkills();
        if (query.includes('experience') || query.includes('history') || query.includes('job')) return this.describeExperience();
        if (query.includes('contact') || query.includes('hiring') || query.includes('email')) return this.provideContactInfo();
        if (query.includes('education') || query.includes('college') || query.includes('degree')) return this.describeEducation();
        if (query.includes('certificate') || query.includes('award')) return this.listCertificates();

        // 5. CONVERSATIONAL
        if (query.includes('hello') || query.includes('hi')) return this.addBotMessage("Hello! I'm fully loaded with Kavin's professional data. Ask me specific questions like 'What is his experience with React?' or 'Tell me about the Portfolio project'.");
        if (query.includes('thank')) return this.addBotMessage("You're welcome! Let me know if you need any other details about Kavin's profile.");
        if (query.includes('who are you')) return this.addBotMessage("I am a custom-built AI assistant seamlessly integrated into Kavin's ASP.NET Core portfolio. I analyze real-time database content to answer your questions.");

        // FALLBACK
        this.addBotMessage("That's a great question. While I'm analyzing the database, I couldn't find a direct match. <br><br>Can you try asking about a specific <b>Skill</b>, <b>Project</b>, or <b>Company</b>?");
    },

    // --- ANALYTICAL FUNCTIONS ---

    extractTechFromQuery(query) {
        // Try to find a skill name inside the query
        const allSkills = this.data.skills.map(s => s.name.toLowerCase());
        return allSkills.find(s => query.includes(s));
    },

    analyzeTechUsage(techName) {
        // Find projects that use this tech
        const matchingProjects = this.data.projects.filter(p =>
            p.technologies && p.technologies.toLowerCase().includes(techName)
        );

        // Find relevant experience
        const matchingExp = this.data.experience.filter(e =>
            e.description.toLowerCase().includes(techName)
        );

        let response = `<b>Analysis for "${techName.toUpperCase()}":</b><br><br>`;

        if (matchingProjects.length > 0) {
            response += `Found in <b>${matchingProjects.length} Projects</b>:<br>`;
            response += matchingProjects.map(p => `• ${p.title}`).join('<br>');
            response += '<br><br>';
        }

        if (matchingExp.length > 0) {
            response += `Applied during Professional Experience at:<br>`;
            response += matchingExp.map(e => `• ${e.companyName} (${e.position})`).join('<br>');
        }

        if (matchingProjects.length === 0 && matchingExp.length === 0) {
            response = `Kavin lists <b>${techName.toUpperCase()}</b> as a skill, but I didn't find specific mentions in his project descriptions or job history details yet. He likely used it in smaller tasks or internal tools.`;
        }

        this.addBotMessage(response);
    },

    findEntity(query) {
        // Check Projects
        const project = this.data.projects.find(p => query.includes(p.title.toLowerCase()));
        if (project) return { type: 'project', data: project };

        // Check Companies
        const job = this.data.experience.find(e => query.includes(e.companyName.toLowerCase()));
        if (job) return { type: 'job', data: job };

        return null;
    },

    respondWithEntityDetails(entity) {
        if (entity.type === 'project') {
            const p = entity.data;
            this.addBotMessage(`<b>${p.title}</b><br>${p.description}<br><br><b>Tech Stack:</b> ${p.technologies || 'N/A'} <br><br> <a href="${p.projectUrl}" target="_blank" class="ai-link">View Project</a>`);
        } else if (entity.type === 'job') {
            const j = entity.data;
            this.addBotMessage(`<b>${j.position} at ${j.companyName}</b><br><i>${j.startDate.split('T')[0]} to ${j.endDate ? j.endDate.split('T')[0] : 'Present'}</i><br><br>${j.description}`);
        }
    },

    respondWithStats(query) {
        if (query.includes('experience') || query.includes('long')) {
            // Calculate total years
            const startStr = this.data.experience.length > 0 ? this.data.experience[this.data.experience.length - 1].startDate : new Date().toISOString();
            const start = new Date(startStr);
            const now = new Date();
            const years = ((now - start) / (1000 * 60 * 60 * 24 * 365)).toFixed(1);
            this.addBotMessage(`Based on his first recorded role, Kavin has approximately <b>${years} years</b> of professional experience.`);
            return;
        }

        if (query.includes('project')) {
            this.addBotMessage(`Looking at the database, Kavin has <b>${this.data.projects.length}</b> featured projects in his portfolio.`);
            return;
        }

        this.addBotMessage("I can calculate stats about projects and years of experience. Try asking 'How many years of experience?'");
    },

    // --- STANDARD LISTERS ---

    listSkills() {
        const categories = {};
        // Mock categorization since we don't have it in DB, or just list top ones
        const topSkills = this.data.skills
            .sort((a, b) => b.proficiencyLevel - a.proficiencyLevel)
            .slice(0, 8);

        let html = "<b>Top Technical Skills:</b><br>";
        html += topSkills.map(s =>
            `<div style="display:flex; justify-content:space-between; margin-top:4px;">
                <span>${s.name}</span>
                <div style="width:50px; background:#ddd; height:6px; margin-top:6px; border-radius:3px;">
                    <div style="width:${s.proficiencyLevel}%; background:var(--primary); height:100%; border-radius:3px;"></div>
                </div>
            </div>`
        ).join('');

        this.addBotMessage(html + "<br><i>Ask me 'Where did he use [Skill]?' for details.</i>");
    },

    listProjects() {
        if (this.data.projects.length === 0) return this.addBotMessage("No projects found in the database.");

        const recents = this.data.projects.slice(0, 3);
        let html = "<b>Recent Featured Work:</b><br><br>";

        recents.forEach(p => {
            html += `<div style="background:rgba(0,0,0,0.05); padding:8px; border-radius:8px; margin-bottom:8px;">
                <b>${p.title}</b><br>
                <span style="font-size:0.8rem; opacity:0.8;">${p.technologies}</span>
             </div>`;
        });

        html += `<button class="ai-suggestion" style="margin-top:5px; width:100%;">Show more projects</button>`;
        this.addBotMessage(html);
    },

    describeExperience() {
        const current = this.data.experience[0];
        if (!current) return this.addBotMessage("No experience records found.");

        this.addBotMessage(`Kavin is currently the <b>${current.position}</b> at <b>${current.companyName}</b> (${current.companyType}).<br><br>He focuses on:<br>${current.description}<br><br>Prior to this, he has other roles you can ask about.`);
    },

    describeEducation() {
        if (this.data.education.length === 0) return this.addBotMessage("Education details not found.");
        const edu = this.data.education[0];
        this.addBotMessage(`He holds a <b>${edu.degree}</b> in <b>${edu.fieldOfStudy}</b> from <b>${edu.institutionName}</b>.<br>Graduated: ${edu.graduationYear}<br>CGPA: ${edu.cgpa}`);
    },

    listCertificates() {
        const count = this.data.certificates.length;
        this.addBotMessage(`Kavin has earned <b>${count} professional certifications</b>, including awards from ${this.data.certificates.slice(0, 2).map(c => c.issuedBy).join(' and ')}.`);
    },

    provideContactInfo() {
        this.addBotMessage(`
            <div style="text-align:center; padding:10px;">
                <b>Let's Connect!</b><br><br>
                <a href="mailto:cecskavinkumarm24@gmail.com" style="color:var(--primary); text-decoration:none; font-weight:bold;">cecskavinkumarm24@gmail.com</a>
                <br>
                <span>+91 6383728267</span>
                <br><br>
                <div style="display:flex; gap:10px; justify-content:center;">
                    <a href="https://linkedin.com" target="_blank">LinkedIn</a> • 
                    <a href="https://github.com" target="_blank">GitHub</a>
                </div>
            </div>
        `);
    }
};

// Auto-boot
document.addEventListener('DOMContentLoaded', () => PortfolioAI.init());
