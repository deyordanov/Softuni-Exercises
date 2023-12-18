namespace TaskBoardApp.Services.Task;

using Contracts;
using Data;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.Task;
using Task = System.Threading.Tasks.Task;

public class TaskService : ITaskService
{
    private readonly ApplicationDbContext dbContext;

    public TaskService(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddAsync(string ownerId, TaskFormModel taskModel)
    {
        Data.Models.Task task = new Data.Models.Task()
        {
            Title = taskModel.Title,
            Description = taskModel.Description,
            CreatedOn = DateTime.Now,
            BoardId = taskModel.BoardId,
            OwnerId = ownerId,
        };

        await dbContext.Tasks.AddAsync(task);
        await dbContext.SaveChangesAsync();
    }

    public async Task<TaskDetailsViewModel> GetByIdForDetailsAsync(int id)
    {
        TaskDetailsViewModel taskToReturn = await this
            .dbContext
            .Tasks
            .Select(t => new TaskDetailsViewModel()
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Owner = t.User.UserName,
                Board = t.Board.Name,
                CreatedOn = t.CreatedOn.ToString("f"),
            })
            .FirstAsync(t => t.Id == id);

        return taskToReturn;
    }

    public async Task<Data.Models.Task?> GetByIdAsync(int id)
    {
        Data.Models.Task? task = await this
            .dbContext
            .Tasks
            .Include(t => t.User)
            .FirstAsync(t => t.Id == id);

        return task;
    }

    public async Task EditAsync(Data.Models.Task task, TaskFormModel taskModel)
    {
        task.Title = taskModel.Title;
        task.Description = taskModel.Description;
        task.BoardId = taskModel.BoardId;

        await this.dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Data.Models.Task task)
    {
        this
            .dbContext
            .Tasks
            .Remove(task);

        await this.dbContext.SaveChangesAsync();
    }
}