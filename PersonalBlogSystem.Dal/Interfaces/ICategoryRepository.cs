using PersonalBlogSystem.Entities.Concrete;

namespace PersonalBlogSystem.Dal.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategoriesAsync(bool isLoad = false);
    Task<Category?> GetCategoryById(Guid id, bool isLoad = false);

    Task AddAsync(Category category);
}
