using System.Threading.Tasks;
using Post.Query.Domain.Entities;
using System.Collections.Generic;

namespace Post.Query.Api.Queries;

public interface IQueryHandler
{
    Task<List<PostEntity>> HandleAsync(FindAllPostsQuery query);
    Task<List<PostEntity>> HandleAsync(FindByIdQuery query);
    Task<List<PostEntity>> HandleAsync(FindPostsByAuthor query);
    Task<List<PostEntity>> HandleAsync(FindPostsWithCommentsQuery query);
    Task<List<PostEntity>> HandleAsync(FindPostsWithLikesQuery query);
}
