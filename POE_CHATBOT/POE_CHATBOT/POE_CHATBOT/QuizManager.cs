using System.Collections.Generic;

public class QuizManager
{
    private List<QuizQuestion> _questions;

    public QuizManager()
    {
        _questions = new List<QuizQuestion>()
        {
            new QuizQuestion
            {
                Question = "What is phishing?",
                Options = new string[] { "A cyberattack using fake messages", "A firewall", "An antivirus", "A VPN" },
                CorrectAnswerIndex = 0
            },
            new QuizQuestion
            {
                Question = "Which password is strongest?",
                Options = new string[] { "123456", "Password", "P@ssw0rd123!", "abcdef" },
                CorrectAnswerIndex = 2
            },
            new QuizQuestion
            {
                Question = "What does VPN stand for?",
                Options = new string[] { "Virtual Private Network", "Verified Public Network", "Virtual Public Node", "Variable Protection Network" },
                CorrectAnswerIndex = 0
            },
            new QuizQuestion
            {
                Question = "What is malware?",
                Options = new string[] { "Helpful software", "Malicious software", "Hardware damage", "Internet speed" },
                CorrectAnswerIndex = 1
            },
            new QuizQuestion
            {
                Question = "Why use two-factor authentication?",
                Options = new string[] { "Extra security layer", "Faster internet", "More storage", "Better graphics" },
                CorrectAnswerIndex = 0
            },
            // --- ADDED EXTRA METRIC QUESTIONS FOR THE >10 CRITERIA ---
            new QuizQuestion
            {
                Question = "What is Social Engineering?",
                Options = new string[] { "Writing computer code", "Manipulating humans into giving up secrets", "Upgrading router hardware", "Setting up databases" },
                CorrectAnswerIndex = 1
            },
            new QuizQuestion
            {
                Question = "If you receive a strange email from your bank asking you to reset your PIN immediately, what is this?",
                Options = new string[] { "Routine Maintenance", "A Phishing/Social Engineering scam attempt", "An OS updates alert", "Encryption protocol" },
                CorrectAnswerIndex = 1
            },
            new QuizQuestion
            {
                Question = "Which protocol makes website browsing traffic safe and encrypted?",
                Options = new string[] { "HTTP", "FTP", "HTTPS", "SMTP" },
                CorrectAnswerIndex = 2
            },
            new QuizQuestion
            {
                Question = "What is a Trojan horse in software engineering context?",
                Options = new string[] { "A fast compiler", "Malware disguised as legitimate software", "A server cooling rack", "A database secondary key" },
                CorrectAnswerIndex = 1
            },
            new QuizQuestion
            {
                Question = "What is safe practice when using public coffee shop Wi-Fi networks?",
                Options = new string[] { "Leave sharing completely open", "Do banking without security shields", "Use a secure encrypted VPN tunnel", "Turn off all Windows firewalls" },
                CorrectAnswerIndex = 2
            },
            new QuizQuestion
            {
                Question = "What does spyware do if it infects your machine parameters?",
                Options = new string[] { "Speeds up hardware rendering", "Secretly tracks keystrokes and harvests private user logs", "Deletes backup JSON configurations files automatically", "Optimizes data serialization paths" },
                CorrectAnswerIndex = 1
            }
        };
    }

    public List<QuizQuestion> GetQuestions()
    {
        return _questions;
    }
}