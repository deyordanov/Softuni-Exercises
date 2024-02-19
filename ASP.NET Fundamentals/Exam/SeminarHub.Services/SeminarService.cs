namespace SeminarHub.Services;

using Common.Exceptions;
using Contracts;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ViewModels.Category;
using ViewModels.Seminar;
using static Common.Constants.ExceptionMessages.Seminar;
using static Common.Constants.ExceptionMessages.SeminarParticipant;
using static Common.Constants.ValidationConstants.Seminar;


public class SeminarService : ISeminarService
{
    private const string SeminarsParticipantsProperty = "SeminarsParticipants";
    private const string CategoryProperty = "Category";
    private const string OrganizerProperty = "Organizer";

    private readonly SeminarHubDbContext _dbContext;
    private readonly ICategoryService _categoryService;

    public SeminarService(
        SeminarHubDbContext dbContext, 
        ICategoryService categoryService)
    {
        _dbContext = dbContext;
        _categoryService = categoryService;
    }

    public async Task<CreateSeminarViewModel> GetSeminarForCreateAsync()
    {
        IEnumerable<CategoryViewModel> allCategories = await this
            ._categoryService
            .GetAllCategoriesAsync();

        return new CreateSeminarViewModel()
        {
            Categories = allCategories.ToList(),
        };
    }

    public async Task<EditSeminarViewModel> GetSeminarForEditAsync(int seminarId)
    {
        Seminar seminar = await this
            .GetSeminarByIdAsync(seminarId, false, null);

        IEnumerable<CategoryViewModel> allCategories = await this
            ._categoryService
            .GetAllCategoriesAsync();

        return new EditSeminarViewModel()
        {
            DateAndTime = seminar.DateAndTime.ToString(DateFormat),
            Details = seminar.Details,
            Duration = seminar.Duration,
            Lecturer = seminar.Lecturer,
            Topic = seminar.Topic,
            CategoryId = seminar.CategoryId,
            OrganizerId = seminar.OrganizerId,
            Id = seminar.Id,
            Categories = allCategories.ToList(),
        };
    }

    public async Task<DetailsSeminarViewModel> GetSeminarForDetailsAsync(int seminarId)
    {
        Seminar seminar = await this
            .GetSeminarByIdAsync(seminarId, false, new [] { CategoryProperty, OrganizerProperty });

        return new DetailsSeminarViewModel
        {
            DateAndTime = seminar.DateAndTime.ToString(DateFormat),
            Details = seminar.Details,
            Duration = seminar.Duration,
            Lecturer = seminar.Lecturer,
            Topic = seminar.Topic,
            CategoryId = seminar.CategoryId,
            OrganizerId = seminar.OrganizerId,
            Id = seminar.Id,
            Category = seminar.Category.Name,
            Organizer = seminar.Organizer.UserName,
        };
    }

    public async Task<DeleteSeminarViewModel> GetSeminarForDeleteAsync(int seminarId)
    {
        Seminar seminar = await this
            .GetSeminarByIdAsync(seminarId, false, null);

        return new DeleteSeminarViewModel
        {
            DateAndTime = seminar.DateAndTime.ToString(DateFormat),
            Topic = seminar.Topic,
            Id = seminar.Id,
            OrganizerId = seminar.OrganizerId,
        };
    }

    public async Task CreateSeminarAsync(CreateSeminarViewModel seminarModel, DateTime dateAndTime)
    {
        Seminar seminar = new Seminar
        {
            DateAndTime = dateAndTime,
            Details = seminarModel.Details,
            Duration = seminarModel.Duration,
            Lecturer = seminarModel.Lecturer,
            Topic = seminarModel.Topic,
            CategoryId = seminarModel.CategoryId,
            OrganizerId = seminarModel.OrganizerId,
        };

        _dbContext.Seminars.Add(seminar);

        await _dbContext.SaveChangesAsync();

        await _dbContext.SeminarsParticipants.AddAsync(new SeminarParticipant
        {
            ParticipantId = seminar.OrganizerId,
            SeminarId = seminar.Id,
        });

        await _dbContext.SaveChangesAsync();
    }


    public async Task EditSeminarAsync(EditSeminarViewModel seminarModel, DateTime dateAndTime)
    {
        Seminar seminar = await this
            .GetSeminarByIdAsync(seminarModel.Id, true, null);

        seminar.DateAndTime = dateAndTime;
        seminar.Details = seminarModel.Details;
        seminar.Duration = seminarModel.Duration;
        seminar.Lecturer = seminarModel.Lecturer;
        seminar.Topic = seminarModel.Topic;
        seminar.CategoryId = seminarModel.CategoryId;
        seminar.OrganizerId = seminarModel.OrganizerId;

        await this
            ._dbContext
            .SaveChangesAsync();
    }

    public async Task DeleteSeminarByIdAsync(int seminarId)
    {
        Seminar seminar = await this
            .GetSeminarByIdAsync(seminarId, true, null);

        IEnumerable<SeminarParticipant> allSeminarsParticipantsToDelete = this
            ._dbContext
            .SeminarsParticipants
            .Where(sp => sp.SeminarId == seminarId);

        this
            ._dbContext
            .SeminarsParticipants
            .RemoveRange(allSeminarsParticipantsToDelete);

        this
            ._dbContext
            .Seminars
            .Remove(seminar);

        await this
            ._dbContext
            .SaveChangesAsync();
    }

    public async Task<bool> AddUserToSeminarAsync(int seminarId, string userId)
    {
        Seminar seminar = await this
            .GetSeminarByIdAsync(seminarId, true, new[] { SeminarsParticipantsProperty });

        if (seminar.SeminarsParticipants.All(sp => sp.ParticipantId != userId))
        {
            seminar.SeminarsParticipants.Add(new SeminarParticipant()
            {
                ParticipantId = userId,
                SeminarId = seminarId,
            });

            await this
                ._dbContext
                .SaveChangesAsync();

            return false;
        }

        return true;
    }

    public async Task RemoveUserFromSeminarAsync(int seminarId, string userId)
    {
        Seminar seminar = await this
            .GetSeminarByIdAsync(seminarId, 
                true,
                new string[] { SeminarsParticipantsProperty });

        SeminarParticipant? seminarParticipant = await this
            ._dbContext
            .SeminarsParticipants
            .FirstOrDefaultAsync(sp => sp.ParticipantId == userId && sp.SeminarId == seminarId);

        if (seminarParticipant == null)
        {
            throw new SeminarParticipantNotFoundException(string.Format(SeminarParticipantNotFoundExceptionMessage, seminarId, userId));
        }

        seminar.SeminarsParticipants.Remove(seminarParticipant);

        this
            ._dbContext
            .SeminarsParticipants
            .Remove(seminarParticipant);

        await this
            ._dbContext
            .SaveChangesAsync();
    }

    public async Task<IEnumerable<SeminarViewModel>> GetAllSeminarsWithFilterAsync(Expression<Func<Seminar, bool>>? filter)
    {
        IQueryable<Seminar> query = this._dbContext.Seminars;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        return await query
            .Select(s => new SeminarViewModel()
            {
                DateAndTime = s.DateAndTime.ToString(DateFormat),
                Details = s.Details,
                Duration = s.Duration,
                Lecturer = s.Lecturer,
                Topic = s.Topic,
                CategoryId = s.CategoryId,
                OrganizerId = s.OrganizerId,
                Id = s.Id,
                Category = s.Category.Name,
                Organizer = s.Organizer.UserName,
            })
            .AsNoTracking()
            .ToListAsync();
    }

    private async Task<Seminar> GetSeminarByIdAsync(int seminarId, bool tracking, string[]? propertiesToInclude)
    {
        IQueryable<Seminar> query = this
            ._dbContext
            .Seminars;

        Seminar? seminar;

        if (propertiesToInclude != null)
        {
            foreach (string property in propertiesToInclude)
            {
                query = query.Include(property);
            }
        }

        if (tracking)
        {
            seminar = await query
                .FirstOrDefaultAsync(s => s.Id == seminarId);
        }
        else
        {
            seminar = await query
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == seminarId);
        }

        if (seminar == null)
        {
            throw new SeminarNotFoundException(string.Format(SeminarNotFoundExceptionMessage, seminarId));
        }

        return seminar;
    }
}