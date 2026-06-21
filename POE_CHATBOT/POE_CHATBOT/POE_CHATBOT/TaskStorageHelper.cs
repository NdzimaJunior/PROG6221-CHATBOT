using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

public static class TaskStorageHelper
{
    private static string FilePath = "tasks.json";

    public static void SaveTasks(List<CyberTask> tasks)
    {
        string json =
            JsonConvert.SerializeObject(tasks, Formatting.Indented);

        File.WriteAllText(FilePath, json);
    }

    public static List<CyberTask> LoadTasks()
    {
        if (!File.Exists(FilePath))
            return new List<CyberTask>();

        string json = File.ReadAllText(FilePath);

        return JsonConvert.DeserializeObject<List<CyberTask>>(json)
               ?? new List<CyberTask>();
    }
}