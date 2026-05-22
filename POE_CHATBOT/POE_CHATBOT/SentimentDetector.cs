using System;
using System.Collections.Generic;

public enum Sentiment
{
    Neutral,
    Worried,
    Curious,
    Frustrated,
    Happy
}

public class SentimentDetector
{
    private Dictionary<Sentiment, List<string>> _triggerWords;

    public SentimentDetector()
    {
        _triggerWords = new Dictionary<Sentiment, List<string>>
        {
            {
                Sentiment.Worried, new List<string>
                {
                    "worried", "scared", "afraid", "anxious", "nervous",
                    "unsafe", "concerned", "panicking", "fear", "terrified"
                }
            },
            {
                Sentiment.Curious, new List<string>
                {
                    "curious", "wondering", "interested", "want to know",
                    "how does", "how do", "what is", "tell me about", "explain"
                }
            },
            {
                Sentiment.Frustrated, new List<string>
                {
                    "frustrated", "annoyed", "confused", "don't understand",
                    "doesn't make sense", "lost", "stuck", "angry", "useless"
                }
            },
            {
                Sentiment.Happy, new List<string>
                {
                    "great", "thanks", "helpful", "awesome", "love it",
                    "amazing", "perfect", "brilliant", "good job", "thank you"
                }
            }
        };
    }

    // Detects the sentiment of the input string
    public Sentiment Detect(string input)
    {
        input = input.ToLower();

        foreach (var entry in _triggerWords)
        {
            foreach (var trigger in entry.Value)
            {
                if (input.Contains(trigger))
                    return entry.Key;
            }
        }

        return Sentiment.Neutral;
    }

    // Returns an empathetic opening sentence based on detected sentiment
    public string GetSentimentResponse(Sentiment sentiment)
    {
        switch (sentiment)
        {
            case Sentiment.Worried:
                return "I can hear that you're feeling worried — that's completely understandable. Let me help you with some useful info:";

            case Sentiment.Curious:
                return "Great question! I love the curiosity — here's what you should know:";

            case Sentiment.Frustrated:
                return "I get it, this stuff can feel overwhelming. Let me break it down for you:";

            case Sentiment.Happy:
                return "Glad to hear it! 😊 Here's a little more to keep you informed:";

            default:
                return ""; // Neutral — no opener needed
        }
    }
}