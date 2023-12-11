using System.Collections.Generic;

namespace TaskManager
{
    public interface IManager
    {
        void AddTask(Task task);

        void RemoveTask(string taskId);

        bool Contains(string taskId);

        Task Get(string taskId);

        int Size();

        void AddDependency(string taskId, string dependentTaskId);

        void RemoveDependency(string taskId, string dependentTaskId);

        IEnumerable<Task> GetDependencies(string taskId);

        IEnumerable<Task> GetDependents(string taskId);
    }
}