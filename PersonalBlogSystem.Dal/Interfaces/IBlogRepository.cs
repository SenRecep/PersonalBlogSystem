using PersonalBlogSystem.Entities.Concrete;

namespace PersonalBlogSystem.Dal.Interfaces;

public interface IBlogRepository
{
    Task<IEnumerable<Blog>> GetBlogsAsync();
    Task<IEnumerable<Blog>> GetBlogsByCategoryIdAsync(Guid id);
    Task<Blog?> GetBlogById(Guid id);
    Task AddAsync(Blog blog);
}
