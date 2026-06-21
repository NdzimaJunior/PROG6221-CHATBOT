using System.Collections.Generic;
using POE_CHATBOT;

public class TaskManager
{
    private List<CyberTask> _tasks;

    public TaskManager()
    {
        _tasks = TaskStorageHelper.LoadTasks();
    }

    public List<CyberTask> GetTasks()
    {
        return _tasks;
    }

    public void AddTask(CyberTask task)
    {
        _tasks.Add(task);

        TaskStorageHelper.SaveTasks(_tasks);

        ActivityLogger.Log($"Task Added: {task.Title}");
    }

    public void DeleteTask(int id)
    {
        _tasks.RemoveAll(t => t.Id == id);

        TaskStorageHelper.SaveTasks(_tasks);

        ActivityLogger.Log($"Task Deleted: {id}");
    }

    public void CompleteTask(int id)
    {
        var task = _tasks.Find(t => t.Id == id);

        if (task != null)
        {
            task.IsCompleted = true;

            TaskStorageHelper.SaveTasks(_tasks);

            ActivityLogger.Log($"Task Completed: {task.Title}");
        }
    }
}