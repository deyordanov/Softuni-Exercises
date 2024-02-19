namespace SeminarHub.Services.Contracts;

using Data.Models;
using System.Linq.Expressions;
using ViewModels.Seminar;

public interface ISeminarService
{
    Task<CreateSeminarViewModel> GetSeminarForCreateAsync();
    Task<EditSeminarViewModel> GetSeminarForEditAsync(int seminarId);
    Task<DetailsSeminarViewModel> GetSeminarForDetailsAsync(int seminarId);
    Task<DeleteSeminarViewModel> GetSeminarForDeleteAsync(int seminarId);
    Task CreateSeminarAsync(CreateSeminarViewModel seminarModel, DateTime dateAndTime);
    Task EditSeminarAsync(EditSeminarViewModel seminarModel, DateTime dateAndTime);
    Task DeleteSeminarByIdAsync(int seminarId);
    Task<IEnumerable<SeminarViewModel>> GetAllSeminarsWithFilterAsync(Expression<Func<Seminar, bool>>? filter);
    Task<bool> AddUserToSeminarAsync(int seminarId, string userId);
    Task RemoveUserFromSeminarAsync(int seminarId, string userId);
}