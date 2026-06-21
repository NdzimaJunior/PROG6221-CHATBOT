using System;
using System.Collections.Generic;

public static class ActivityLogger
{
    private static List<string> _logs = new List<string>();

    public static void Log(string action)
    {
        string entry = $"[{DateTime.Now:HH:mm:ss}] {action}";
        _logs.Add(entry);
    }

    public static List<string> GetLogs()
    {
        return _logs;
    }
}