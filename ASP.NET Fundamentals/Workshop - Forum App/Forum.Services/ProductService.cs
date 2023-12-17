namespace Forum.Services;

using Common.Exceptions.Post;
using Contracts;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using ViewModels.Post;

public class ProductService : IProductService
{
    private readonly ForumDbContext dbContext;

    public ProductService(ForumDbContext dbContext)
    {
        this.dbContext = dbContext; 
    }

    public async Task<IEnumerable<PostListViewModel>> ListAllAsync()
    {
        IEnumerable<PostListViewModel> allPosts = await dbContext.Posts
            .AsNoTracking()
            .Select(p => new PostListViewModel()
            {
                Id = p.Id.ToString(),
                Title = p.Title,
                Content = p.Content,
            })
            .ToArrayAsync();

        return allPosts;
    }

    public async Task AddPostAsync(PostFormModel post)
    {
        Post newPost = new Post()
        {
            Title = post.Title,
            Content = post.Content,
        };

        await this.dbContext.Posts.AddAsync(newPost);
        await this.dbContext.SaveChangesAsync();
    }

    public async Task<PostFormModel> GetPostById(string id)
    {
        Post? post = await this.dbContext
            .Posts
            .FindAsync(Guid.Parse(id));

        if (post == null)
        {
            throw new InvalidPostIdException();
        }

        return new PostFormModel()
        {
            Title = post.Title,
            Content = post.Content,
        };
    }

    public async Task EditPostByIdAsync(string id, PostFormModel model)
    {
        Post? postToEdit = await this.dbContext
            .Posts
            .FindAsync(Guid.Parse(id));

        if (postToEdit == null)
        {
            throw new InvalidPostIdException();
        }

        postToEdit.Title = model.Title;
        postToEdit.Content = model.Content;

        await this.dbContext.SaveChangesAsync();
    }

    public async Task DeletePostByIdAsync (string id)
    {
        Post? postToDelete = await this.dbContext
            .Posts
            .FindAsync(Guid.Parse(id));

        if (postToDelete == null)
        {
            throw new InvalidPostIdException();
        }

        this.dbContext.Posts.Remove(postToDelete);
        await this.dbContext.SaveChangesAsync();
    }
}