using System;
using System.Collections.Generic;

public class Chatbot
{
    // ── Part 1 originals ──────────────────────────────────────
    private User user;
    private AudioPlayer audio;

    // ── Part 2 new classes ────────────────────────────────────
    private KeywordResponder _keywords;
    private SentimentDetector _sentiment;
    private MemoryStore _memory;

    // ── Conversation state ────────────────────────────────────
    private bool _awaitingName = true;
    private string _lastTopic = "";

    public Chatbot()
    {
        user = new User();
        audio = new AudioPlayer();

        _keywords = new KeywordResponder();
        _sentiment = new SentimentDetector();
        _memory = new MemoryStore();
    }

    // ── Called once when the GUI loads ────────────────────────
    public string GetGreeting()
    {
        audio.PlayAudio(); // keeps Part 1 voice greeting
        return "🔐 Welcome to Cyber Sentinel AI!\n\nWhat is your name?";
    }

    // ── ASCII art string for the GUI header ───────────────────
    public string GetAsciiArt()
    {
        return
@" ██████╗██╗   ██╗██████╗ ███████╗██████╗ 
██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗
██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝
██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗
╚██████╗   ██║   ██████╔╝███████╗██║  ██║
 ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝
        🔐 CYBER SENTINEL AI 🤖";
    }

    // ── MAIN METHOD — Form1 calls this for every message ──────
    public string ProcessInput(string input)
    {
        input = input.Trim();

        if (string.IsNullOrWhiteSpace(input))
            return "Please type something so I can help you. 😊";

        // ── STEP 1: Capture name on first message ──────────────
        if (_awaitingName)
        {
            user.Name = input;
            _memory.UserName = input;
            _awaitingName = false;
            return $"Nice to meet you, {user.Name}! 🔐\n\n" +
                   $"You can ask me about: {string.Join(", ", _keywords.GetAllKeywords())}\n\n" +
                   "Or just tell me how you're feeling and I'll help you out!";
        }

        string inputLower = input.ToLower();

        // ── STEP 2: Follow-up handling ─────────────────────────
        if ((inputLower.Contains("more") || inputLower.Contains("tell me more") || inputLower.Contains("explain more"))
            && _lastTopic != "")
        {
            string followUp = _keywords.GetResponse(_lastTopic);
            return $"Here's more on {_lastTopic}, {_memory.UserName}:\n\n{followUp}";
        }

        // ── STEP 3: Detect sentiment ───────────────────────────
        Sentiment detectedMood = _sentiment.Detect(inputLower);
        string sentimentOpener = _sentiment.GetSentimentResponse(detectedMood);

        // ── STEP 4: Keyword recognition ────────────────────────
        string keywordResponse = _keywords.GetResponse(inputLower);

        if (keywordResponse != null)
        {
            // Update last topic and favourite topic in memory
            foreach (string kw in _keywords.GetAllKeywords())
            {
                if (inputLower.Contains(kw))
                {
                    _lastTopic = kw;
                    _memory.FavouriteTopic = kw;
                    break;
                }
            }

            string personalOpener = _memory.GetPersonalisedOpener();

            // Build the full response
            string response = "";
            if (!string.IsNullOrEmpty(sentimentOpener)) response += sentimentOpener + "\n\n";
            if (!string.IsNullOrEmpty(personalOpener)) response += personalOpener + "\n\n";
            response += keywordResponse;
            response += "\n\nType 'tell me more' if you want to know more about this topic!";
            return response;
        }

        // ── STEP 5: Special phrases ────────────────────────────
        if (inputLower.Contains("how are you"))
            return $"I'm running at full capacity, {_memory.UserName}! 💻 Ready to keep you cyber-safe. How can I help?";

        if (inputLower.Contains("what can you do") || inputLower.Contains("help") || inputLower.Contains("purpose"))
            return $"I can help you with cybersecurity topics, {_memory.UserName}!\n\n" +
                   $"Try asking about: {string.Join(", ", _keywords.GetAllKeywords())}\n\n" +
                   "You can also just tell me how you're feeling and I'll respond accordingly!";

        if (inputLower.Contains("bye") || inputLower.Contains("goodbye") || inputLower.Contains("exit"))
            return $"Stay safe online, {_memory.UserName}! 🔐 Goodbye!";

        // ── STEP 6: Fallback ───────────────────────────────────
        var fallbacks = new List<string>
        {
            $"I'm not sure about that, {_memory.UserName}. Try asking about phishing, malware, or passwords!",
            $"Hmm, that's outside my knowledge base. Ask me about: {string.Join(", ", _keywords.GetAllKeywords())}",
            $"I didn't quite get that. Try rephrasing or ask me about a cybersecurity topic, {_memory.UserName}!",
        };

        var rng = new Random();
        return fallbacks[rng.Next(fallbacks.Count)];
    }
}