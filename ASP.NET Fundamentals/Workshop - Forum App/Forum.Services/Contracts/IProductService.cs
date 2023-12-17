namespace Forum.Services.Contracts;

using Data.Models;
using ViewModels.Post;

public interface IProductService
{
    Task<IEnumerable<PostListViewModel>> ListAllAsync();

    Task AddPostAsync (PostFormModel model);

    Task<PostFormModel> GetPostById(string id);

    Task EditPostByIdAsync (string id, PostFormModel model);

    Task DeletePostByIdAsync (string id);
}