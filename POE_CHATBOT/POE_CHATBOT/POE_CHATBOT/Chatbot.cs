using System;
using System.Collections.Generic;
using POE_CHATBOT;

public enum ChatContext
{
    Normal,
    AddTask_AwaitingTitle,
    AddTask_AwaitingDescription,
    AddTask_AwaitingReminder,
    Quiz_Active
}

public class Chatbot
{
    // Part 1 & Part 2 instances
    private User user;
    private AudioPlayer audio;
    private KeywordResponder _keywords;
    private SentimentDetector _sentiment;
    private MemoryStore _memory;

    // Part 3 Manager instances
    private TaskManager _taskManager;
    private QuizManager _quizManager;

    // Context & State Tracking
    private bool _awaitingName = true;
    private string _lastTopic = "";
    private ChatContext _currentContext = ChatContext.Normal;

    // Temporal storage state machines
    private CyberTask _tempTask;
    private List<QuizQuestion> _activeQuizQuestions;
    private int _currentQuizIndex = 0;
    private int _quizScore = 0;

    public Chatbot()
    {
        user = new User();
        audio = new AudioPlayer();
        _keywords = new KeywordResponder();
        _sentiment = new SentimentDetector();
        _memory = new MemoryStore();

        // Initialize Part 3 components
        _taskManager = new TaskManager();
        _quizManager = new QuizManager();
    }

    public string GetGreeting()
    {
        audio.PlayAudio();
        ActivityLogger.Log("Chatbot started / greeting played.");
        return "🔐 Welcome to Cyber Sentinel AI!\n\nWhat is your name?";
    }

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

    public string ProcessInput(string input)
    {
        input = input.Trim();
        if (string.IsNullOrWhiteSpace(input))
            return "Please type something so I can help you. 😊";

        // 1. Capture name on first execution
        if (_awaitingName)
        {
            user.Name = input;
            _memory.UserName = input;
            _awaitingName = false;
            ActivityLogger.Log($"User registered name: {input}");
            return $"Nice to meet you, {user.Name}! 🔐\n\n" +
                   $"You can ask me about: {string.Join(", ", _keywords.GetAllKeywords())}\n\n" +
                   "Or use the new capabilities:\n" +
                   "🔹 Tasks: Try 'add task', 'view tasks', 'complete task [id]', 'delete task [id]'\n" +
                   "🔹 Quiz: Try 'start quiz' or 'play game'\n" +
                   "🔹 Logs: Try 'show activity log' or 'what have you done for me?'";
        }

        string inputLower = input.ToLower();

        // ── STATE-MACHINE INTERCEPTORS ──
        if (_currentContext == ChatContext.AddTask_AwaitingTitle ||
            _currentContext == ChatContext.AddTask_AwaitingDescription ||
            _currentContext == ChatContext.AddTask_AwaitingReminder)
        {
            return HandleTaskCreationWizard(input);
        }

        if (_currentContext == ChatContext.Quiz_Active)
        {
            return HandleQuizEngine(inputLower);
        }

        // ── TASK ASSISTANT INTENT ROUTING (NLP Simulation) ──
        if (inputLower.Contains("add task") || inputLower.Contains("create a task") || inputLower.Contains("new task"))
        {
            _currentContext = ChatContext.AddTask_AwaitingTitle;
            _tempTask = new CyberTask { Id = new Random().Next(1000, 9999), IsCompleted = false, CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm") };
            return "📝 Let's create a new task. What is the **Title** of this cybersecurity task?";
        }

        if (inputLower.Contains("view task") || inputLower.Contains("show task") || inputLower.Contains("list task") || inputLower == "tasks")
        {
            return DisplayUserTasks();
        }

        if (inputLower.Contains("complete task") || inputLower.Contains("finish task") || inputLower.Contains("done task"))
        {
            return CompleteTaskByInput(inputLower);
        }

        if (inputLower.Contains("delete task") || inputLower.Contains("remove task") || inputLower.Contains("cancel task"))
        {
            return DeleteTaskByInput(inputLower);
        }

        // ── QUIZ INTENT ROUTING (NLP Simulation) ──
        if (inputLower.Contains("start quiz") || inputLower.Contains("play quiz") || inputLower.Contains("quiz game") || inputLower.Contains("play game"))
        {
            ActivityLogger.Log("Quiz system initialized.");
            _activeQuizQuestions = _quizManager.GetQuestions();
            _currentQuizIndex = 0;
            _quizScore = 0;
            _currentContext = ChatContext.Quiz_Active;

            return "🎯 **Cybersecurity Mini-Game Initialized!**\n" +
                   "Answer by typing the full option text or the matching option text accurately.\n\n" +
                   RenderCurrentQuestion();
        }

        // ── ACTIVITY LOG INTENT ROUTING (NLP Simulation) ──
        if (inputLower.Contains("show activity log") || inputLower.Contains("view log") || inputLower.Contains("what have you done for me") || inputLower.Contains("display log"))
        {
            return DisplayActivityLog(showFullHistory: false);
        }

        if (inputLower.Contains("show more logs") || inputLower.Contains("view full log") || inputLower.Contains("display full history"))
        {
            return DisplayActivityLog(showFullHistory: true);
        }

        // ── PART 2: Original Keyword / Follow-Up Logic ──
        if ((inputLower.Contains("more") || inputLower.Contains("tell me more") || inputLower.Contains("explain more")) && _lastTopic != "")
        {
            string followUp = _keywords.GetResponse(_lastTopic);
            return $"Here's more on {_lastTopic}, {_memory.UserName}:\n\n{followUp}";
        }

        Sentiment detectedMood = _sentiment.Detect(inputLower);
        string sentimentOpener = _sentiment.GetSentimentResponse(detectedMood);
        string keywordResponse = _keywords.GetResponse(inputLower);

        if (keywordResponse != null)
        {
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
            string response = "";
            if (!string.IsNullOrEmpty(sentimentOpener)) response += sentimentOpener + "\n\n";
            if (!string.IsNullOrEmpty(personalOpener)) response += personalOpener + "\n\n";
            response += keywordResponse;
            response += "\n\nType 'tell me more' if you want to know more about this topic!";
            return response;
        }

        if (inputLower.Contains("how are you"))
            return $"I'm running at full capacity, {_memory.UserName}! 💻 Ready to keep you cyber-safe. How can I help?";

        if (inputLower.Contains("what can you do") || inputLower.Contains("help") || inputLower.Contains("purpose"))
            return $"I can help you with cybersecurity topics, {_memory.UserName}!\n\n" +
                   $"Try asking about: {string.Join(", ", _keywords.GetAllKeywords())}\n\n" +
                   "Or interact with your tasks and testing engine using conversational text commands!";

        if (inputLower.Contains("bye") || inputLower.Contains("goodbye") || inputLower.Contains("exit"))
            return $"Stay safe online, {_memory.UserName}! 🔐 Goodbye!";

        // ── FALLBACK ──
        var fallbacks = new List<string>
        {
            $"I didn't quite catch that context, {_memory.UserName}. Try rephrasing or ask for 'help' to see functional intents!",
            $"I didn't quite get that. Try rephrasing or ask me about a cybersecurity topic, {_memory.UserName}!"
        };
        return fallbacks[new Random().Next(fallbacks.Count)];
    }

    // ── TASK WIZARD LOGIC ──
    private string HandleTaskCreationWizard(string textInput)
    {
        if (_currentContext == ChatContext.AddTask_AwaitingTitle)
        {
            _tempTask.Title = textInput;
            _currentContext = ChatContext.AddTask_AwaitingDescription;
            return "📝 Title captured. Now, input the **Description** of what needs to be accomplished:";
        }
        if (_currentContext == ChatContext.AddTask_AwaitingDescription)
        {
            _tempTask.Description = textInput;
            _currentContext = ChatContext.AddTask_AwaitingReminder;
            return "⏰ Description captured. Provide an optional **Reminder Date/Time** (or type 'none'):";
        }
        if (_currentContext == ChatContext.AddTask_AwaitingReminder)
        {
            _tempTask.Reminder = textInput.ToLower() == "none" ? "No reminder set" : textInput;
            _taskManager.AddTask(_tempTask);
            _currentContext = ChatContext.Normal;
            return $"✅ **Task Successfully Generated and Saved!**\n\n🆔 **ID:** {_tempTask.Id}\n📌 **Title:** {_tempTask.Title}\n📖 **Description:** {_tempTask.Description}\n⏰ **Reminder:** {_tempTask.Reminder}";
        }
        return "Task error structural disruption occurred.";
    }

    private string DisplayUserTasks()
    {
        var tasks = _taskManager.GetTasks();
        if (tasks == null || tasks.Count == 0)
            return "📭 You currently have no outstanding tasks in your profile tracking storage repository.";

        string rendering = "📋 **YOUR CURRENT CYBERSECURITY TASKS**\n" + new string('─', 40) + "\n";
        foreach (var task in tasks)
        {
            string flag = task.IsCompleted ? "✅ [COMPLETED]" : "❌ [INCOMPLETE]";
            rendering += $"🆔 **ID:** {task.Id} | {flag}\n📌 **Title:** {task.Title}\n📖 **Desc:** {task.Description}\n⏰ **Alert:** {task.Reminder}\n" + new string('─', 40) + "\n";
        }
        return rendering;
    }

    private string CompleteTaskByInput(string inputLower)
    {
        int id = ExtractIdFromInput(inputLower);
        if (id == -1) return "❌ Could not parse valid task structure ID. Please include a valid numerical digits referencing target task. (e.g., 'complete task 1234')";

        var matchingTask = _taskManager.GetTasks().Find(t => t.Id == id);
        if (matchingTask == null) return $"❌ No tracking profile task matching ID: {id} could be verified.";

        _taskManager.CompleteTask(id);
        return $"✅ Completed target ID entry verification profile: **{matchingTask.Title}** updated to completed structure status.";
    }

    private string DeleteTaskByInput(string inputLower)
    {
        int id = ExtractIdFromInput(inputLower);
        if (id == -1) return "❌ Action blocked: Target task ID parsing missing. Try referencing like: 'delete task 1234'";

        var matchingTask = _taskManager.GetTasks().Find(t => t.Id == id);
        if (matchingTask == null) return $"❌ Delete structural failure: ID {id} records not present.";

        _taskManager.DeleteTask(id);
        return $"🗑 Task data array index item **{matchingTask.Title}** deleted permanently out of disk runtime records.";
    }

    private int ExtractIdFromInput(string text)
    {
        string[] metrics = text.Split(' ');
        foreach (var check in metrics)
        {
            if (int.TryParse(check, out int result)) return result;
        }
        return -1;
    }

    // ── QUIZ LOGIC INTERACTION ENGINE ──
    private string RenderCurrentQuestion()
    {
        var activeQ = _activeQuizQuestions[_currentQuizIndex];
        string textOutput = $"❓ **Question {_currentQuizIndex + 1} of {_activeQuizQuestions.Count}:**\n**{activeQ.Question}**\n\n";
        for (int i = 0; i < activeQ.Options.Length; i++)
        {
            textOutput += $"🔹 {activeQ.Options[i]}\n";
        }
        return textOutput;
    }

    private string HandleQuizEngine(string inputLower)
    {
        var activeQ = _activeQuizQuestions[_currentQuizIndex];
        int correctIndex = activeQ.CorrectAnswerIndex;
        string correctText = activeQ.Options[correctIndex].ToLower();

        bool isCorrect = inputLower.Contains(correctText) || inputLower == correctText;

        string feedString = "";
        if (isCorrect)
        {
            _quizScore++;
            feedString = "🎯 **Brilliant! Correct response verified.**\n";
        }
        else
        {
            feedString = $"❌ **Incorrect response.**\n💡 *Correct structural path was:* {activeQ.Options[correctIndex]}\n";
        }

        // Hardcoded custom explanations to fit criteria requirements
        feedString += GetQuestionExplanation(_currentQuizIndex) + "\n\n";
        ActivityLogger.Log($"Quiz Q{_currentQuizIndex + 1} finalized answer. Correct: {isCorrect}");

        _currentQuizIndex++;

        if (_currentQuizIndex >= _activeQuizQuestions.Count)
        {
            _currentContext = ChatContext.Normal;
            string finalOverview = $"{feedString}🏁 **Quiz Complete, {_memory.UserName}!**\n" +
                                   $"🏆 Your total score breakdown metrics evaluate to: **{_quizScore} / {_activeQuizQuestions.Count}**\n\n";
            if (_quizScore == _activeQuizQuestions.Count) finalOverview += "🥇 Master level! Your cybersecurity architecture resilience is fully compliant.";
            else if (_quizScore >= 3) finalOverview += "🥈 Good status capacity, keep updating your security policy awareness structures.";
            else finalOverview += "🥉 Operational Warning level parameters hit. Recommend further domain reading revisions.";

            ActivityLogger.Log($"Quiz completed. Final performance rating metrics: {_quizScore}/{_activeQuizQuestions.Count}");
            return finalOverview;
        }

        feedString += "Press forward to next item...\n" + new string('─', 35) + "\n\n";
        feedString += RenderCurrentQuestion();
        return feedString;
    }

    private string GetQuestionExplanation(int index)
    {
        switch (index)
        {
            case 0: return "ℹ Phishing methods rely primarily on malicious social engineered emails designed intentionally to mimic corporate entities to harvest security tokens or credentials.";
            case 1: return "ℹ Complexity metrics are extended when random symbols, alphanumeric integers, and high casing parameters block typical dictionary brute-force decryption modules.";
            case 2: return "ℹ Virtual Private Networks tunnel active web vectors securely over shared networking lines hiding original host operational IP nodes.";
            case 3: return "ℹ Malware operates broadly as any compilation code architecture written deliberately to interrupt host configurations or leak client parameters.";
            case 4: return "ℹ Two-factor security checks verification identities outside base values by demanding an asynchronous short-term token from local authenticators.";
            default: return "ℹ Retain security structural awareness principles safely.";
        }
    }

    // ── ACTIVITY LOG FORMATTED DISPATCHER ──
    private string DisplayActivityLog(bool showFullHistory)
    {
        var primaryLogs = ActivityLogger.GetLogs();
        if (primaryLogs == null || primaryLogs.Count == 0)
            return "📊 Activity track profiles remain blank. No structural interactions tracked inside this active runtime context.";

        int maxEntriesToShow = showFullHistory ? primaryLogs.Count : 5;
        int standardStartRange = Math.Max(0, primaryLogs.Count - maxEntriesToShow);

        string render = $"📊 **SYSTEM ACTIVITY HISTORY LOGS (Showing last {Math.Min(maxEntriesToShow, primaryLogs.Count)} items)**\n" +
                        $"*Type 'show more logs' or 'view full log' to inspect complete system metrics history.*\n" + new string('═', 50) + "\n";

        for (int i = primaryLogs.Count - 1; i >= standardStartRange; i--)
        {
            render += $"{primaryLogs[i]}\n";
        }
        return render;
    }
}