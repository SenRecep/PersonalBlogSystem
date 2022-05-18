using PersonalBlogSystem.DTO.Blog;

namespace PersonalBlogSystem.BlazorUI.Services.Interfaces;

public interface IHttpBlogService
{
    Task<BlogDto?> GetBlogByIdAsync(Guid id);
    Task<IEnumerable<BlogDto>?> GetBlogsAsync();
}
