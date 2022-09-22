using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Post.Query.Domain.Entities;
using Post.Query.Domain.Repositories;
using Post.Query.Infrastructure.DataAccess;

namespace Post.Query.Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly DatabaseContextFactory _contextFactory;

    public PostRepository(DatabaseContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task CreateAsync(PostEntity post)
    {
        using DatabaseContext context = _contextFactory.CreateDbContext();

        context.Posts.Add(post);
        await context.SaveChangesAsync();
    }

    public Task DeleteAsync(Guid postId)
    {
        throw new NotImplementedException();
    }

    public Task<PostEntity> GetByIdAsync(Guid postId)
    {
        throw new NotImplementedException();
    }

    public Task<List<PostEntity>> ListAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<PostEntity>> ListByAuthorAsync(string author)
    {
        throw new NotImplementedException();
    }

    public Task<List<PostEntity>> ListWithCommentsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<PostEntity>> ListWithLikes(int numberOfLikes)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(PostEntity post)
    {
        throw new NotImplementedException();
    }
}
