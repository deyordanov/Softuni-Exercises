namespace TaskBoardApp.Data.Seeders;

using Models;

public class TaskSeeder
{
    internal IEnumerable<Task> GenerateTasks()
    {
        return new HashSet<Task>()
        {
            new Task()
            {
                Id = 1,
                Title = "Improve CSS styles",
                Description = "Implement better styling for all public pages",
                CreatedOn = DateTime.Now.AddDays(-200),
                OwnerId = "0ecabc3f-05c6-4a08-97c3-36963ceb882f",
                BoardId = 1,
            },
            new Task()
            {
                Id = 2,
                Title = "Android Client App",
                Description = "Create Android client app for the TaskBoard RESTful API",
                CreatedOn = DateTime.Now.AddMonths(-5),
                OwnerId = "0ecabc3f-05c6-4a08-97c3-36963ceb882f",
                BoardId = 1,
            },
            new Task()
            {
                Id = 3,
                Title = "Desktop Client App",
                Description = "Create Windows Forms desktop app client for the TaskBoard RESTful API",
                CreatedOn = DateTime.Now.AddMonths(-1),
                OwnerId = "0ecabc3f-05c6-4a08-97c3-36963ceb882f",
                BoardId = 2,
            },
            new Task()
            {
                Id = 4,
                Title = "Create Tasks",
                Description = "Implement [Create Task] page for adding new tasks",
                CreatedOn = DateTime.Now.AddYears(-1),
                OwnerId = "0ecabc3f-05c6-4a08-97c3-36963ceb882f",
                BoardId = 3,
            },
        };
    }
}