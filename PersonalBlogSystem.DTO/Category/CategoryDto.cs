using PersonalBlogSystem.Core.Interfaces;
using PersonalBlogSystem.DTO.Blog;

namespace PersonalBlogSystem.DTO.Category;

public class CategoryDto:IDTO
{
    public Guid? Id{ get; set; }
    public string? Name { get; set; }
    public IEnumerable<CategoryDto>? Categories { get; set; }
    public IEnumerable<BlogDto>? Blogs { get; set; }
}
