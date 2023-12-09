using System;
using System.Collections.Generic;

namespace Exam.TaskManager
{
    using System.Linq;

    public class TaskManager : ITaskManager
    {
        private Dictionary<string, Task> allTasksById;
        private Dictionary<string, Task> executedTasks;
        private LinkedList<Task> pendingTasks;

        public TaskManager()
        {
            this.allTasksById = new Dictionary<string, Task>();
            this.executedTasks = new Dictionary<string, Task>();
            this.pendingTasks = new LinkedList<Task>();
        }
        
        public void AddTask(Task task)
        {
            this.allTasksById.Add(task.Id, task);
            this.pendingTasks.AddLast(task);
        }

        public bool Contains(Task task) => this.allTasksById.ContainsKey(task.Id);

        public void DeleteTask(string taskId)
        {
            if (!this.allTasksById.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            Task taskToDelete = this.allTasksById[taskId];

            this.allTasksById.Remove(taskId);
            if (this.executedTasks.ContainsKey(taskToDelete.Id))
            {
                this.executedTasks.Remove(taskToDelete.Id);
            }
            else
            {
                this.pendingTasks.Remove(taskToDelete);
            }
        }

        public Task ExecuteTask()
        {
            if (this.pendingTasks.Count == 0)
            {
                throw new ArgumentException();
            }

            Task taskToExecute = this.pendingTasks.First!.Value;

            this.pendingTasks.RemoveFirst();
            this.executedTasks.Add(taskToExecute.Id, taskToExecute);

            return taskToExecute;
        }

        public IEnumerable<Task> GetAllTasksOrderedByEETThenByName()
        {
            return this.allTasksById
                .Select(kvp => kvp.Value)
                .OrderByDescending(t => t.EstimatedExecutionTime)
                .ThenBy(t => t.Name.Length);
        }

        public IEnumerable<Task> GetDomainTasks(string domain)
        {
            List<Task> tasks = pendingTasks.Where(t => t.Domain == domain).ToList();

            if (tasks.Count == 0)
            {
                throw new ArgumentException();
            }

            return tasks;
        }

        public Task GetTask(string taskId)
        {
            if (!this.allTasksById.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            return this.allTasksById[taskId];
        }

        public IEnumerable<Task> GetTasksInEETRange(int lowerBound, int upperBound)
        {
            return this.pendingTasks
                .Where(t => t.EstimatedExecutionTime >= lowerBound && t.EstimatedExecutionTime <= upperBound);
        }

        public void RescheduleTask(string taskId)
        {
            if (!this.executedTasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            Task taskToReschedule = this.executedTasks[taskId];

            this.executedTasks.Remove(taskId);
            this.pendingTasks.AddLast(taskToReschedule);
        }

        public int Size() => this.allTasksById.Count;
    }
}
