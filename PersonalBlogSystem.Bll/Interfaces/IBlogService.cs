using PersonalBlogSystem.DTO.Blog;
using PersonalBlogSystem.Entities.Concrete;

namespace PersonalBlogSystem.Bll.Interfaces;

public interface IBlogService
{
    Task<IEnumerable<BlogDto>> GetBlogsAsync();
    Task<BlogDto?> GetBlogById(Guid id);
    Task AddAsync(Blog blog);
}
