namespace TaskBoardApp.Services.Contracts;

using Web.ViewModels.Task;
using Task = System.Threading.Tasks.Task;

public interface ITaskService
{
    Task AddAsync(string ownerId, TaskFormModel taskModel);

    Task<TaskDetailsViewModel> GetByIdForDetailsAsync(int id);
    Task<Data.Models.Task?> GetByIdAsync(int id);

    Task EditAsync(Data.Models.Task task, TaskFormModel taskModel);

    Task DeleteAsync(Data.Models.Task task);
}