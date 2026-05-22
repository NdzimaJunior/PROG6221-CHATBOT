
# 🔐 Cyber Sentinel AI — PROG6221 Part 2

> A cybersecurity awareness chatbot built in C# WinForms with keyword recognition, sentiment detection, memory recall, and random responses.

---

## 👤 Student Details

| Field | Details |
|---|---|
| **Name** | Ndzima Mthembi |
| **Module** | PROG6221 — Programming 2A |
| **Part** | Part 2 — GUI Chatbot |

---

## 📋 Features Implemented

- ✅ **WinForms GUI** — Dark navy cybersecurity themed interface with ASCII art header
- ✅ **Voice Greeting** — Plays audio on launch (Part 1 carried over)
- ✅ **ASCII Art** — Displays in the GUI header on startup
- ✅ **Keyword Recognition** — 8 cybersecurity keywords recognised:
  - password, phishing, privacy, malware, scam, wifi, firewall, encryption
- ✅ **Random Responses** — Each keyword has 4 different responses, randomly selected
- ✅ **Sentiment Detection** — Detects worried, curious, frustrated, happy moods and responds empathetically
- ✅ **Memory & Recall** — Remembers user name and favourite topic, uses them in responses
- ✅ **Conversation Flow** — "tell me more" continues the current topic without resetting
- ✅ **Fallback Responses** — Handles unrecognised input without crashing
- ✅ **OOP Structure** — Logic split across 4 classes (no God class)

---

## 🗂️ Project Structure

```
PROG6221-CHATBOT/
├── Chatbot.cs              # Core chatbot logic and ProcessInput() routing
├── KeywordResponder.cs     # Keyword dictionary with random response lists
├── SentimentDetector.cs    # Mood detection and empathetic responses
├── MemoryStore.cs          # Stores user name and favourite topic
├── User.cs                 # User model (Part 1)
├── AudioPlayer.cs          # Voice greeting (Part 1)
├── Form1.cs                # WinForms GUI event handlers
├── Form1.Designer.cs       # WinForms GUI layout and controls
├── Program.cs              # App entry point
├── greeting.wav            # Voice greeting audio file
└── README.md
```

---

## 🚀 How to Run

### Prerequisites
- Visual Studio 2022
- .NET 8.0 (or .NET Framework 4.7.2+)
- Windows OS

### Steps
1. Clone the repository:
   ```
   git clone https://github.com/NdzimaJunior/PROG6221-CHATBOT.git
   ```
2. Open `PROG6221-CHATBOT.sln` in Visual Studio 2022
3. Make sure `greeting.wav` is in the project folder and set to **Copy Always** in properties
4. Press **F5** or click the green ▶️ button to run

---

## 🔊 Voice Greeting Setup

The `greeting.wav` file must be located in the project root folder. In Visual Studio:
1. Right-click `greeting.wav` in Solution Explorer
2. Click **Properties**
3. Set **Copy to Output Directory** to `Copy always`

---

## 🧪 How to Test Features

| Feature | What to type |
|---|---|
| Keyword Recognition | `phishing`, `malware`, `password` |
| Random Responses | Type `password` multiple times — response changes each time |
| Sentiment Detection | `I am worried about phishing` |
| Memory Recall | Enter your name → then ask about a topic → it uses your name |
| Conversation Flow | Ask about a topic → then type `tell me more` |

---

## 🔗 Links

| Resource | Link |
|---|---|
| GitHub Repository | https://github.com/NdzimaJunior/PROG6221-CHATBOT |
| YouTube Presentation | *(to be added)* |

---

## 📸 Screenshots

*(Add a screenshot of the running GUI here)*

---

## ⚙️ GitHub Actions CI

*(Add a screenshot of the green Actions tick here)*

---

*By Ndzima Mthembi — PROG6221 Part 2*
