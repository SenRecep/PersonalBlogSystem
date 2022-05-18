using PersonalBlogSystem.DTO.Category;

namespace PersonalBlogSystem.BlazorUI.Services.Interfaces;

public interface IHttpCategoryService
{
    Task<CategoryDto?> GetCategoryById(Guid id);
    Task<IEnumerable<CategoryDto>?> GetCategories();

     Task<CategoryDto?> GetLoadedCategoryById(Guid id);
    Task<IEnumerable<CategoryDto>?> GetLoadedCategories();
}
