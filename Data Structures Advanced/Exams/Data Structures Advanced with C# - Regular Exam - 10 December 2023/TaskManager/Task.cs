namespace TaskManager
{
    using System.Collections.Generic;

    public class Task
    {
        public Task()
        {
            this.Dependencies = new HashSet<Task>();
            this.Dependants = new HashSet<Task>();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Assignee { get; set; }

        public int Priority { get; set; }

        public HashSet<Task> Dependencies { get; set; }

        public HashSet<Task> Dependants { get; set; }

        public override string ToString()
        {
            return this.Title;
        }
    }
}