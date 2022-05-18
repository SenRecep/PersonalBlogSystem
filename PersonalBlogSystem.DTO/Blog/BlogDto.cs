using PersonalBlogSystem.Core.Interfaces;
using PersonalBlogSystem.DTO.Category;

namespace PersonalBlogSystem.DTO.Blog;

public class BlogDto:IDTO
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public CategoryDto? Category { get; set; }
}
