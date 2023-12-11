using System;
using System.Collections.Generic;

namespace TaskManager
{
    using System.Threading;

    public class Manager : IManager
    {
        private Dictionary<string, Task> tasks;

        public Manager()
        {
            this.tasks = new Dictionary<string, Task>();
        }

        public void AddDependency(string taskId, string dependentTaskId)
        {
            if (!this.tasks.ContainsKey(taskId) || !this.tasks.ContainsKey(dependentTaskId))
            {
                throw new ArgumentException();
            }

            Task parent = this.tasks[dependentTaskId];
            Task child = this.tasks[taskId];
            child.Dependencies.Add(parent);
            
            if (this.IsCircularDependencyBfs(parent, child.Id))
            {
                throw new ArgumentException();
            }

            Queue<Task> queue = new Queue<Task>();
            queue.Enqueue(child);

            while (queue.Count > 0)
            {
                Task currentTask = queue.Dequeue();

                foreach (Task dependency in currentTask.Dependants)
                {
                    queue.Enqueue(dependency);
                }

                if (currentTask.Id != parent.Id)
                {
                    currentTask.Dependencies.Add(parent);
                    parent.Dependants.Add(currentTask);
                }
            }
        }


        public bool IsCircularDependencyBfs(Task parent, string childId)
        {
            Queue<Task> queue = new Queue<Task>();
            HashSet<string> visited = new HashSet<string>();

            foreach (Task dependantTask in parent.Dependencies)
            {
                queue.Enqueue(dependantTask);
            }

            while (queue.Count > 0)
            {
                Task currentTask = queue.Dequeue();

                if (visited.Contains(parent.Id))
                {
                    return true;
                }

                visited.Add(currentTask.Id);
                foreach (Task dependentTask in currentTask.Dependencies)
                {
                    queue.Enqueue(dependentTask);
                }
            }

            return false;
        }


        public void AddTask(Task task)
        {
            if (this.tasks.ContainsKey(task.Id))
            {
                throw new ArgumentException();
            }

            this.tasks.Add(task.Id, task);
        }

        public bool Contains(string taskId) => this.tasks.ContainsKey(taskId);

        public Task Get(string taskId)
        {
            if (!this.tasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            return this.tasks[taskId];
        }

        public IEnumerable<Task> GetDependencies(string taskId)
        {
            if (!this.tasks.ContainsKey(taskId))
            {
                return new List<Task>();
            }

            Task task = this.tasks[taskId];

            return task.Dependencies;
        }

        public IEnumerable<Task> GetDependents(string taskId)
        {
            if (!this.tasks.ContainsKey(taskId))
            {
                return new List<Task>();
            }

            Task task = this.tasks[taskId];

            return task.Dependants;
        }

        public void RemoveDependency(string taskId, string dependentTaskId)
        {
            if (!this.tasks.ContainsKey(taskId) || !this.tasks.ContainsKey(dependentTaskId))
            {
                throw new ArgumentException();
            }

            Task parent = this.tasks[taskId];
            Task child = this.tasks[dependentTaskId];

            if (!parent.Dependencies.Contains(child))
            {
                throw new ArgumentException();
            }

            Queue<Task> queue = new Queue<Task>();
            queue.Enqueue(parent);

            while (queue.Count > 0)
            {
                Task curr = queue.Dequeue();

                curr.Dependencies.Remove(child);

                foreach (Task dep in curr.Dependants)
                {
                    queue.Enqueue(dep);
                }
            }
            child.Dependants.Remove(parent);
        }

        public void RemoveTask(string taskId)
        {
            if (!this.tasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            Task task = this.tasks[taskId];

            foreach (Task dependant in task.Dependants)
            {
                dependant.Dependencies.Remove(task);
            }

            foreach (Task dependency in task.Dependencies)
            {
                dependency.Dependants.Remove(task);
            }

            this.tasks.Remove(taskId);
        }

        public int Size() => this.tasks.Count;
    }
}