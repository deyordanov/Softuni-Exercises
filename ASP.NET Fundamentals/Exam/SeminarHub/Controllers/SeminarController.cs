using Microsoft.AspNetCore.Mvc;

namespace SeminarHub.Controllers;

using Data.Models;
using Extensions.ClaimsPrincipal;
using Microsoft.AspNetCore.Authorization;
using Services.Contracts;
using System.Globalization;
using ViewModels.Category;
using ViewModels.Seminar;
using static Common.Constants.ValidationConstants.Seminar;
using static Common.Constants.ValidationMessages.Seminar;

[Authorize]
public class SeminarController : Controller
{
    private readonly ISeminarService _seminarService;
    private readonly ICategoryService _categoryService;

    public SeminarController(
        ISeminarService seminarService, 
        ICategoryService categoryService)
    {
        _seminarService = seminarService;
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        CreateSeminarViewModel seminarModel = await this
            ._seminarService
            .GetSeminarForCreateAsync();

        return View(seminarModel);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateSeminarViewModel seminarModel)
    {
        if (!DateTime.TryParseExact(
                seminarModel.DateAndTime,
                DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime dateAndTime))
        {
            ModelState
                .AddModelError(nameof(seminarModel.DateAndTime), string.Format(SeminarDateAndTimeInvalidDateMessage, DateFormat));
        }

        if (!ModelState.IsValid)
        {
            IEnumerable<CategoryViewModel> allCategories = await this
                ._categoryService
                .GetAllCategoriesAsync();

            seminarModel.Categories = allCategories.ToList();

            return View(seminarModel);
        }

        seminarModel.OrganizerId = this.GetUserId();

        await this
            ._seminarService
            .CreateSeminarAsync(seminarModel, dateAndTime);

        return RedirectToAction(nameof(All), nameof(Seminar));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        EditSeminarViewModel seminarModel = await this
            ._seminarService
            .GetSeminarForEditAsync(id);

        if (!this.IsOwner(seminarModel.OrganizerId))
        {
            return RedirectToAction(nameof(All), nameof(Seminar));
        }

        return View(seminarModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditSeminarViewModel seminarModel)
    {
        if (!DateTime.TryParseExact(
                seminarModel.DateAndTime,
                DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime dateAndTime))
        {
            ModelState
                .AddModelError(nameof(seminarModel.DateAndTime), string.Format(SeminarDateAndTimeInvalidDateMessage, DateFormat));
        }

        if (!ModelState.IsValid)
        {
            IEnumerable<CategoryViewModel> allCategories = await this
                ._categoryService
                .GetAllCategoriesAsync();

            seminarModel.Categories = allCategories.ToList();

            return View(seminarModel);
        }

        seminarModel.OrganizerId = this.GetUserId();

        await this
            ._seminarService
            .EditSeminarAsync(seminarModel, dateAndTime);

        return RedirectToAction(nameof(All), nameof(Seminar));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        DetailsSeminarViewModel seminarModel = await this
            ._seminarService
            .GetSeminarForDetailsAsync(id);

        return View(seminarModel);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        DeleteSeminarViewModel seminarModel = await this
            ._seminarService
            .GetSeminarForDeleteAsync(id);

        if (!this.IsOwner(seminarModel.OrganizerId))
        {
            return RedirectToAction(nameof(All), nameof(Seminar));
        }

        return View(seminarModel);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(DeleteSeminarViewModel seminarModel)
    {
        await this
            ._seminarService
            .DeleteSeminarByIdAsync(seminarModel.Id);

        return RedirectToAction(nameof(All), nameof(Seminar));
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        IEnumerable<SeminarViewModel> allSeminars = await this
            ._seminarService
            .GetAllSeminarsWithFilterAsync(null);

        return View(allSeminars);
    }

    [HttpGet]
    public async Task<IActionResult> Joined()
    {
        string userId = this.GetUserId();

        IEnumerable<SeminarViewModel> allSeminars = await this
            ._seminarService
            .GetAllSeminarsWithFilterAsync(s => s.SeminarsParticipants
                .Any(sp => sp.ParticipantId == userId));

        return View(allSeminars);
    }

    [HttpPost]
    public async Task<IActionResult> Join(int id)
    {
        string userId = this.GetUserId();

        bool userWasAlreadyAdded = await this
            ._seminarService
            .AddUserToSeminarAsync(id, userId);

        return RedirectToAction(userWasAlreadyAdded ? nameof(All) : nameof(Joined));
    }

    [HttpPost]
    public async Task<IActionResult> Leave(int id)
    {
        string userId = this.GetUserId();

        await this._seminarService.RemoveUserFromSeminarAsync(id, userId);

        return RedirectToAction(nameof(Joined));
    }

    private string GetUserId() => User.GetId();

    private bool IsOwner(string ownerId)
    {
        return ownerId == this.GetUserId();
    }
}