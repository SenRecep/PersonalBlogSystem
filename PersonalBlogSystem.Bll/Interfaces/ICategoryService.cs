using PersonalBlogSystem.DTO.Category;
using PersonalBlogSystem.Entities.Concrete;

namespace PersonalBlogSystem.Bll.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetCategoriesAsync(bool isLoad=false);
    Task<CategoryDto?> GetCategoryById(Guid id, bool isLoad=false);
    Task AddAsync(Category category);
}
