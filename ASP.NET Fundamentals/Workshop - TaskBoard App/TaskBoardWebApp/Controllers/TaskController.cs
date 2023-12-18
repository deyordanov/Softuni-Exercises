using Microsoft.AspNetCore.Mvc;

namespace TaskBoardApp.Controllers;

using System.Security.Claims;
using Data.Models;
using Extensions;
using Microsoft.AspNetCore.Authorization;
using Services.Contracts;
using Web.ViewModels.Board;
using Web.ViewModels.Task;
using Task = System.Threading.Tasks.Task;

[Authorize]
public class TaskController : Controller
{
    private readonly IBoardService boardService;
    private readonly ITaskService taskService;

    public TaskController(IBoardService boardService, ITaskService taskService)
    {
        this.boardService = boardService;
        this.taskService = taskService;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        TaskFormModel taskModel = new TaskFormModel()
        {
            Boards = await this.boardService.AllForDropdownAsync()
        };

        return View(taskModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TaskFormModel taskModel)
    {
        if (!ModelState.IsValid)
        {
            taskModel.Boards = await this.boardService.AllForDropdownAsync();

            return View(taskModel);
        }

        bool boardExists = await this.boardService.ExistsByIdAsync((taskModel.BoardId));
        if (!boardExists)
        {
            ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist!");
        }

        string ownerId = User.GetId();
        await this.taskService.AddAsync(ownerId, taskModel);

        return RedirectToAction("All", "Board");
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        try
        {
            TaskDetailsViewModel taskModel = await this
                .taskService
                .GetByIdForDetailsAsync(id);

            return View(taskModel);
        }
        catch (Exception e)
        {
            return this.RedirectToAction("All", "Board");
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        Data.Models.Task? task = await this
            .taskService
            .GetByIdAsync(id);

        if (task == null)
        {
            return BadRequest();
        }

        string ownerId = User.GetId();
        TaskFormModel taskModel = new TaskFormModel()
        {
            Title = task.Title,
            Description = task.Description,
            BoardId = task.BoardId,
            Boards = await this.boardService.AllForDropdownAsync(),
        };

        return View(taskModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, TaskFormModel taskModel)
    {
        if (!ModelState.IsValid)
        {
            taskModel.Boards = await this.boardService.AllForDropdownAsync();

            return View(taskModel);
        }

        Data.Models.Task? task = await this
            .taskService
            .GetByIdAsync(id);

        if (task == null)
        {
            return BadRequest();
        }

        string ownerId = User.GetId();
        if (ownerId != task?.User?.Id)
        {
            return Unauthorized();
        }

        bool boardExists = await this.boardService.ExistsByIdAsync(taskModel.BoardId);
        if (!boardExists)
        {
            ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist");
        }

        await this.taskService.EditAsync(task, taskModel);

        return RedirectToAction("All", "Board");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        Data.Models.Task? task = await this.taskService.GetByIdAsync(id);
        if (task == null)
        {
            return BadRequest();
        }

        string ownerId = User.GetId();
        if (ownerId != task.OwnerId)
        {
            return Unauthorized();
        }

        TaskDeleteViewModel taskModel = new TaskDeleteViewModel()
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
        };

        return View(taskModel);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id, TaskDeleteViewModel taskModel)
    {
        Data.Models.Task? task = await this.taskService.GetByIdAsync(id);
        if (task == null)
        {
            return BadRequest();
        }

        string ownerId = User.GetId();
        if (ownerId != task.OwnerId)
        {
            return Unauthorized();
        }

        await this.taskService.DeleteAsync(task);

        return RedirectToAction("All", "Board");
    }
}