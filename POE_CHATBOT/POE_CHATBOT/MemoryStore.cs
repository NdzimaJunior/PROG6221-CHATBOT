using System;
using System.Collections.Generic;

public class MemoryStore
{
    public string UserName { get; set; }
    public string FavouriteTopic { get; set; }

    // General-purpose key-value store for any extra memory needs
    private Dictionary<string, string> _memory = new Dictionary<string, string>();

    // Stores any key-value pair
    public void Store(string key, string value)
    {
        _memory[key.ToLower()] = value;
    }

    // Retrieves a stored value by key, returns null if not found
    public string Recall(string key)
    {
        _memory.TryGetValue(key.ToLower(), out string value);
        return value;
    }

    // Builds a personalised opener using stored name and/or topic
    public string GetPersonalisedOpener()
    {
        if (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(FavouriteTopic))
            return $"As someone interested in {FavouriteTopic}, {UserName}, here's something relevant for you:";

        if (!string.IsNullOrWhiteSpace(UserName))
            return $"Here's something for you, {UserName}:";

        if (!string.IsNullOrWhiteSpace(FavouriteTopic))
            return $"As someone interested in {FavouriteTopic}, here's what you should know:";

        return "";
    }
}