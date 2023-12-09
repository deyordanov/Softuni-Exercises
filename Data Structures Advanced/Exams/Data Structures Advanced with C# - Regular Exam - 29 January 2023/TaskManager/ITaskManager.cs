using System.Collections.Generic;

namespace Exam.TaskManager
{
    public interface ITaskManager
    {
        void AddTask(Task task);

        bool Contains(Task task);

        int Size();

        Task GetTask(string taskId);

        void DeleteTask(string taskId);

        Task ExecuteTask();

        void RescheduleTask(string taskId);

        IEnumerable<Task> GetDomainTasks(string domain);

        IEnumerable<Task> GetTasksInEETRange(int lowerBound, int upperBound);

        IEnumerable<Task> GetAllTasksOrderedByEETThenByName();
    }
}
